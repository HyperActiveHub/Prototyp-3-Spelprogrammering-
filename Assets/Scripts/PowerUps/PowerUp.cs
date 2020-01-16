using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    public float fallingSpeed = 3;

    protected bool pickedUp;
    protected bool falling = true;
    protected SpriteRenderer sr;

    protected virtual void Start()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    protected virtual void Update()
    {
        float screenBottom = Camera.main.ScreenToWorldPoint(new Vector3(0, 0)).y;
        float powerUpTop = transform.position.y + sr.sprite.bounds.max.y;

        if (powerUpTop < screenBottom)
        {
            Destroy(gameObject);
        }
        else if(falling)
        {
            transform.position += Vector3.down * Time.deltaTime * fallingSpeed;
        }
    }

    protected virtual void OnTriggerEnter2D(Collider2D collision)
    {
        var a = collision.gameObject.GetComponent<PaddleScript>();
        if (a != null)
        {
            pickedUp = true;
            falling = false;
            sr.enabled = false;
            GetComponent<Collider2D>().enabled = false;
        }
    }
}