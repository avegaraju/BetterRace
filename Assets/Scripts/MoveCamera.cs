using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCamera : MonoBehaviour {

	public KeyCode MoveLeft;
	public KeyCode MoveRight;
	public KeyCode MoveForward;
	public KeyCode SlowDown;
	public float horizontalMovement = 0f;
	public float RigidbodyPosition =0f;
	public float GeneratorPosition =0f;

	private float defaultSpeed = 8f;
	private float speed = 8f;
	private float rateOfSpeed = 10f;
	

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		var rigidbody = GetComponent<Rigidbody>();
		rigidbody.velocity= new Vector3(horizontalMovement, 
															0, 
															speed * GlobalVariables.zAxisMovement);	
		
		GlobalVariables.playerPositionOnZAxis = rigidbody.position.z;

		if(Input.GetKeyDown(MoveForward))
		{
			speed = speed + rateOfSpeed;
			StartCoroutine(WaitForHalfASecond());
		}

		if(Input.GetKeyUp(MoveForward))
		{
			speed = defaultSpeed;
			StartCoroutine(WaitForHalfASecond());
		}

		if(Input.GetKeyUp(SlowDown))
		{
			speed = defaultSpeed;
			StartCoroutine(WaitForHalfASecond());
		}

		if(Input.GetKeyDown(SlowDown))
		{
			speed = defaultSpeed/2;
			StartCoroutine(WaitForHalfASecond());
		}

		if(Input.GetKeyDown(MoveLeft))
		{
			horizontalMovement = -2f;
			StartCoroutine(WaitForHalfASecond());
		}

		if(Input.GetKeyDown(MoveRight))
		{
			horizontalMovement = 2f;
			StartCoroutine(WaitForHalfASecond());
			
		}

		DestroyOutOfViewPath(rigidbody.position.z);

		if(GlobalVariables.zAxisMovement == 0)
		{
			DestroyAllRacePathClones();
		}
	}

	void OnBecameInvisible()
	{
		Destroy(gameObject);
	}

	void DestroyAllRacePathClones()
	{
		foreach(var racePathClone in GlobalVariables.RacePaths)
		{
			Destroy(racePathClone.gameObject);	
		}
	}

	void DestroyOutOfViewPath(float rigidBodyPosition)
	{
		RigidbodyPosition = rigidBodyPosition;
		GeneratorPosition = GlobalVariables.zAxisPosition;
		var peedkedClone = GlobalVariables.RacePaths.Peek();
		if(peedkedClone.position.z < rigidBodyPosition - 50)
		{
			var clone = GlobalVariables.RacePaths.Dequeue();
			Destroy(clone.gameObject);
		}
	}
	IEnumerator WaitForHalfASecond()
	{
		yield return new WaitForSeconds(0.5f);
		horizontalMovement = 0f;
	}
}
