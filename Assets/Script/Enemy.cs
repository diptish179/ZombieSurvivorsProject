using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    protected GameObject player;
    [SerializeField]GameObject crystalPrefab;
    [SerializeField] public float speed = 1f;
    public bool isTrackingPlayer = true;
    public int enemyHP = 3;


    protected virtual void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Player player = collision.GetComponent<Player>();
        if (!player.isInvincible)
        {
            if (player.OnDamage())
            {
                Destroy(gameObject);
                Instantiate(crystalPrefab, transform.position, Quaternion.identity);
            }
        }
    }

    // Update is called once per frame
    protected virtual void Update()
    {
        Vector3 destination = player.transform.position;
        Vector3 source = transform.position;
        Vector3 direction = destination - source;

        if(!isTrackingPlayer)
        {
            direction = new Vector3(1, 0, 0);
        }
        direction.Normalize();
        transform.position += direction * Time.deltaTime * speed;

        int scaleX = 1;
        if(direction.x > 0)
        {
            scaleX = -1;
        }
        transform.localScale = new Vector3(scaleX, 1, 1);
    }

    internal virtual void Damage(int damage)
    {
        enemyHP -= damage;
        if (enemyHP < 1)
        {
            //TitleManager.saveData.goldCoins++;
            Destroy(gameObject);
            Instantiate(crystalPrefab, transform.position, Quaternion.identity);
            
        }
        
    }
}
