using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class WaveAnimation : MonoBehaviour
{
    [Tooltip("波が引くまでにかかる時間"), SerializeField]
    private float _wavesPullTime = 1f;
    [Tooltip("波が満ちるまでにかかる時間"), SerializeField]
    private float _wavesPushTime = 1f;
    [Tooltip("波が停止する時間"), SerializeField]
    private float _wavesIdleTime = 10f;

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

    /// <summary> 波が引いた回数をカウントする値 </summary>
    public int WavesPulledCount => _wavesPulledCount;

    private void Start()
    {
        _droper = GetComponent<FlotsamDrop>();
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
                WavesIdle();
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
}