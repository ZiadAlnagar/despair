using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraZoomScroll : MonoBehaviour
{

	private Camera cam;

	public float TargetZoom = 3;

	private float scrollData;

	public float ZoomSpeed = 2;



	// Use this for initialization
	void Start()
	{
		cam = GetComponent<Camera>();
		TargetZoom = cam.orthographicSize;
	}

	// Update is called once per frame
	void Update()
	{
		scrollData = Input.GetAxis("Mouse ScrollWheel");
		TargetZoom = TargetZoom - scrollData;

		TargetZoom = Mathf.Clamp(TargetZoom, 3, 4.170861f);
		cam.orthographicSize = Mathf.Lerp(cam.orthographicSize, TargetZoom, Time.deltaTime * ZoomSpeed);
	}
}
