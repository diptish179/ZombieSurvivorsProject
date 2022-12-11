using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossEnemy : MonoBehaviour
{
    GameObject player;
    [SerializeField] GameObject crystalPrefab;
    [SerializeField] SpriteRenderer spriteRenderer;
    [SerializeField] float speed = 0.5f;
    public bool isTrackingPlayer = true;
    public int currentenemyHP;
    public int maxenemyHP = 20;
    Material material;


    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        currentenemyHP = maxenemyHP;
        material = spriteRenderer.material;
        StartCoroutine(BossCameraCoroutine());
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Player player = collision.GetComponent<Player>();
        if (!player.isInvincible)
        {
            if (player.OnDamage())
            {
                //Destroy(gameObject);
                currentenemyHP--;
                //Instantiate(crystalPrefab, transform.position, Quaternion.identity);
                
            }
        }
    }

    IEnumerator BossCameraCoroutine()
    {
        Time.timeScale = 0;

        Camera.main.GetComponent<PlayerCamera>().target = transform;
        Camera.main.orthographicSize = 4f;
        yield return new WaitForSecondsRealtime(5f);

        Camera.main.GetComponent<PlayerCamera>().target = player.transform;
        Camera.main.orthographicSize = 5f;
        yield return new WaitForSecondsRealtime(2f);
        Time.timeScale = 1;

    }

    // Update is called once per frame
    void Update()
    {
        material.SetFloat("_Glow",(1- (float)currentenemyHP/maxenemyHP));
        Vector3 destination = player.transform.position;
        Vector3 source = transform.position;
        Vector3 direction = destination - source;

        if (!isTrackingPlayer)
        {
            direction = new Vector3(1, 0, 0);
        }
        direction.Normalize();
        transform.position += direction * Time.deltaTime * speed;

        int scaleX = 1;
        if (direction.x > 0)
        {
            scaleX = -1;
        }
        transform.localScale = new Vector3(scaleX, 1, 1);
        
    }

    internal void Damage(int damage)
    {
        currentenemyHP -= damage;
        if (currentenemyHP <= maxenemyHP / 2 && speed == 0.5)
        {
            speed = speed * 3;
        }

        if (currentenemyHP < 1)
        {
            
            //TitleManager.saveData.goldCoins++;
            Destroy(gameObject);
            Instantiate(crystalPrefab, transform.position, Quaternion.identity);
            //crystalPrefab.transform.localScale = new Vector3(2, 2, 2);
        }

    }
}
