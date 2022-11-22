using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[System.Serializable]
public class WaveAnimation : MonoBehaviour
{
    [Tooltip("�g�������܂łɂ����鎞��"), SerializeField]
    private float _wavesPullTime = 1f;
    [Tooltip("�g��������܂łɂ����鎞��"), SerializeField]
    private float _wavesPushTime = 1f;
    [Tooltip("�g����~���鎞��"), SerializeField]
    private float _wavesIdleTime = 10f;
    [Tooltip("�Q�[���I�[�o�[�V�[���Ɉڍs����܂ł̎���"),SerializeField]
    private float _gameoverDelayTime = 0f;

    [Tooltip("�A�C�h������|�W�V����"), SerializeField]
    private Vector3 _idlePos;
    [Tooltip("�g��������|�W�V����"), SerializeField]
    private Vector3 _maxPos;

    [Tooltip("�g���������̃C�[�W���O"), SerializeField]
    private Ease _pullEase = default;
    [Tooltip("�g�������鎞�̃C�[�W���O"), SerializeField]
    private Ease _pushEase = default;

    private int _wavesPulledCount = 0;
    /// <summary>
    /// �v���p�^�C�}�[
    /// </summary>
    private float _idleTimer = 0f;
    private FlotsamDrop _droper = null;
    private WavesPlayerContact _playerContacter = null;

    /// <summary> �g���������񐔂��J�E���g����l </summary>
    public int WavesPulledCount => _wavesPulledCount;

    private void Start()
    {
        _droper = GetComponent<FlotsamDrop>();
        _playerContacter = GetComponent<WavesPlayerContact>();
        // �A�C�h������J�n����
        // �A�C�h�����v�b�V�����v�����A�C�h��
        WavesIdle();
    }

    // �ȉ��O�̃��\�b�h��DOTween���g�p���Ď�������B
    private void WavesPull()
    {
        // Pull�A�j���[�V�������Đ��A
        // �������Ԃ�Idle�ɑJ�ڂ��J�E���g��ݒ肷��B
        transform.
            DOMove(_idlePos, _wavesPullTime).
            SetEase(_pullEase).
            SetDelay(0.12f). // ������Ƒ҂��Ĕg����������
            OnComplete(() =>
            {
                // �g�������؂������A�v���C���[�𝺂��Ă����� n�b�҂���GameOverScene�ɑJ�ڂ���B
                if (_playerContacter.TakeAwayPlayer)
                {
                    StartCoroutine(StartGameOverCoroutine());
                }
                // �����Ŗ�����Βʏ�s��
                 else
                {
                    WavesIdle();
                }
            });
    }
    private void WavesPush()
    {
        // Push�A�j���[�V�������Đ��A������Pull�A�j���[�V�������Đ�����B
        transform.DOMove(_maxPos, _wavesPushTime).
            SetEase(_pushEase).
            OnComplete(() =>
            {
                // �g���������u�ԃJ�E���g�A�b�v����B
                _wavesPulledCount++;
                // �A�C�e����S�č폜����B
                _droper.ItemDelete();
                // �g���������u�ԃh���b�v����B
                _droper.Drop();
                WavesPull();
            });
    }
    private void WavesIdle()
    {
        // ���̔g�܂ŃJ�E���g�_�E�����A
        // �J�E���g��0��菬�����Ȃ������APush����B
        StartCoroutine(IdleCoroutine());
    }
    IEnumerator IdleCoroutine()
    {
        _idleTimer = 0f;
        // �҂���
        while (_idleTimer < _wavesIdleTime)
        {
            _idleTimer += Time.deltaTime;
            yield return null;
        }
        // ����������g���v�b�V������
        WavesPush();
    }
    IEnumerator StartGameOverCoroutine()
    {
        var timer = 0f;
        // �҂���
        while (timer < _gameoverDelayTime)
        {
            timer += Time.deltaTime;
            yield return null;
        }
        // ����������g���v�b�V������
        SceneManager.LoadScene("GameOver");
    }
}