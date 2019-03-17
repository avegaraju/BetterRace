using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalVariables : MonoBehaviour {

	public static float zAxisMovement =1;
	public static float zAxisPosition =0f;

	public static float playerPositionOnZAxis =0f;
	public static Queue<Transform> RacePaths = new Queue<Transform>();
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
