using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallScript : MonoBehaviour
{
    public Vector2 initialDirection = new Vector2(0, -1);
    public float speed = 500;

    bool started, moving;
    Rigidbody2D rb;

    public void StartBall()
    {
        if (!started && !moving)
        {
            started = true;
        }
    }

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    { 
        if(!started && Input.GetAxisRaw(GameManagerScript.jumpAxis) > 0)
        {
            StartBall();
        }

        if(!moving && started)
        {
            rb.AddForce(initialDirection * speed);
            moving = true;
        }
    }

}
