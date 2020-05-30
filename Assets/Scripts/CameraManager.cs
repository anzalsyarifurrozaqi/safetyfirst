using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    public Transform target;
    public float smoothTime;
    public float posX;
    public float minY;
    public float maxY;
    public float overY;
   
    private Vector3 velocity = Vector3.zero;

    void Start()
    {
        //enemy = GameObject.FindWithTag("Enemy");
        //player = GameObject.FindWithTag("Player");       
    }
    void Update()
    {
        Vector3 targetPosition = target.TransformPoint(new Vector3(posX, 0, -20));
        Vector3 desiredPosition = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime * Time.fixedDeltaTime);
        transform.position = new Vector3(desiredPosition.x, Mathf.Clamp(desiredPosition.y, target.position.y - minY, target.position.y + maxY) + overY, desiredPosition.z);        
    }
}
