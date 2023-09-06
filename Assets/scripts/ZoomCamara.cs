using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoomCamara : MonoBehaviour {

	public float zoomSpeed = 1.0f;
	public float minZoom = 1.0f;
	public float maxZoom = 5.0f;

	private Camera mainCamera;
	// Use this for initialization
	void Start () {
		mainCamera = GetComponent<Camera> ();
	}
	
	// Update is called once per frame
	void Update () {
		float zoom = Input.GetAxis ("Mouse ScrollWheel") * zoomSpeed;

		if(zoom != 0){
			mainCamera.orthographicSize = Mathf.Clamp (mainCamera.orthographicSize - zoom, minZoom, maxZoom);
		}
	}
}
