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
        if(CanMove(h))
        rb.position += new Vector2(movement, 0);
    }

    bool CanMove(float h)
    {
        if(h > 0)
        {
            if(transform.position.x + GetComponent<SpriteRenderer>().bounds.extents.x < Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, 0)).x - 1.15f)
            {
                return true;
            }


        }
        else if(h < 0)
        {
            if (transform.position.x - GetComponent<SpriteRenderer>().bounds.extents.x > Camera.main.ScreenToWorldPoint(new Vector2(0, 0)).x + 1.15f)
            {
                return true;
            }

        }

        return false;
    }
}
