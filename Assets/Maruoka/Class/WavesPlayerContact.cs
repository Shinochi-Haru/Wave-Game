using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WavesPlayerContact : MonoBehaviour
{
    private bool _takeAwayPlayer = false;
    /// <summary> プレイヤーを攫っているかどうか </summary>
    public bool TakeAwayPlayer => _takeAwayPlayer;


    // あとでコメントインする
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out PlayerController player))
        {
            KidnappedPlayer(player);
        }
    }

    /// <summary>
    /// プレイヤーと波の接触処理
    /// </summary>
    public void KidnappedPlayer(PlayerController player)
    {
        _takeAwayPlayer = true;
        // プレイヤーを波の子オブジェクトにする。
        player.transform.SetParent(this.transform);
        // プレイヤーの移動を停止する。
        // player.StopMove();
        // 波に攫う演出後,GameOver演出を再生,あるいはGameOverシーンに遷移する。
    }
    public void OnGameOver()
    {
        SceneManager.LoadScene("GameOver");
    }

    // Tests
    [SerializeField]
    private GameObject _playerSample;
    public void TestKidnappedPlayer()
    {
        _takeAwayPlayer = true;
        _playerSample.transform.SetParent(this.transform);
    }
}
