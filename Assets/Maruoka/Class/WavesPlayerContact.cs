using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WavesPlayerContact : MonoBehaviour
{
    private bool _takeAwayPlayer = false;
    /// <summary> プレイヤーを攫っているかどうか </summary>
    public bool TakeAwayPlayer => _takeAwayPlayer;

    [SerializeField]
    private GameObject _playerDeathPrefab;


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
        //player.transform.SetParent(this.transform);
        //// プレイヤーの移動を停止する。
        //player.IsMove = false;
        var a = Instantiate(_playerDeathPrefab, player.transform.position, Quaternion.identity, this.transform);
        var b = a.transform;
        b.localScale /= 3f;
        a.transform.localScale = b.localScale;
        GameObject.Destroy(player.gameObject);
    }
    public void OnGameOver()
    {
        SceneManager.LoadScene("GameOver");
    }
}
