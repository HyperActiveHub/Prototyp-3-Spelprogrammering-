using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateSingleWeapon : ActivateWeapons
{
    protected override void SpawnShots()
    {
        Vector3 pos = new Vector3(paddle.transform.position.x, paddle.transform.position.y + 1f);

        Instantiate(shotPrefab, pos, Quaternion.identity);
    }
}
