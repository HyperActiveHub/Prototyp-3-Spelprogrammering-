using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateWeapons : PowerUp
{
    static ActivateWeapons instance;
    static float timer;
    static bool resetTimer;

    public float weaponTime = 10f;
    public float fireRate = 0.35f;

    GameObject shotPrefab = null;
    bool startTimer;
    float fireTimer;
    GameObject paddle;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
            timer = 0;
        }
        else
        {
            resetTimer = true;
        }
    }

    protected override void Start()
    {
        base.Start();
        fireTimer = fireRate;
        shotPrefab = Resources.Load<GameObject>("Prefabs/Shot");
        paddle = GameObject.Find("Paddle");
    }

    protected override void Update()
    {
        base.Update();

        if (startTimer)
        {
            if (timer < weaponTime)
            {
                timer += Time.deltaTime;
                print("timer: " + timer);

                if (Input.GetAxisRaw("Jump") != 0)
                {
                    if (fireTimer >= fireRate)
                    {
                        Vector3 posR = new Vector3(paddle.transform.position.x + 1, paddle.transform.position.y + 1f);
                        Vector3 posL = new Vector3(paddle.transform.position.x - 1, paddle.transform.position.y + 1f);

                        Instantiate(shotPrefab, posR, Quaternion.identity);
                        Instantiate(shotPrefab, posL, Quaternion.identity);
                        fireTimer = 0;
                    }
                    else
                        fireTimer += Time.deltaTime;
                }
            }
            else
            {
                //disable weapons
                Destroy(gameObject);
            }
        }

    }

    protected override void OnTriggerEnter2D(Collider2D collision)
    {
        base.OnTriggerEnter2D(collision);

        if (pickedUp)
        {
            //enable weapons
            startTimer = true;
            //paddle = collision.GetComponent<PaddleScript>();  doesnt work?? loses reference somehow..

            if (resetTimer && instance != this)
            {
                timer = 0;
                Destroy(gameObject);
                print("timer reset.");
            }
        }
    }
}
