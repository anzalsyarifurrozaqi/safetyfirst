using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FuelMove : MonoBehaviour
{
	// Use this for initialization
	public float speed;
	Vector3 kebawah;
	Vector2 screenBounds;
	Camera cam;
	void Start()
	{
		kebawah = new Vector3(0, -1, 0);
		cam = FindObjectOfType<Camera>();
	}

	// Update is called once per frame
	void Update()
	{
		screenBounds = cam.ScreenToWorldPoint(new Vector3(Screen.width, cam.transform.position.y, cam.transform.position.z));
		transform.position += (kebawah * speed * Time.deltaTime);
		if (transform.position.y < -screenBounds.y - 10)
		{
			Destroy(this.gameObject);
		}
	}

	private void OnMouseDown()
	{
		//Debug.Log("touch fuel)");
		Destroy(this.gameObject);
		FindObjectOfType<FuelBar>().takeAmount(5);
	}
}
