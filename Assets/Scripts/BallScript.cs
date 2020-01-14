using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallScript : MonoBehaviour
{
    Rigidbody2D rb;
    public Vector2 initialForce = new Vector2(0, -1);
    bool started, moving;

    public void StartBall()
    {
        if (!started && !moving)
        {
            started = true;
        }
        else
            Debug.LogError("Tried to start when ball was already moving.");
    }

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    { 
        if(!started && Input.GetAxisRaw("Jump") > 0)
        {
            StartBall();
        }

        if(!moving && started)
        {
            rb.AddForce(initialForce * 500);
            moving = true;
        }
    }

}
