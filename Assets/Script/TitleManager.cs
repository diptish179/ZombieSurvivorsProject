using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleManager : MonoBehaviour
{

    public static SaveData saveData; 
    string SavePath => Path.Combine(Application.persistentDataPath, "save.data");

    private void Awake() 
    {
        if (saveData == null)
        {
            Load(); 
        }
        else
        { 
            Save(); 
        }

        Debug.Log($"goldcoins: {saveData.goldCoins}, deathcounter: {saveData.deathCount}");
    }

    private void Load()
    {
        FileStream file = null;
        try
        {
            file = File.Open(SavePath, FileMode.Open);
            var bf = new BinaryFormatter();
            saveData = bf.Deserialize(file) as SaveData;
        }
        catch (Exception e)
        {
            Debug.Log(e.Message);
            saveData = new SaveData();
        }
        finally
        {
            if (file != null) file.Close();
        }
    }

    private void Save()
    {
        FileStream file = null;
        try 
        {
            if (!Directory.Exists(Application.persistentDataPath))
            {
                Directory.CreateDirectory(Application.persistentDataPath); 
            }
            file = File.Create(SavePath); 
            var bf = new BinaryFormatter();
            bf.Serialize(file, saveData); 
        } 
        catch (Exception e)
        { 
            Debug.Log(e); 
        } 
        finally 
        { 
            if (file != null) 
                file.Close();
        }
    }



    // Start is called before the first frame update
    public void OnStartButtonClick()
    {
        SceneManager.LoadScene("Level 1");
    }

    public void OnUpgradeButtonClick()
    {
        Debug.Log("To do");
    }

    public void OnExitButtonClick()
    {
        Application.Quit();
    }

}
