using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WavesPlayerContact : MonoBehaviour
{
    private bool _takeAwayPlayer = false;
    /// <summary> �v���C���[�𝺂��Ă��邩�ǂ��� </summary>
    public bool TakeAwayPlayer => _takeAwayPlayer;


    // ���ƂŃR�����g�C������
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out PlayerController player))
        {
            KidnappedPlayer(player);
        }
    }

    /// <summary>
    /// �v���C���[�Ɣg�̐ڐG����
    /// </summary>
    public void KidnappedPlayer(PlayerController player)
    {
        _takeAwayPlayer = true;
        // �v���C���[��g�̎q�I�u�W�F�N�g�ɂ���B
        player.transform.SetParent(this.transform);
        // �v���C���[�̈ړ����~����B
        // player.StopMove();
        // �g�ɝ������o��,GameOver���o���Đ�,���邢��GameOver�V�[���ɑJ�ڂ���B
    }
    public void OnGameOver()
    {
        SceneManager.LoadScene("GameOver");
    }

    // Tests
    [SerializeField]
    private GameObject _playerSample;
    public void TestKidnappedPlayer()
    {
        _takeAwayPlayer = true;
        _playerSample.transform.SetParent(this.transform);
    }
}
