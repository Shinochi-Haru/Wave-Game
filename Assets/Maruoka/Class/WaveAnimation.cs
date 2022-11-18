using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class WaveAnimation
{
    [Tooltip("�g�������܂łɂ����鎞��"), SerializeField]
    private float _wavesPullTime = 1f;
    [Tooltip("�g��������܂łɂ����鎞��"), SerializeField]
    private float _wavesPushTime = 1f;
    [Tooltip("�g����~���鎞��"), SerializeField]
    private float _wavesIdleTime = 10f;

    [Tooltip("�A�C�h������|�W�V����"), SerializeField]
    private Vector3 _idlePos;
    [Tooltip("�g��������|�W�V����"), SerializeField]
    private Vector3 _pushPos;

    private int _wavesPulledCount = 0;

    /// <summary> �g���������񐔂��J�E���g����l </summary>
    public int WavesPulledCount => _wavesPulledCount;

    public void Enter()
    {
        WavesIdle();
    }

    // �ȉ��O�̃��\�b�h��DOTween���g�p���Ď�������B
    private void WavesPull()
    {
        // Pull�A�j���[�V�������Đ��A
        // �������Ԃ�Idle�ɑJ�ڂ��J�E���g��ݒ肷��B
    }
    private void WavesPush()
    {
        // Push�A�j���[�V�������Đ��A������Pull�A�j���[�V�������Đ�����B
    }
    private void WavesIdle()
    {
        // ���̔g�܂ŃJ�E���g�_�E�����A
        // �J�E���g��0��菬�����Ȃ������APush����B
    }
}