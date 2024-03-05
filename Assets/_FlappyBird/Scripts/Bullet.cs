using System;
using System.Collections;
using System.Collections.Generic;
using GameTool;
using UnityEngine;

public class Bullet : BasePooling
{
    private float speed = 10f;
    private Rigidbody2D rb;
   
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        rb.velocity = new Vector2(speed, 0);
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Block"))
        {
            var block = other.gameObject.GetComponent<Block>();
            block.TakeDamage(1);
           
            gameObject.SetActive(false);
        }
    }
}
