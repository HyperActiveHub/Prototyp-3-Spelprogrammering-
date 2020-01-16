using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleScript : MonoBehaviour
{
    public float moveSpeed = 10f;

    Rigidbody2D rb;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        float h = Input.GetAxisRaw(GameManagerScript.horizontalAxis);
        float movement = h * Time.deltaTime * moveSpeed;
        rb.position += new Vector2(movement, 0);
    }
}
