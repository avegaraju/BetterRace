using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class PlayerController
{
    Rigidbody _player;
    LeftControl _leftControl;
    RightControl _rightControl;
    ForwardControl _forwardControl;
    SlowDownControl _slowDownControl;
    //private float _horizontalMovement = 0f;
    private float _defaultSpeed = 8f;

    public PlayerController(Rigidbody player,
                            LeftControl leftControl,
                            RightControl rightControl,
                            ForwardControl forwardControl,
                            SlowDownControl slowDownControl)
    {
        _player = player;
        _leftControl = leftControl;
        _rightControl = rightControl;
        _forwardControl = forwardControl;
        _slowDownControl = slowDownControl;
    }

    public float MoveLeft()
    {
        return _leftControl.Move();
    }

    public float MoveRight()
    {
        return _rightControl.Move();
        
    }

    public void ResetToDefaultSpeed()
    {
        _defaultSpeed = GlobalVariables.DefaultSpeed;
    }

    public void MoveForward()
    {
        _defaultSpeed = _forwardControl.Move(_defaultSpeed);
    }

    public void SlowDown()
    {
        _defaultSpeed = _slowDownControl.Move(_defaultSpeed);
    }

    public void UpdatePlayerVelocity(float horizontalMovement)
    {
        if(GlobalVariables.HasCollided)
            _player.velocity = new Vector3(horizontalMovement, 0, 0);
        else
            _player.velocity = new Vector3(horizontalMovement, 0, _defaultSpeed);
    }
}