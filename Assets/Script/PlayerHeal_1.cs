using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHeal_1 : MonoBehaviour
{
    AudioSource playerHealSFX;
    GameObject player;

    [System.Obsolete]
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Player player = collision.GetComponent<Player>();

        if (player != null && player.currentHP < player.maxHP)
        {
            /// Add 2 hp to player 
            //Debug.Log("Picked up 1 HP");
            player.PlayerHeal1();
            playerHealSFX.Play();
            DestroyObject(gameObject, 0.5f);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        playerHealSFX = GetComponent<AudioSource>();
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {

    }
}
