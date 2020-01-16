using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddBall : PowerUp
{
    public Vector2 spawnForce = new Vector2(0.75f, 0.75f);

    protected override void OnTriggerEnter2D(Collider2D collision)
    {
        base.OnTriggerEnter2D(collision);

        if (pickedUp)
        {
            GameObject a = Instantiate(Resources.Load("Prefabs/Ball") as GameObject, Vector3.zero, Quaternion.identity);
            int randomSide = Random.Range(-1, 2);   //Left, middle or right.
            a.GetComponent<BallScript>().initialDirection = new Vector2(spawnForce.x * randomSide, spawnForce.y);
            a.GetComponent<BallScript>().StartBall();
            Destroy(gameObject);
        }
    }
}
