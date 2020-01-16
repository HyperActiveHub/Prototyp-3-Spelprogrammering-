using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoundsScript : MonoBehaviour
{
    GameObject ball;
    private void Start()
    {
        ball = Resources.Load("Prefabs/Ball") as GameObject;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        Destroy(collision.gameObject);

        if (collision.GetComponent<BallScript>())
        {
            var balls = FindObjectsOfType<BallScript>();

            if (balls.Length == 1)
            {
                //remove one life from player
                var b = Instantiate(ball, Vector3.zero, Quaternion.identity);
                b.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            }
        }
    }
}
