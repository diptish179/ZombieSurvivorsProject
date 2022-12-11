using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrystalBox : MonoBehaviour
{
    GameObject[] crystalBalls;
    GameObject player;

    [System.Obsolete]
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Player player = collision.GetComponent<Player>();
        if (player != null)
        {
            foreach (GameObject item in crystalBalls)
            {
                Destroy(item);
                player.AddExp();
            }
            DestroyObject(gameObject, 0.5f);
            
            
        }
    }
    // Start is called before the first frame update
    void Start()
    {
       
        
    }

    // Update is called once per frame
    void Update()
    {
        crystalBalls = GameObject.FindGameObjectsWithTag("Crystal");
        
    }


    
}
