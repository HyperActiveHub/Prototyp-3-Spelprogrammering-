using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteAlways]
public class BrickScript : MonoBehaviour
{
    [SerializeField]
    BrickObject brick = null;

    int health;
    SpriteRenderer sr;
    GameObject powerUp;

    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        health = brick.health;
        sr.sprite = brick.sprite;
        sr.color = brick.color;

        if (Random.Range(0f, 1f) <= brick.dropChance)
            powerUp = GameManagerScript.instance.powerUps[Random.Range(0, GameManagerScript.instance.powerUps.Count)];
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        health--;
        if (health < 1)
        {
            if (powerUp != null)
                Instantiate(powerUp, transform.position, Quaternion.identity);

            Destroy(gameObject);
        }

        sr.color = brick.hitColor;
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        sr.color = brick.color;
    }
}