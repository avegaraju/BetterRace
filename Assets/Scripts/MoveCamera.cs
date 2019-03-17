using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCamera : MonoBehaviour {

	public KeyCode MoveLeft;
	public KeyCode MoveRight;
	public KeyCode MoveForward;
	public KeyCode SlowDown;
	public float horizontalMovement = 0f;

	private float defaultSpeed = 8f;
	private float speed = 8f;
	private float rateOfSpeed = 10f;
	

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		GetComponent<Rigidbody>().velocity= new Vector3(horizontalMovement, 
															0, 
															speed * GlobalVariables.zAxisMovement);	

		if(Input.GetKeyDown(MoveForward))
		{
			speed = speed + rateOfSpeed;
			StartCoroutine(StopSlide());
		}

		if(Input.GetKeyUp(MoveForward))
		{
			speed = defaultSpeed;
			StartCoroutine(StopSlide());
		}

		if(Input.GetKeyUp(SlowDown))
		{
			speed = defaultSpeed;
			StartCoroutine(StopSlide());
		}

		if(Input.GetKeyDown(SlowDown))
		{
			speed = defaultSpeed/2;
			StartCoroutine(StopSlide());
		}

		if(Input.GetKeyDown(MoveLeft))
		{
			horizontalMovement = -2f;
			StartCoroutine(StopSlide());
		}

		if(Input.GetKeyDown(MoveRight))
		{
			horizontalMovement = 2f;
			StartCoroutine(StopSlide());
		}
	}

	IEnumerator StopSlide()
	{
		yield return new WaitForSeconds(0.5f);
		horizontalMovement = 0f;
	}
}
