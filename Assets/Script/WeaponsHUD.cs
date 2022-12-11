using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeaponsHUD : MonoBehaviour
{
    [SerializeField] Image[] weaponsImages;
    [SerializeField] BaseWeapon[] weapons;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(weapons[0].gameObject.activeInHierarchy)
        {
            weaponsImages[0].gameObject.SetActive(true);
        }

        if(weapons[1].gameObject.activeInHierarchy)
        {
            weaponsImages[1].gameObject.SetActive(true);
        }

        if (weapons[2].gameObject.activeInHierarchy)
        {
            weaponsImages[2].gameObject.SetActive(true);
        }

        if (weapons[3].gameObject.activeInHierarchy)
        {
            weaponsImages[3].gameObject.SetActive(true);
        }

        if (weapons[4].gameObject.activeInHierarchy)
        {
            weaponsImages[4].gameObject.SetActive(true);
        }

    }
}
