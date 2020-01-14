using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Brick", menuName = "ScriptableObjects/Brick", order = 1)]
public class BrickObject : ScriptableObject
{
    public Sprite sprite;
    //[Min((1))]    not working (bug), fixed in Unity 2020.x
    public int health;
    public Color color;

    private void OnEnable()
    {
        UnityEngine.Assertions.Assert.IsTrue(health > 0, "Health must be larger than 0.");
    }
}
