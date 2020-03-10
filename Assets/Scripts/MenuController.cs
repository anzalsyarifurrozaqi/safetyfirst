using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    public GameObject mainMenuamera;
    CameraManager _cameraManager;

    private void Start()
    {
        _cameraManager = new CameraManager();
    }
    public void OnPlay()
    {
        var camPos = mainMenuamera.transform.position;        
        GameObject objectParent = GameObject.Find("Level Menu");
        Vector3 newDesiredPosition = objectParent.transform.Find("Scroll View").GetComponent<Transform>().position;
        newDesiredPosition = new Vector3(newDesiredPosition.x, newDesiredPosition.y, -10);
        mainMenuamera.GetComponent<CameraManager>().cameraMoveAble = true;
        mainMenuamera.GetComponent<CameraManager>().newDesiredPosition = newDesiredPosition;
        mainMenuamera.GetComponent<CameraManager>().cameraMoveSpeed = 1f;

        //camera.transform.Translate(new Vector3(camera.transform.position.x + 20f, camera.transform.position.y, camera.transform.position.z));
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
