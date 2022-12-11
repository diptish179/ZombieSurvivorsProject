using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scythe : MonoBehaviour
{
    [SerializeField] int scytheDmg = 4;
    // Start is called before the first frame update
  

    // Update is called once per frame
    void Update()
    {
        transform.position += transform.up * 5 * Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Enemy enemy = collision.GetComponent<Enemy>();
        if (enemy != null)
        {
            //Debug.Log("Scythe contact with enemy");
            enemy.Damage(scytheDmg);

        }

        BossEnemy bossenemy = collision.GetComponent<BossEnemy>();
        if (bossenemy != null)
        {
            bossenemy.Damage(scytheDmg);

        }
    }
}
