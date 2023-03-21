using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    private void Awake()
    {
        if (Instance != null)
            Debug.LogError("Multipler GMs in the scene");
        Instance = this;
    }

    [Range(0,1)]
    public float worldSpeed = 0.1f;


    private void FixedUpdate()
    {
        worldSpeed += 0.00001f;
    }

}
