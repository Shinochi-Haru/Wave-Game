using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CurrentTurnPresenter : MonoBehaviour
{
    private WaveAnimation _nowTurn = null;
    [SerializeField]
    private Text _turnText = null;
    [SerializeField]
    private int _clearTurn = 3;

    void Start()
    {
        _nowTurn = GetComponent<WaveAnimation>();
        if (_turnText == null)
        {
            Debug.LogError("ターン表示用テキストをアサインしてください！");
        }
    }
    public void UpdateValue()
    {
        _turnText.text = $"{(_nowTurn.WavesPulledCount / 2) + 1}";
        if ((_nowTurn.WavesPulledCount / 2) + 1 > _clearTurn)
        {
            SceneManager.LoadScene("Result");
        }
    }
}
