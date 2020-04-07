using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementBG : MonoBehaviour
{
    public float speed = 1f; // for BG speed movements

    public float clamppos; // for clamping position

    public Vector3 StartPosition; // get our first position

    // Start is called before the first frame update
    void Start()
    {
        StartPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        float NewPosition = Mathf.Repeat(Time.time * speed , clamppos);
        transform.position = StartPosition + Vector3.left * NewPosition;
    }
}
