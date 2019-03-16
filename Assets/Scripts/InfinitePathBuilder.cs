using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfinitePathBuilder : MonoBehaviour {

	public Transform racePathSimple;

	private float zAxisPosition =0f;

	// Use this for initialization
	void Start () {
		Instantiate(racePathSimple, 
			new Vector3(-12.18895f, 0.005062461f, 53.03f), 
			racePathSimple.rotation);

		Instantiate(racePathSimple, 
			new Vector3(-12.18895f, 0.005062461f, 57.03f), 
			racePathSimple.rotation);
		Instantiate(racePathSimple, 
			new Vector3(-12.18895f, 0.005062461f, 61.03f), 
			racePathSimple.rotation);
	}
	
	// Update is called once per frame
	void Update () {
		
		if(zAxisPosition < 120)
		{
			Instantiate(racePathSimple, 
				new Vector3(-12.18895f, 0.005062461f, zAxisPosition), 
				racePathSimple.rotation);

			zAxisPosition+=4;
		}
	}
}
