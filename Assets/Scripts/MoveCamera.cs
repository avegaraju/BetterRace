using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCamera : MonoBehaviour {

	public KeyCode MoveLeft;
	public KeyCode MoveRight;
	public KeyCode MoveForward;
	public KeyCode SlowDown;
	private float _horizontalMovement = 0f;
	
	private float defaultSpeed = 8f;
	private float speed = 8f;
	private float rateOfSpeed = 10f;
	private Rigidbody _player;
	
	PlayerController _playerController;

	// Use this for initialization
	void Start () {
		_player = GetComponent<Rigidbody>();
		_playerController = new PlayerController(_player,
													new LeftControl(),
													new RightControl(),
													new ForwardControl(),
													new SlowDownControl());
	}
	
	// Update is called once per frame
	void Update ()
    {
		_playerController.UpdatePlayerVelocity(_horizontalMovement);
		
        GlobalVariables.playerPositionOnZAxis = _player.position.z;
		
        if (Input.GetKeyDown(MoveForward))
        {
			_playerController.MoveForward();
        }

        if (Input.GetKeyUp(MoveForward))
        {
			_playerController.ResetToDefaultSpeed();
        }

        if (Input.GetKeyUp(SlowDown))
        {
			_playerController.ResetToDefaultSpeed();
        }

        if (Input.GetKeyDown(SlowDown))
        {
			_playerController.SlowDown();
        }

        if (Input.GetKeyDown(MoveLeft))
        {
			_horizontalMovement = _playerController.MoveLeft();
			_playerController.UpdatePlayerVelocity(_horizontalMovement);
            StartCoroutine(DelayAction());
			
        }

        if (Input.GetKeyDown(MoveRight))
        {
			_horizontalMovement = _playerController.MoveRight();
			_playerController.UpdatePlayerVelocity(_horizontalMovement);
            StartCoroutine(DelayAction());
        }

        DestroyOutOfViewPathSegments();
    }

    private void DestroyOutOfViewPathSegments()
    {
        DestroyOutOfViewPath();

        if (GlobalVariables.HasCollided)
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

	void DestroyOutOfViewPath()
	{
		var peedkedClone = GlobalVariables.RacePaths.Peek();
		
		if(IsRacePathSegmentOutOfView(peedkedClone.position.z))
		{
			var clone = GlobalVariables.RacePaths.Dequeue();
			Destroy(clone.gameObject);
		}
	}

	bool IsRacePathSegmentOutOfView(float racePathSegmentPosition) 
	{
		return racePathSegmentPosition < GlobalVariables.playerPositionOnZAxis - 50;
	} 

	IEnumerator DelayAction()
	{
		yield return new WaitForSeconds(0.5f);
		_horizontalMovement = 0f;
	}
}
