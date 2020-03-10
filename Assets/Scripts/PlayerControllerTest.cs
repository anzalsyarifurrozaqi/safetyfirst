using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerControllerTest : MonoBehaviour
{
    PlayerController playerController;
    GameObject player;
    float speed = 1.0f;
    float forward = 2.0f;
    Rigidbody2D rb;
    bool breaker = false;    

    private void Start()
    {
        playerController = PlayerController.Instance;
        player = GameObject.FindGameObjectWithTag("Player");
        rb = player.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    private void Update()
    {
        
        if (playerController.Tap)
        {
            Debug.Log("Tap");
        }

        if (playerController.SwipeLeft)
        {
            Debug.Log("Swipe Left");
            rb.velocity = new Vector2(-speed, rb.velocity.y);
        }

        if (playerController.SwipeRight)
        {
            Debug.Log("Swipe Right");
            rb.velocity = new Vector2(speed, rb.velocity.y);
        }

        if (playerController.SwipeDown)
        {
            Debug.Log("Swipe Down");
            breaker = true;
            rb.velocity = Vector2.zero;
            if (breaker)
                StartCoroutine(DoBreak());
        }

        if (!breaker)
        {
            rb.velocity = new Vector2(rb.velocity.x, forward);
        }
    }

    IEnumerator DoBreak()
    {
        yield return new WaitForSecondsRealtime(0.6f);

        breaker = false;
    }   
}
