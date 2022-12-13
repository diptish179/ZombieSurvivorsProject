using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    [SerializeField] private float speed = 1f;
    //[SerializeField] GameObject weapon;
    [SerializeField] GameManager gameManager;
    [SerializeField] SpriteRenderer spriteRenderer;
    [SerializeField] BaseWeapon[] weapons;
    AudioSource playerLevelupAudio;

    Animator animator;
    Material material;

    public double currentHP;
    public double maxHP = 6;
    public bool isInvincible;

    internal int currentExp=0;
    internal int expToLevel = 5;
    public int currentLevel;

    public int levelCount = 0;

    internal void AddExp()
    {
        currentExp++;
        if(currentExp == expToLevel)
        {
            currentExp = 0;
            expToLevel += 5;
            currentLevel++;
            playerLevelupAudio.Play();
            int randomIndex = UnityEngine.Random.Range(0, weapons.Length);
            weapons[randomIndex].LevelUp();
        }
        // If the player's current experience level is 5, load the "Level 2" scene
        if (currentLevel == 5)
        {
            levelCount++;
            SceneManager.LoadScene("Level 2");
        }
    }

    internal void PlayerHeal0()
    {
        StartCoroutine(HealCouroutine());
        if (currentHP <= 0)
        {
            currentHP = 0.25;
        }
        else
        {
            currentHP = currentHP + (0.25 * currentHP);
        } 
    }

    internal void PlayerHeal1()
    {
        StartCoroutine(HealCouroutine());
        if (currentHP <= 0)
        {
            currentHP = 0.5;
        }
        else
        {
            currentHP = currentHP + (0.5 * currentHP);
        }
        
    }


    public bool OnDamage()
    {
        if(!isInvincible)
        {
            isInvincible = true;
            StartCoroutine(InvincibilityCoroutine());
            if (currentHP-- <= 0)
            {
                //TitleManager.saveData.deathCount++;
                Destroy(gameObject);
                SceneManager.LoadScene("Title");
                
            } return true;
        }    return false;    
    }

    IEnumerator HealCouroutine()
    {
        material.SetFloat("_HealGlow", 0.4f);
        yield return new WaitForSeconds(1f);
        material.SetFloat("_HealGlow", 0);
    }

    IEnumerator InvincibilityCoroutine()
    {
        isInvincible = true;
        //spriteRenderer.color = Color.red; 
        material.SetFloat("_Flash", 0.4f);
        yield return new WaitForSeconds(1f);
        //spriteRenderer.color = Color.white;
        material.SetFloat("_Flash", 0);
        isInvincible = false;
    }

    // Start is called before the first frame update
    void Start()
    {
        currentHP = maxHP;
        animator = GetComponent<Animator>();
        playerLevelupAudio = GetComponent<AudioSource>();
        //StartCoroutine(AxeCoroutine());
        material = spriteRenderer.material;
        
    }

    // Update is called once per frame
    void Update()
    {
        //isInvincible = false;

        float inputX = Input.GetAxis("Horizontal");
        float inputY = Input.GetAxis("Vertical");
        
        transform.position += new Vector3(inputX, inputY, 0) * speed * Time.deltaTime;
        
        if (inputX != 0)
        {
            transform.localScale = new Vector3(inputX > 0 ? -1 : 1, 1, 1);
        }

        bool isRunning = false;

        if(inputX != 0)
        {
            isRunning = true;
        }
        else if (inputY != 0)
        {
            isRunning = true;
        }

        animator.SetBool("IsRunning", isRunning);
    }
}
