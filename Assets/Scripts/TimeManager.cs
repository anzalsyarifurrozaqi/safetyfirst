using UnityEngine;
using UnityEngine.UI;

public class TimeManager : MonoBehaviour
{
    double miliSeconds = 1;
    double second = 0;
    double minute = 5;
    Text TimeText
    {
        get
        {
            GameObject objectParent = GameObject.Find("Canvas");
            GameObject text = objectParent.transform.Find("TimeText").gameObject;

            Text textObject = text.GetComponent<Text>();

            return textObject;
        }
    }

    private void FixedUpdate()
    {
        miliSeconds += miliSeconds * 0.1;        
        if (miliSeconds >= 100)
        {
            second--;
            miliSeconds = 1;
        }      
        if (second == 0)
        {
            minute--;
            second = 59;
        }
            

        var minutesText = (minute >= 10) ? minute.ToString() :  "0" + minute.ToString();
        var secondsText = (second >= 10) ? second.ToString() : "0" + second.ToString();
        TimeText.text = minutesText + ":" + secondsText;
    }
}
