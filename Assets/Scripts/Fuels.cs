using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fuels : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject fuel;
    public float respawnTime;
    Vector2 screenBounds;
    public Camera cam;

    void Start()
    {        
        StartCoroutine(coinWave());
    }   
    private void spawnFuel()
    {
        Debug.Log(screenBounds);
        GameObject a = Instantiate(fuel) as GameObject;
        a.transform.position = new Vector2(Random.Range(-screenBounds.x, screenBounds.x), screenBounds.y + 10);
    }

    // Update is called once per frame
    IEnumerator coinWave()
    {
        while (true)
        {
            yield return new WaitForSeconds(respawnTime);
            screenBounds = cam.ScreenToWorldPoint(new Vector3(Screen.width, cam.transform.position.y, cam.transform.position.z));
            spawnFuel();
        }
    }
}
