using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDestroyer : MonoBehaviour {

	public GameObject explosion;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter(Collider collider)
	{
		if(collider.tag == "Player")
		{
			Instantiate(explosion, transform.position, transform.rotation);
			Destroy(collider.gameObject, 0.5f);
			GlobalVariables.zAxisMovement =0;
		}
	}
}
