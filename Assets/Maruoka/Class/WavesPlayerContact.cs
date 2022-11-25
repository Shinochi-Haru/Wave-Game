using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WavesPlayerContact : MonoBehaviour
{
    private bool _takeAwayPlayer = false;
    /// <summary> �v���C���[�𝺂��Ă��邩�ǂ��� </summary>
    public bool TakeAwayPlayer => _takeAwayPlayer;

    [SerializeField]
    private GameObject _playerDeathPrefab;


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
        //player.transform.SetParent(this.transform);
        //// �v���C���[�̈ړ����~����B
        //player.IsMove = false;
        var a = Instantiate(_playerDeathPrefab, player.transform.position, Quaternion.identity, this.transform);
        var b = a.transform;
        b.localScale /= 3f;
        a.transform.localScale = b.localScale;
        GameObject.Destroy(player.gameObject);
    }
    public void OnGameOver()
    {
        SceneManager.LoadScene("GameOver");
    }
}
