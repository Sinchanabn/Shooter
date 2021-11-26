﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D rb;
    public float speed;
    float inputX;
    float inputY;
    

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
         inputX = Input.GetAxis("Horizontal");
         inputY = Input.GetAxis("Vertical");
    }
    void FixedUpdate()
    {
        rb.velocity = new Vector2(inputX * speed, rb.velocity.y);
        
    }
}