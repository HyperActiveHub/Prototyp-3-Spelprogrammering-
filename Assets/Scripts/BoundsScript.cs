using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoundsScript : MonoBehaviour
{
    private void OnTriggerExit2D(Collider2D collision)
    {
        Destroy(collision.gameObject);

        if (collision.GetComponent<BallScript>())
        {
            GameManagerScript.LostBall();
        }
    }
}
