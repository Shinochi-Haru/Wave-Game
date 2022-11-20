using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// �Y�����h���b�v�N���X
public class FlotsamDrop : MonoBehaviour
{
    [Tooltip("�A�C�e�����h���b�v����G���A����̍��W"), SerializeField]
    private Vector2 _dropAreaTopLeft;
    [Tooltip("�A�C�e�����h���b�v����G���A�E���̍��W"), SerializeField]
    private Vector2 _dropAreaBottomRight;
    [Tooltip("���̕�����"), SerializeField, Range(1, 10)]
    private int _horizontalDivision = 1;
    [Tooltip("�c�̕�����"), SerializeField, Range(1, 10)]
    private int _verticalDivision = 1;
    [Tooltip("1���ɔz�u����A�C�e���̐�"), SerializeField, Range(1, 3)]
    private int _numberToPlaceItem = 1;
    [Tooltip("1���ɔz�u����G�̐�"), SerializeField, Range(1, 3)]
    private int _numberToPlaceEnemy = 1;
    [Tooltip("�Y�����̃A�C�e���v���n�u"), SerializeField]
    private GameObject[] _flotsamItemPrefabs = default;
    [Tooltip("�Y�����̓G�v���n�u"), SerializeField]
    private GameObject[] _flotsamEnemyPrefabs = default;

    private WaveAnimation _waveAnimationer = null;
    private void Start()
    {
        _waveAnimationer = GetComponent<WaveAnimation>();
    }

    public void Drop()
    {
        var overallWidth = (_dropAreaBottomRight.x - _dropAreaTopLeft.x) > 0f ?
            (_dropAreaBottomRight.x - _dropAreaTopLeft.x) :
            -(_dropAreaBottomRight.x - _dropAreaTopLeft.x);
        var oneAreaWidth = overallWidth / (float)_horizontalDivision;

        var overallHeight = (_dropAreaBottomRight.y - _dropAreaTopLeft.y) > 0f ?
            (_dropAreaBottomRight.y - _dropAreaTopLeft.y) :
            -(_dropAreaBottomRight.y - _dropAreaTopLeft.y);
        var oneAreaHeight = overallHeight / (float)_verticalDivision;
        // �w�肳�ꂽ�G���A��n * m�������Ă�����a���Y������z�u����B
        for (int i = 0; i < _verticalDivision; i++)// ���s
        {
            for (int j = 0; j < _horizontalDivision; j++) // ����̋���
            {
                var xPos = UnityEngine.Random.Range(oneAreaWidth * i, oneAreaWidth * (i + 1));
                var yPos = UnityEngine.Random.Range(oneAreaHeight * j, oneAreaHeight * (j + 1));
                var generationPos = new Vector2(xPos, yPos) + new Vector2(_dropAreaTopLeft.x, -_dropAreaTopLeft.y);

                if (_waveAnimationer.WavesPulledCount % 2 == 0)
                {
                    for (int k = 0; k < _numberToPlaceItem; k++) // �A�C�e���𐶐�����
                    {
                        var index = UnityEngine.Random.Range(0, _flotsamItemPrefabs.Length);
                        GameObject.Instantiate(_flotsamItemPrefabs[index], generationPos, Quaternion.identity);
                    }
                }
                else
                {
                    for (int k = 0; k < _numberToPlaceEnemy; k++) // �G�𐶐�����
                    {
                        var index = UnityEngine.Random.Range(0, _flotsamEnemyPrefabs.Length);
                        GameObject.Instantiate(_flotsamEnemyPrefabs[index], generationPos, Quaternion.identity);
                    }
                }
            }
        }
    }
}
