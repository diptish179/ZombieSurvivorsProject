using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnergyBall : MonoBehaviour
{

    [SerializeField] int energyBallDmg = 1;

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
            enemy.Damage(energyBallDmg);

        }

        BossEnemy bossenemy = collision.GetComponent<BossEnemy>();
        if (bossenemy != null)
        {
            bossenemy.Damage(energyBallDmg);

        }
    }
}
