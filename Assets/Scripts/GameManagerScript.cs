using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerScript : MonoBehaviour
{
    public static GameManagerScript instance;

    public List<GameObject> powerUps = new List<GameObject>();
    public static string horizontalAxis = "Horizontal", jumpAxis = "Jump";

    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
           
    }

    void Update()
    {
        
    }
}
