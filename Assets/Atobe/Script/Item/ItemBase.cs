using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// アイテムの基底クラス
/// </summary>

public abstract class ItemBase : MonoBehaviour
{
    public abstract void Activate();

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            Debug.Log("Hit");
            Activate();
        }
    }

    protected void Destroy() => Destroy(gameObject);
}
