using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// �Y�����h���b�v�N���X
public class FlotsamDrop
{
    [Tooltip("�A�C�e�����h���b�v����G���A����̍��W"), SerializeField]
    private Vector3 _dropAreaTopLeft;
    [Tooltip("�A�C�e�����h���b�v����G���A�E���̍��W"), SerializeField]
    private Vector3 _dropAreaBottomRight;
    [Tooltip("���̕�����"), SerializeField, Range(1, 10)]
    private int _horizontalDivision = 1;
    [Tooltip("�c�̕�����"), SerializeField, Range(1, 10)]
    private int _verticalDivision = 1;
    [Tooltip("1���ɔz�u����A�C�e���̐�"), SerializeField, Range(1, 3)]
    private int _numberToPlace = 1;
    [Tooltip("�Y�����̃v���n�u"), SerializeField]
    private GameObject[] _flotsamPrefabs = default;

    public void Drop()
    {
        // �w�肳�ꂽ�G���A��n * m�������Ă�����a���Y������z�u����B
    }
}
