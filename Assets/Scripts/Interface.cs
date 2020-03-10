using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public interface IText
{
    Text text { get; }

    void setText(string text);
    void clearText();
}

public interface IRambu
{    
    void OnTriggerEnter2D(Collider2D other);
    void OnTriggerStay2D(Collider2D other);
    void OnTriggerExit2D(Collider2D other);
}
