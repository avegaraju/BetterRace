using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalVariables : MonoBehaviour {

	public static bool HasCollided = false;

	public static float DynamicPathGeneratorZAxisPosition = 0f;
	public static float playerPositionOnZAxis =0f;
	public static float TopSpeed = 10f;

	public static float DefaultSpeed = 8f;
	public static Queue<Transform> RacePaths = new Queue<Transform>();
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
