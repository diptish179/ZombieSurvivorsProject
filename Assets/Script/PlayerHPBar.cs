using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHPBar : MonoBehaviour
{
    [SerializeField] Player player;
    [SerializeField] Image foreground;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = player.transform.position + new Vector3(0.75f, 0.75f, 0);
        double hpRatio = player.currentHP / player.maxHP;
        foreground.transform.localScale = new Vector3((float)hpRatio, 1, 1);
    }
}
