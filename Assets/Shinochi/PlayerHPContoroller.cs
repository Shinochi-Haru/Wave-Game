using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHPContoroller : MonoBehaviour
{
    [SerializeField] GameObject effectPrefab2;
    [SerializeField] int objectHP;
    private GameObject[] heartArray = new GameObject[2];
    private int heartCount;
    void Start()
    {
        heartCount = 3;
    }

    void Update()
    {
        
    }
}
