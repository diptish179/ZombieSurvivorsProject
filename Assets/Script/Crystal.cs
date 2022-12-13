using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crystal : MonoBehaviour
{
   

    void Start()
    {
       

    }



    private void OnTriggerEnter2D(Collider2D collision)
    {
        Player player = collision.GetComponent<Player>();
        if(player)
        {
            TitleManager.saveData.crystalCount++;
            Destroy(gameObject);
           
            player.AddExp();
        }
    }
}
