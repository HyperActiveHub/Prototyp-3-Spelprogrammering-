using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotScript : MonoBehaviour
{
    public Vector2 direction = Vector2.up;
    public float speed = 10f;

    Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        rb.position += direction * Time.deltaTime * speed;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);
    }
}
