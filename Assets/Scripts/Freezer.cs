using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Freezer : MonoBehaviour
{
    #region Instance
    private static Freezer instance;
    public static Freezer Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<Freezer>();
                if (instance == null)
                {
                    instance = new GameObject("Game Object", typeof(Freezer)).GetComponent<Freezer>();

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
    
   
}
