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
    }
}
