using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CurrentTurnPresenter : MonoBehaviour
{
    private WaveAnimation _nowTurn = null;
    [SerializeField]
    private Text _turnText = null;

    private void Awake()
    {
        _nowTurn = GetComponent<WaveAnimation>();
        if (_turnText == null)
        {
            Debug.LogError("ターン表示用テキストをアサインしてください！");
        }
    }
    void Start()
    {

    }
    public void UpdateValue()
    {
        _turnText.text = $"{(_nowTurn.WavesPulledCount / 2) + 1}";
    }
}
