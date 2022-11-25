using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CurrentTurnPresenter : MonoBehaviour
{
    private WaveAnimation _nowTurn = null;
    [SerializeField]
    private Text _turnText = null;
    [SerializeField]
    int _clearTurn;
    int _resultTurn;
    SceneCanger sceneCanger;

    private void Awake()
    {
        _nowTurn = GetComponent<WaveAnimation>();
        if (_turnText == null)
        {
            Debug.LogError("�^�[���\���p�e�L�X�g���A�T�C�����Ă��������I");
        }
    }
    void Start()
    {
        _resultTurn = _clearTurn;
        sceneCanger = GetComponent<SceneCanger>();
    }
    public void UpdateValue()
    {
        _turnText.text = $"�t�F�C�Y {(_nowTurn.WavesPulledCount / 2) + 1}";
        /*if ((_nowTurn.WavesPulledCount / 2) + 1 < _clearTurn)
        {
            _turnText.color = Color.black;
            _turnText.text = $"�t�F�C�Y {(_nowTurn.WavesPulledCount / 2) + 1}";
        }
        else if ((_nowTurn.WavesPulledCount / 2) + 1 == _clearTurn)
        {
            _turnText.color = Color.red;
            _turnText.text = $"�ŏI�t�F�C�Y";
        }*/
        if ((_nowTurn.WavesPulledCount / 2) + 1 > _clearTurn)
        {
            sceneCanger.LoadScene("Result");
        }
    }
}
