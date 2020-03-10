using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    public Vector3 newDesiredPosition = Vector3.zero;
    public float cameraMoveSpeed = 0f;
    public bool cameraMoveAble = false;
    //public struct mainMenuCamera
    //{
    //    public Vector3 newDesiredPosition;
    //    public float cameraMoveSpeed;
    //    public bool cameraMoveAble;
    //}
    //mainMenuCamera _camera;
    //mainMenuCamera _getCamera
    //{
    //    get
    //    {
    //        return _camera;
    //    }

    //    set
    //    {
    //        Debug.Log($"campos {_camera.newDesiredPosition}, {_camera.cameraMoveSpeed}");
    //        _camera = value;
    //    }
    //}


    //public void setMove(bool cameraMoveAble ,Vector3 newDesiredPosition, float cameraMoveSpeed)
    //{        
    //    _camera.cameraMoveAble = cameraMoveAble;
    //    _camera.newDesiredPosition = newDesiredPosition;
    //    _camera.cameraMoveSpeed = cameraMoveSpeed;

    //}
    void Update()
    {           
        if (cameraMoveAble)
        {
            Debug.Log("jfkdfk");
            StartCoroutine(ToTarget(transform.position, newDesiredPosition, cameraMoveSpeed));
        }
    }
    public IEnumerator ToTarget(Vector3 pos1, Vector3 pos2, float duration)
    {
        Debug.Log($"campos {pos1}, {pos2}");
        for (float t = 0; t < duration; t += Time.deltaTime)
        {
            transform.position = Vector3.Lerp(pos1, pos2, t / duration);
        }
        cameraReset();
        yield return 0;
    }

    
    void cameraReset()
    {
        transform.position = newDesiredPosition;
        cameraMoveAble = false;
        newDesiredPosition = Vector2.zero;
        cameraMoveSpeed = 0f;
    }

    
    public void Orthographic(float distance)
    {

    }
}
