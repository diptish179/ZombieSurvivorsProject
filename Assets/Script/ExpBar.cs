using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ExpBar : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] Player player;
    [SerializeField] Image foreground;
    [SerializeField] TMP_Text expLevelText;

    

    private void Update()
    {
        float expRatio = (float) player.currentExp / player.expToLevel;
        foreground.transform.localScale = new Vector3 (expRatio,1,1);

        expLevelText.text =  "XP Level " + player.currentLevel.ToString();
    }
}
