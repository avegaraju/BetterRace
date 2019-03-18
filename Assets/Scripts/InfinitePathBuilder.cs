using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfinitePathBuilder : MonoBehaviour {

	public Transform racePathSimple;

	public float zAxisPositionValue = 0f;

	// Use this for initialization
	void Start () {
		var firstPathSegementClone = Instantiate(racePathSimple, 
										new Vector3(-12.18895f, 0.005062461f, 53.03f), 
										racePathSimple.rotation);

		var secondPathSegmentClone = Instantiate(racePathSimple, 
										new Vector3(-12.18895f, 0.005062461f, 57.03f), 
										racePathSimple.rotation);
		var thirdPathSegmentClone = Instantiate(racePathSimple, 
										new Vector3(-12.18895f, 0.005062461f, 61.03f), 
										racePathSimple.rotation);
		
		GlobalVariables.RacePaths.Enqueue(firstPathSegementClone);
		GlobalVariables.RacePaths.Enqueue(secondPathSegmentClone);
		GlobalVariables.RacePaths.Enqueue(thirdPathSegmentClone);
	}
	
	// Update is called once per frame
	void Update () 
	{
		 if(!GlobalVariables.HasCollided
		 && GlobalVariables.DynamicPathGeneratorZAxisPosition - GlobalVariables.playerPositionOnZAxis < 100)
		 {
			var clone = Instantiate(racePathSimple, 
						new Vector3(-12.18895f, 0.005062461f, GlobalVariables.DynamicPathGeneratorZAxisPosition), 
						racePathSimple.rotation);
			
			GlobalVariables.RacePaths.Enqueue(clone);

			GlobalVariables.DynamicPathGeneratorZAxisPosition+=4;
		}
	}
}
