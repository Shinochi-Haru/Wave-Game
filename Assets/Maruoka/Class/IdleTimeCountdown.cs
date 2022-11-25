using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IdleTimeCountdown : MonoBehaviour
{
    [SerializeField]
    private Text _text;

    private WaveAnimation _waveAnimation;
    void Start()
    {
        _waveAnimation = GetComponent<WaveAnimation>();
    }
    void Update()
    {
        if (Mathf.Abs(_waveAnimation.MaxIdleTime - _waveAnimation.IdleTimer) > 0.1f)
        {
            _text.text = $"{(_waveAnimation.MaxIdleTime - _waveAnimation.IdleTimer).ToString("0.00")}";
        }
        else
        {
            _text.text = $"0.00";
        }
    }
}
