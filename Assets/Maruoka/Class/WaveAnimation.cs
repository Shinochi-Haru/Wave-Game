using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[System.Serializable]
public class WaveAnimation : MonoBehaviour
{
    [Tooltip("波が引くまでにかかる時間"), SerializeField]
    private float _wavesPullTime = 1f;
    [Tooltip("波が満ちるまでにかかる時間"), SerializeField]
    private float _wavesPushTime = 1f;
    [Tooltip("波が停止する時間"), SerializeField]
    private float _wavesIdleTime = 10f;
    [Tooltip("ゲームオーバーシーンに移行するまでの時間"),SerializeField]
    private float _gameoverDelayTime = 0f;

    [Tooltip("アイドルするポジション"), SerializeField]
    private Vector3 _idlePos;
    [Tooltip("波が満ちるポジション"), SerializeField]
    private Vector3 _maxPos;

    [Tooltip("波が引く時のイージング"), SerializeField]
    private Ease _pullEase = default;
    [Tooltip("波が満ちる時のイージング"), SerializeField]
    private Ease _pushEase = default;

    private int _wavesPulledCount = 0;
    /// <summary>
    /// 計測用タイマー
    /// </summary>
    private float _idleTimer = 0f;
    private FlotsamDrop _droper = null;
    private WavesPlayerContact _playerContacter = null;

    /// <summary> 波が引いた回数をカウントする値 </summary>
    public int WavesPulledCount => _wavesPulledCount;

    private void Start()
    {
        _droper = GetComponent<FlotsamDrop>();
        _playerContacter = GetComponent<WavesPlayerContact>();
        // アイドルから開始する
        // アイドル→プッシュ→プル→アイドル
        WavesIdle();
    }

    // 以下三つのメソッドはDOTweenを使用して実装する。
    private void WavesPull()
    {
        // Pullアニメーションを再生、
        // 完了後状態をIdleに遷移しカウントを設定する。
        transform.
            DOMove(_idlePos, _wavesPullTime).
            SetEase(_pullEase).
            SetDelay(0.12f). // ちょっと待って波を引かせる
            OnComplete(() =>
            {
                // 波が引き切った時、プレイヤーを攫っていたら n秒待ってGameOverSceneに遷移する。
                if (_playerContacter.TakeAwayPlayer)
                {
                    StartCoroutine(StartGameOverCoroutine());
                }
                // そうで無ければ通常行動
                 else
                {
                    WavesIdle();
                }
            });
    }
    private void WavesPush()
    {
        // Pushアニメーションを再生、完了後Pullアニメーションを再生する。
        transform.DOMove(_maxPos, _wavesPushTime).
            SetEase(_pushEase).
            OnComplete(() =>
            {
                // 波が満ちた瞬間カウントアップする。
                _wavesPulledCount++;
                // アイテムを全て削除する。
                _droper.ItemDelete();
                // 波が満ちた瞬間ドロップする。
                _droper.Drop();
                WavesPull();
            });
    }
    private void WavesIdle()
    {
        // 次の波までカウントダウンし、
        // カウントが0より小さくなった時、Pushする。
        StartCoroutine(IdleCoroutine());
    }
    IEnumerator IdleCoroutine()
    {
        _idleTimer = 0f;
        // 待つ処理
        while (_idleTimer < _wavesIdleTime)
        {
            _idleTimer += Time.deltaTime;
            yield return null;
        }
        // 完了したら波をプッシュする
        WavesPush();
    }
    IEnumerator StartGameOverCoroutine()
    {
        var timer = 0f;
        // 待つ処理
        while (timer < _gameoverDelayTime)
        {
            timer += Time.deltaTime;
            yield return null;
        }
        // 完了したら波をプッシュする
        SceneManager.LoadScene("GameOver");
    }
}