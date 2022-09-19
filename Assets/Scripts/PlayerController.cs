using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float _torqueAmount = 10f;
    [SerializeField] float _baseSpeed = 20f;
    [SerializeField] float _boostSpeed = 30f;

    Rigidbody2D _rb2d;
    SurfaceEffector2D _surfaceEffector2D;
    bool canMove = true;

    // Start is called before the first frame update
    void Start()
    {
        _rb2d = GetComponent<Rigidbody2D>();
        _surfaceEffector2D = FindObjectOfType<SurfaceEffector2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (canMove)
            RotatePlayer();
            RespondToBoost();
    }

    public void DisableControls()
    {
        canMove = false;
    }

    private void RespondToBoost()
    {
        if (Input.GetKey(KeyCode.UpArrow))
            _surfaceEffector2D.speed = _boostSpeed;
        else
            _surfaceEffector2D.speed = _baseSpeed;
    }

    private void RotatePlayer()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
            _rb2d.AddTorque(_torqueAmount);
        else if (Input.GetKey(KeyCode.RightArrow))
            _rb2d.AddTorque(-_torqueAmount);
    }
}
