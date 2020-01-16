using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerScript : MonoBehaviour
{
    public static GameManagerScript instance;
    static GameObject ball;
    public static string horizontalAxis = "Horizontal", jumpAxis = "Jump";

    public List<GameObject> powerUps = new List<GameObject>();
    public int maxLives = 3;

    static int lives;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        lives = maxLives;
        ball = Resources.Load("Prefabs/Ball") as GameObject;
    }

    void Update()
    {

    }

    public static void BrickDestroyed()
    {
        var bricks = FindObjectsOfType<BrickScript>();
        List<GameObject> inScene = new List<GameObject>();

        foreach (var brick in bricks)
        {
            if(brick.isActiveAndEnabled)
            {
                inScene.Add(brick.gameObject);
            }
        }

        if (inScene.Count == 0 && lives >= 0)
        {
            Debug.Log("You Win!");
            //load next level
        }
    }

    public static void LostBall()
    {
        var balls = FindObjectsOfType<BallScript>();

        if (balls.Length == 1)
        {
            RemoveLife();
            var b = Instantiate(ball, Vector3.zero, Quaternion.identity);
            b.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        }
    }

    static void RemoveLife()
    {
        lives--;
        if (lives < 0)
        {
            Debug.Log("Game Over.");
        }
    }
}
