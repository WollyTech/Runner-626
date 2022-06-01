using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    CharacterController _controller;

    [SerializeField]
    private float _speed = 5.0f;

    [SerializeField]
    private float _gravity = 1.0f;
    private float _yVelocity;
    [SerializeField]
    private bool _jump;
    [SerializeField]
    private float _jumpHeight = 10.0f;

    // Called Immediately
    void Start()
    {
        _controller = GetComponent<CharacterController>();

        if (_controller == null)
        {
            Debug.LogError("Charcater Controller not assigned on Enemy!");
        }
    }

    // Called once per PC FPS
    void Update()
    {
        
    }

    // Called once per 60FPS
    void FixedUpdate()
    {
        Vector3 direction = Vector3.right;
        Vector3 velocity = direction * _speed;

        if (_jump == true)
        {
            _yVelocity = _jumpHeight;
            _jump = false;
        }

        if (_controller.isGrounded == false)
        {
            _yVelocity -= _gravity;
        }

        velocity.y = _yVelocity;

        _controller.Move(velocity * Time.deltaTime);
    }

    public void Stop()
    {
        _speed = 0f;
    }
}