using UnityEngine;
using System;
using System.Collections;

public class Flock : MonoBehaviour {
	public float speed=1;

	private Rigidbody rb;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");

        //float moveHorizontalRandom = Random()
        float angle = rb.transform.rotation.eulerAngles.z;
        Vector2 movementAngle = new Vector2(Mathf.Sin(angle), Mathf.Cos(angle))*Time.deltaTime;
		Vector2 movement = new Vector2 (moveHorizontal, moveVertical);

        
		rb.AddForce (movementAngle * speed);
        rb.AddForce(movement * speed);
	}
}