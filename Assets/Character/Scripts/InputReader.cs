using UnityEngine;

public class InputReader : MonoBehaviour
{
    [Header("Logic")]   
    private bool isDraging = false;
    private Vector2 swipeDelta, startTouch;  
   
    private void Reset()
    {
        isDraging = false;
        startTouch = swipeDelta = Vector2.zero;
    }
    
    public Vector2 ReadMove(Touch touch)
    {
        float vertical = 0;
        if (touch.phase == TouchPhase.Began)
        {
            isDraging = true;
            startTouch = touch.position;
        }
        else if (touch.phase == TouchPhase.Ended)
        {
            Reset();
        }       

        swipeDelta = Vector2.zero;
        if (isDraging)
        {
            if (Input.touches.Length > 0)
                swipeDelta = touch.position - startTouch;
        }

        if (swipeDelta.magnitude > 50)
        {
            float x = swipeDelta.x;
            float y = swipeDelta.y;

            if (Mathf.Abs(x) > Mathf.Abs(y))
            {                
                if (x > 0)
                {
                    vertical = 1f;
                }
                else
                {
                    vertical = -1f;
                }
            }           
        }

        if (vertical != 0)
        {
            return new Vector2(vertical, 0);
        }

        return Vector2.zero;

    }

    public Vector2 ReadDirection(Touch touch)
    {
        if (touch.phase == TouchPhase.Began)
        {
            isDraging = true;
            startTouch = touch.position;
        }
        else if (touch.phase == TouchPhase.Ended)
        {
            Reset();
        }

        if (touch.tapCount == 2)
        {
            Debug.Log("Double tap..");
            if (touch.position.x > Screen.width / 2)
            {
                Debug.Log("Right click");
                var direction = new Vector2(1, 0);
                return direction;
            }
            else
            {
                Debug.Log("Left click");
                var direction = new Vector2(-1, 0);
                return direction;
            }
        }

        return Vector2.zero;
    }

    public bool ReadBreak(Touch touch)
    {
        if (touch.phase == TouchPhase.Began)
        {
            isDraging = true;
            startTouch = touch.position;
        }
        else if (touch.phase == TouchPhase.Ended)
        {
            Reset();
        }        

        swipeDelta = Vector2.zero;
        if (isDraging)
        {
            if (Input.touches.Length > 0)
                swipeDelta = touch.position - startTouch;
        }

        if (swipeDelta.magnitude > 100)
        {
            float x = swipeDelta.x;
            float y = swipeDelta.y;

            if (Mathf.Abs(y) > Mathf.Abs(x))
            {
                if (y < 0)
                {
                    if (touch.phase == TouchPhase.Stationary)
                    {
                        Debug.Log("hold down");
                        return true;
                    }
                }                
            }
        }
        return false;
    }
}
