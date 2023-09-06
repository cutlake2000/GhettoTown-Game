using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Scripting.APIUpdating;

public class TopDownMovement : MonoBehaviour
{
    private TopDownCharacterController topDownCharacterController;
    private new Rigidbody2D rigidbody2D;
    private Vector2 movementDirection = Vector2.zero;

    private void Awake()
    {
        topDownCharacterController = GetComponent<TopDownCharacterController>();
        rigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        topDownCharacterController.OnMoveEvent += Move;
    }

    private void FixedUpdate()
    {
        ApplyMovement(movementDirection);
    }

    private void Move(Vector2 direction)
    {
        movementDirection = direction;
    }

    private void ApplyMovement(Vector2 direction)
    {
        direction *= 5;
        rigidbody2D.velocity = direction;
    }
}
