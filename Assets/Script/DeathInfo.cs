using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathInfo : MonoBehaviour
{
    [SerializeField] Player player;
    [SerializeField] Enemy enemy;
    //[SerializeField] Image foreground;
    [SerializeField] TMP_Text totalKills;
    [SerializeField] TMP_Text totalCrystals;
    [SerializeField] TMP_Text totalHealPotions;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        totalKills.text = "Total Kills: " + TitleManager.saveData.killCount.ToString();
        totalCrystals.text = "Crystals: " + TitleManager.saveData.crystalCount.ToString();
        totalHealPotions.text = "HealPotions: " + TitleManager.saveData.healpotionCount.ToString();
    }

    public void OnMainMenuButtonClick()
    {
        SceneManager.LoadScene("Title");
    }

    public void OnRetryButtonClick()
    {
        //Debug.Log("To do");
        SceneManager.LoadScene("Level 1");
    }

    public void OnExitButtonClick()
    {
        Application.Quit();
    }
}
