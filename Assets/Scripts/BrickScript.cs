using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickScript : MonoBehaviour
{
    public BrickObject brickType;
    int health;

    SpriteRenderer sr;
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        health = brickType.health;
    }

    private void Update()
    {
        sr.sprite = brickType.sprite;
        sr.color = brickType.color;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        print("brick hit.");
        health--;   //make sure this only happens once per bounce

        if (health < 1)
        {
            Debug.Log("Brick health reached 0 and was removed.");
            //Destroy(gameObject);
            gameObject.SetActive(false);
        }
    }

}