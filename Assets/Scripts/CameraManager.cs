using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    public Transform target;
    public float smoothTime;
    public float posY;
    public float minY;
    public float maxY;
    public float overY;
   
    private Vector3 velocity = Vector3.zero;
    private void Start()
    {
        transform.position = target.position;
    }
    void Update()
    {
        Vector3 targetPosition = target.TransformPoint(new Vector3(15, posY, -20));
        Vector3 desiredPosition = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime * Time.fixedDeltaTime);
        transform.position = new Vector3(transform.position.x, Mathf.Clamp(desiredPosition.y, target.position.y - minY, target.position.y + maxY) + overY, desiredPosition.z);        
    }
}
