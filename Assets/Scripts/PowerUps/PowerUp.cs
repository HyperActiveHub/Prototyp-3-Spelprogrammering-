using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    protected bool pickedUp;
    protected bool falling = true;
    protected SpriteRenderer sr;

    protected virtual void Start()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    protected virtual void Update()
    {
        if (transform.position.y + sr.sprite.bounds.max.y < Camera.main.ScreenToWorldPoint(new Vector3(0, 0)).y)
        {
            Destroy(gameObject);
        }
        else if(falling)
        {
            transform.position += new Vector3(0, -1 * Time.deltaTime * 3);
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