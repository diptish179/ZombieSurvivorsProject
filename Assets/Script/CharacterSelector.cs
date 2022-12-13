using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterSelector : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnMainMenuButtonClick()
    {
        SceneManager.LoadScene("Title");
    }

    public void OnJuliusButtonClick()
    {
        SceneManager.LoadScene("Title");
    }

    public void OnArikadoButtonClick()
    {
        SceneManager.LoadScene("Title");
    }
}
