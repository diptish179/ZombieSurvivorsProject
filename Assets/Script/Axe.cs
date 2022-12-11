using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Axe : BaseWeapon
{
    // Start is called before the first frame update
    SpriteRenderer spriteRenderer;
    CircleCollider2D circleCollider2D;
    AudioSource axeAttack;
    [SerializeField] int axeDamage = 3;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        circleCollider2D = GetComponent<CircleCollider2D>();
        axeAttack = GetComponent<AudioSource>();
        StartCoroutine(AxeCoroutine());

    }

    IEnumerator AxeCoroutine()
    {
        while (true)
        {
            spriteRenderer.enabled = true;
            circleCollider2D.enabled = true;
            axeAttack.Play();
            yield return new WaitForSeconds(0.5f);
            spriteRenderer.enabled = false;
            circleCollider2D.enabled = false;
            yield return new WaitForSeconds(2f);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Enemy enemy = collision.GetComponent<Enemy>();
        if (enemy != null)
        {
            enemy.Damage(axeDamage);

        }
        BossEnemy bossenemy = collision.GetComponent<BossEnemy>();
        if (bossenemy != null)
        {
            bossenemy.Damage(axeDamage);

        }
    }
}
