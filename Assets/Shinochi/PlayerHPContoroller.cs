using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHPContoroller : MonoBehaviour
{
    [SerializeField] GameObject effectPrefab2;
    [SerializeField] int objectHP;
    private GameObject[] heartArray = new GameObject[2];
    private int heartCount;
    [SerializeField] int _hp = 3;
    public int Hp { get { return _hp; } set { _hp = value; } }

    public void Damage(int dam)
    {
        Hp -= dam;
    }

}
