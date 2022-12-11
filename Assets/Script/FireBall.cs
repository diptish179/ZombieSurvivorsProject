using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBall : MonoBehaviour
{

    [SerializeField] int fireBallDmg = 3;

    void Update()
    {
        transform.position += transform.up * 5 * Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Enemy enemy = collision.GetComponent<Enemy>();
        if (enemy != null)
        {
            //Debug.Log("EBall contact with enemy");
            enemy.Damage(fireBallDmg);

        }

        BossEnemy bossenemy = collision.GetComponent<BossEnemy>();
        if (bossenemy != null)
        {
            bossenemy.Damage(fireBallDmg);

        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

}
