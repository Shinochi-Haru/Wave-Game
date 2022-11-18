using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class WaveAnimation
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
    private Vector3 _pushPos;

    private int _wavesPulledCount = 0;

    /// <summary> 波が引いた回数をカウントする値 </summary>
    public int WavesPulledCount => _wavesPulledCount;

    public void Enter()
    {
        WavesIdle();
    }

    // 以下三つのメソッドはDOTweenを使用して実装する。
    private void WavesPull()
    {
        // Pullアニメーションを再生、
        // 完了後状態をIdleに遷移しカウントを設定する。
    }
    private void WavesPush()
    {
        // Pushアニメーションを再生、完了後Pullアニメーションを再生する。
    }
    private void WavesIdle()
    {
        // 次の波までカウントダウンし、
        // カウントが0より小さくなった時、Pushする。
    }
}