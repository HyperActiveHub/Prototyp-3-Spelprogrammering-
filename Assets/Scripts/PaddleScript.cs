using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleScript : MonoBehaviour
{
    Rigidbody2D rb;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        float h = Input.GetAxisRaw("Horizontal");
        //transform.position += new Vector3(h * Time.deltaTime * 10, 0);
        rb.position += (new Vector2(h * Time.deltaTime * 10, 0));
    }
}
