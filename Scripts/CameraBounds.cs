using UnityEngine;
using System;
using System.Collections;

public class CameraBounds : MonoBehaviour {

	public GameObject Player;
    private Rigidbody rb;
    Camera camera;
    Rect cameraRect;

	// Use this for initialization
	void Start () {
        Player = GameObject.FindWithTag("Player");
        rb = GetComponent<Rigidbody>();
        camera = Camera.main;
        Debug.Log("Yo Camera Bound");

        var bottomLeft = camera.ScreenToWorldPoint(Vector3.zero);
        var topRight = camera.ScreenToWorldPoint(new Vector3(
            camera.pixelWidth, camera.pixelHeight));
        cameraRect = new Rect(
            bottomLeft.x,
            bottomLeft.y,
            topRight.x - bottomLeft.x,
            topRight.y - bottomLeft.y);
    }
	
	// Update is called once per frame
	void FixedUpdate () {

        CameraRestriction();
    }

	void  CameraRestriction ()
	{
        if (transform.position.x < cameraRect.xMin)
        {
            transform.position = new Vector2(cameraRect.xMax,transform.position.y);
        }
        else if(transform.position.x > cameraRect.xMax)
        {
            transform.position = new Vector2(cameraRect.xMin, transform.position.y);
        }
        else if (transform.position.y < cameraRect.yMin)
        {
            transform.position = new Vector2(transform.position.x, cameraRect.yMax);
        }
        else if (transform.position.y > cameraRect.yMax)
        {
            transform.position = new Vector2(transform.position.x, cameraRect.yMin);
        }

        //Code For clamping not needed Right Now
        //transform.position = new Vector2(
        //Mathf.Clamp(transform.position.x, cameraRect.xMin, cameraRect.xMax),
        //Mathf.Clamp(transform.position.y, cameraRect.yMin, cameraRect.yMax));
    }
}

