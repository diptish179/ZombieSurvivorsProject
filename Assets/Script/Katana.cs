using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Katana : BaseWeapon
{
    SpriteRenderer spriteRenderer;
    BoxCollider2D boxCollider2D;
    AudioSource katanaAttack;
    [SerializeField] int katanaDmg = 2;

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        boxCollider2D = GetComponent<BoxCollider2D>();
        katanaAttack = GetComponent<AudioSource>();
        StartCoroutine(KatanaCoroutine());
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator KatanaCoroutine()
    {
        while (true)
        {
            spriteRenderer.enabled = true;
            boxCollider2D.enabled = true;
            katanaAttack.Play();
            yield return new WaitForSeconds(0.5f);
            spriteRenderer.enabled = false;
            boxCollider2D.enabled = false;
            yield return new WaitForSeconds(2f);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Enemy enemy = collision.GetComponent<Enemy>();
        if (enemy != null)
        {
                   enemy.Damage(katanaDmg);
           
        }

        BossEnemy bossenemy = collision.GetComponent<BossEnemy>();
        if (bossenemy != null)
        {
            bossenemy.Damage(katanaDmg);

        }

    }


}
