using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraZoom : MonoBehaviour
{
	private Camera cam;
	public float ZoomSpeed;
	public KeyCode ZoomKey;

	// Use this for initialization
	void Start()
	{
		cam = GetComponent<Camera>();
	}

	void FixedUpdate()
	{
		if (Input.GetKey(ZoomKey))
		{
			cam.orthographicSize = Mathf.Lerp(cam.orthographicSize, 4, Time.deltaTime * ZoomSpeed);
		}
		else
		{
			cam.orthographicSize = Mathf.Lerp(cam.orthographicSize, 6, Time.deltaTime * ZoomSpeed);
		}
	}

}
