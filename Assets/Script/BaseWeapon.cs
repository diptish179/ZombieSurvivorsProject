using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseWeapon : MonoBehaviour
{
    // Start is called before the first frame update
    protected int level = 0;

    internal void LevelUp()
    {
        if (++level==1)
        {
            gameObject.SetActive(true);
        }
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
