using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WavesPlayerContact : MonoBehaviour
{
    // あとでコメントインする
    //private void OnTriggerEnter2D(Collider2D collision)
    //{
    //    if (collision.TryGetComponent(out PlayerController player))
    //    {
    //        KidnappedPlayer(player);
    //    }
    //}

    /// <summary>
    /// プレイヤーと波の接触処理
    /// </summary>
    public void KidnappedPlayer(/*PlayerController player*/)
    {
        // プレイヤーを波の子オブジェクトにする。
        // プレイヤーの移動を停止する。
        // 波に攫う演出後,GameOver演出を再生,あるいはGameOverシーンに遷移する。
    }
}
