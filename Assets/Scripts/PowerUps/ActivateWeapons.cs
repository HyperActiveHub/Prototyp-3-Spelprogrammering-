using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateWeapons : PowerUp
{
    static ActivateWeapons instance;

    public float weaponTime = 10f;
    public float fireRate = 0.35f;
    public Vector2 shotOffset;
    public GameObject shotPrefab = null;

    bool startTimer, canShoot;
    float fireTimer;
    float timer;
    protected GameObject paddle;


    protected override void Start()
    {
        base.Start();
        fireTimer = fireRate;
        paddle = GameObject.Find("Paddle");
    }

    protected override void Update()
    {
        base.Update();

        if (startTimer)
        {
            if (AreWeaponsActive())
            {
                FireRate();

                if (Input.GetAxisRaw(GameManagerScript.jumpAxis) != 0)
                {
                    Shoot();
                }
            }
            else
                Destroy(gameObject);
        }
    }

    bool AreWeaponsActive()
    {
        timer += Time.deltaTime;
        return (timer < weaponTime);
    }

    private void Shoot()
    {
        if (canShoot)
        {
            SpawnShots();
            fireTimer = 0;
            canShoot = false;
        }
    }

    private void FireRate()
    {
        if (fireTimer >= fireRate)
        {
            canShoot = true;
        }
        else
            fireTimer += Time.deltaTime;
    }

    protected virtual void SpawnShots()
    {
        Vector3 posR = new Vector2(paddle.transform.position.x, paddle.transform.position.y) + shotOffset;
        Vector3 posL = new Vector2(paddle.transform.position.x, paddle.transform.position.y) + new Vector2(-shotOffset.x, shotOffset.y);

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
