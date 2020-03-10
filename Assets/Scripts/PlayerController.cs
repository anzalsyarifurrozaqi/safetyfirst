using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    #region Instance
    private static PlayerController instance;
    public static PlayerController Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<PlayerController>();
                if (instance == null)
                {
                    instance = new GameObject("Game Object", typeof(PlayerController)).GetComponent<PlayerController>();

                }
            }
            return instance;
        }

        set
        {
            instance = value;
        }
    }
    #endregion

    [Header("Tweaks")]
    [SerializeField] private float deadZone = 100.0f;

    [Header("Logic")]
    private bool tap, swipeLeft, swipeRight, swipeDown;
    private Vector2 swipeDelta, startTouch;
    private float lastTap;
    private float sqrDeadzone;

    #region Public properties
    public bool Tap { get { return tap; } }
    public Vector2 SwipeDelta { get { return swipeDelta; } }
    public bool SwipeLeft { get { return swipeLeft; } }
    public bool SwipeRight { get { return swipeRight; } }
    public bool SwipeDown { get { return swipeDown; } }
    #endregion
 
    private void Start()
    {
        sqrDeadzone = deadZone * deadZone;
    }

    private void Update()
    {
        tap = swipeLeft = swipeRight = swipeDown = false;

        UpdateStandalone();
    }

    private void UpdateStandalone()
    {
        if (Input.GetMouseButtonDown(0))
        {
            tap = true;
            startTouch = Input.mousePosition;
            lastTap = Time.time;
        }
        else if (Input.GetMouseButtonUp(0))
        {
            startTouch = swipeDelta = Vector2.zero;
        }

        swipeDelta = Vector2.zero;

        if (startTouch != Vector2.zero && Input.GetMouseButton(0))
            swipeDelta = (Vector2)Input.mousePosition - startTouch;

        if (swipeDelta.sqrMagnitude > sqrDeadzone)
        {
            float x = swipeDelta.x;
            float y = swipeDelta.y;
            if (Mathf.Abs(x) > Mathf.Abs(y))
            {
                if (x < 0)
                    swipeLeft = true;
                else
                    swipeRight = true;
            }
            else
            {
                if (y < 0)
                    swipeDown = true;
            }
            startTouch = swipeDelta = Vector2.zero;
        }
    }
}
