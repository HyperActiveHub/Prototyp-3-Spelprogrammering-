using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddBall : PowerUp
{

    protected override void OnTriggerEnter2D(Collider2D collision)
    {
        base.OnTriggerEnter2D(collision);

        if (pickedUp)
        {
            GameObject a = Instantiate(Resources.Load("Prefabs/Ball") as GameObject, Vector3.zero, Quaternion.identity);
            a.GetComponent<BallScript>().initialForce = new Vector2(0.75f * Random.Range(-1, 2), 0.75f);
            a.GetComponent<BallScript>().StartBall();
            Destroy(gameObject);
        }
    }
}
