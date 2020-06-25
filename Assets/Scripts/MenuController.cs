using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{      
    public void OnPlay()
    {
              
    }  
    public void OnSetting()
    {
        SceneManager.LoadScene("Setting");
    }   
    public void OnCredits()
    {
        SceneManager.LoadScene("Credits");
    }

    public void OnMain()
    {        
        SceneManager.LoadScene("Main Menu");
        Time.timeScale = 1;        
    }

    public void OnLevel1()
    {
        SceneManager.LoadScene("Level 1");
    }

    public void OnLevel2()
    {
        SceneManager.LoadScene("Level 2");
    }

    public void OnLevel3()
    {
        SceneManager.LoadScene("Level 3");
    }

    public void ClickExit()

    {
        Application.Quit();
    }
}
