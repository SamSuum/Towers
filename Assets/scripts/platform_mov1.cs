﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class platform_mov1 : MonoBehaviour
{
    //Rigidbody2D rb;
    [SerializeField] private float speed;
    


    // Start is called before the first frame update
    void Start()
    {
        // rb=GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(0, speed, 0);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "point")
        {
             speed = -speed;
             //Debug.Log(speed);
        }

    }
}