using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveFalse : MonoBehaviour
{
    [SerializeField] GameObject _topGun;

    public void FalseActive()
    {
        _topGun.SetActive(false);
    }
}
