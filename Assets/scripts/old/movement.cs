using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour
{

    public float speed;
    public float jump;
    public Rigidbody2D rb;
    public Joystick joystick;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float movex = joystick.Horizontal * speed;
        rb.velocity = new Vector2(movex,0);

        float movey = joystick.Vertical * jump;
        if (movey >= .5f) rb.velocity=new Vector2(0,movey);

    }
}
