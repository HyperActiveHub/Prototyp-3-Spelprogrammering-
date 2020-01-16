using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateWeapons : PowerUp
{
    static ActivateWeapons instance;

    public float weaponTime = 10f;
    public float fireRate = 0.35f;

    bool startTimer, canShoot;
    float fireTimer;
    float timer;
    protected GameObject paddle;
    protected GameObject shotPrefab = null;

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

                if (fireTimer >= fireRate)
                {
                    canShoot = true;
                }
                else
                    fireTimer += Time.deltaTime;

                if (Input.GetAxisRaw("Jump") != 0)
                {
                    if (canShoot)
                    {
                        SpawnShots();
                        fireTimer = 0;
                        canShoot = false;
                    }
                }
            }
            else
            {
                Destroy(gameObject);
            }
        }

    }

    protected virtual void SpawnShots()
    {
        Vector3 posR = new Vector3(paddle.transform.position.x + 1, paddle.transform.position.y + 1f);
        Vector3 posL = new Vector3(paddle.transform.position.x - 1, paddle.transform.position.y + 1f);

        Instantiate(shotPrefab, posR, Quaternion.identity);
        Instantiate(shotPrefab, posL, Quaternion.identity);
    }

    protected override void OnTriggerEnter2D(Collider2D collision)
    {
        base.OnTriggerEnter2D(collision);

        if (pickedUp)
        {
            //paddle = collision.GetComponent<PaddleScript>();  doesnt work?? loses reference somehow..
            pickedUp = false;
            startTimer = true;

            if (instance == null)
            {
                instance = this;
            }
            else
            {
                Destroy(instance.gameObject);
                instance = this;
            }
        }
    }
}
