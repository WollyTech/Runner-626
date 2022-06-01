using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    #region Variables
    #region Components
    CharacterController _controller;
    #endregion

    #region Movement
    [SerializeField]
    private float _speed = 3;

    #region Jump/Aerial
    [SerializeField]
    private float _gravity = 1;
    private bool _canJump;
    private bool _jump;
    [SerializeField]
    private float _jumpForce = 2.0f;
    private float _yVelocity;
    #endregion

    #endregion

    #endregion

    //On start of scene
    void Start()
    {
        #region Getting Components
        _controller = GetComponent<CharacterController>();
        #endregion

        #region Null Checking
        if (_controller == null)
        {
            Debug.LogError("Character Controller is not found on Player!");
        }
        #endregion
    }

    //Runs based on system FPS
    void Update()
    {
        //check for input here
        if (Input.GetKeyDown(KeyCode.Space) && _canJump == true)
        {
            _jump = true;
        }

    }

    //Update for Physics at 60FPS
    void FixedUpdate()
    {
        #region Player Movement

        #region Direction & Velocity
        Vector3 direction;
        direction = Vector3.right;

        Vector3 velocity = direction * _speed;
        #endregion

        #region Jump/Aerial physics
        if (_controller.isGrounded == true)
        {
            _canJump = true;
            if(_jump == true)
            {
                _yVelocity = _jumpForce;
                _jump = false;
            }
        }
        else
        {
            _canJump = false;
            _yVelocity -= _gravity;
        }
        velocity.y = _yVelocity;
        #endregion

        _controller.Move(velocity * Time.deltaTime);
        #endregion
    }

    public void Stop()
    {
        _speed = 0f;
    }
}