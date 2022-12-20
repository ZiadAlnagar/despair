using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{

	public Transform target;
	public float speed;


	public float minX, minY, maxX, maxY;


	// Use this for initialization
	void Start()
	{

	}

	// Update is called once per frame
	void Update()
	{

	}


	void FixedUpdate()
	{
		if (target != null)
		{
			Vector2 newCamPosition = Vector2.Lerp(transform.position, target.position, Time.deltaTime * speed);
			float clampX = Mathf.Clamp(newCamPosition.x, minX, maxX);
			float clampY = Mathf.Clamp(newCamPosition.y, minY, maxY);
			transform.position = new Vector3(clampX, clampY, -10f);
		}
	}

}
