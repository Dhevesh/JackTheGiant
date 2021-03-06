﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Movement Variables")]
    [SerializeField] private float maxSpeed = 8f;
    [SerializeField] private float maxVelocity = 4f;

    private Rigidbody2D rigidbody2D;
    private Animator animator;

    private float minX;
    private float maxX;
    
    void Awake()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    void Start()
    {
        SetPlayerBounds();
    }

    void Update()
    {
        if (transform.position.x < minX)
        {
            Vector3 temp = transform.position;
            temp.x = minX;
            transform.position = temp;
        }else if(transform.position.x > maxX)
        {
            Vector3 temp = transform.position;
            temp.x = maxX;
            transform.position = temp;
        }
    }

    void FixedUpdate()
    {
        PlayerMovement();
    }

    void PlayerMovement()
    {
        float forceX = 0;
        float moveVelocity = Mathf.Abs(rigidbody2D.velocity.x);

        float h = Input.GetAxisRaw("Horizontal");

        Vector3 playerFacing = transform.localScale;

        if (h > 0)
        {
            if (moveVelocity < maxVelocity)
            {
                forceX = maxSpeed;
                animator.SetBool("Walk",true);
                playerFacing.x = 1;
                transform.localScale = playerFacing;
            }
        }
        else if (h < 0)
        {
            if (moveVelocity < maxVelocity)
            {
                forceX = -maxSpeed;
                animator.SetBool("Walk", true);
                playerFacing.x = -1;
                transform.localScale = playerFacing;
            }
        }
        else
        {
            animator.SetBool("Walk", false);
        }

        rigidbody2D.AddForce(new Vector2(forceX, transform.localPosition.y));
    }

    void SetPlayerBounds()
    {
        Vector3 bounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0));

        maxX = bounds.x;
        minX = -bounds.x;
    }
}
