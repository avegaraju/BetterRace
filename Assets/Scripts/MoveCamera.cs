using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCamera : MonoBehaviour {

	public KeyCode MoveLeft;
	public KeyCode MoveRight;
	public float horizontalMovement = 0f;

	public string collisionObject = "";

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		GetComponent<Rigidbody>().velocity= new Vector3(horizontalMovement, 
															0, 
															4f * GlobalVariables.zAxisMovement);	

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
