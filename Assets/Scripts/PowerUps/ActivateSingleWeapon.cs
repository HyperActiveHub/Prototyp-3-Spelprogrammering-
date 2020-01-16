using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateSingleWeapon : ActivateWeapons
{
    protected override void SpawnShots()
    {
        Vector3 pos = new Vector2(paddle.transform.position.x, paddle.transform.position.y) + shotOffset;

        Instantiate(shotPrefab, pos, Quaternion.identity);
    }
}
