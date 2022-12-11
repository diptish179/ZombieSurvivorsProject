using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GiantKnife : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // The amount of damage the knife should do to the player on collision

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Player player = collision.GetComponent<Player>();
        if (!player.isInvincible)
        {
            if (player.OnDamage())
            {
                Destroy(gameObject);
                //Instantiate(crystalPrefab, transform.position, Quaternion.identity);
            }
        }
    }
    

}
