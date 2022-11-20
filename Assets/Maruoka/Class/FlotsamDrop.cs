using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 漂流物ドロップクラス
public class FlotsamDrop : MonoBehaviour
{
    [Tooltip("アイテムをドロップするエリア左上の座標"), SerializeField]
    private Vector2 _dropAreaTopLeft;
    [Tooltip("アイテムをドロップするエリア右下の座標"), SerializeField]
    private Vector2 _dropAreaBottomRight;
    [Tooltip("横の分割数"), SerializeField, Range(1, 10)]
    private int _horizontalDivision = 1;
    [Tooltip("縦の分割数"), SerializeField, Range(1, 10)]
    private int _verticalDivision = 1;
    [Tooltip("1区画に配置するアイテムの数"), SerializeField, Range(1, 3)]
    private int _numberToPlaceItem = 1;
    [Tooltip("1区画に配置する敵の数"), SerializeField, Range(1, 3)]
    private int _numberToPlaceEnemy = 1;
    [Tooltip("漂流物のアイテムプレハブ"), SerializeField]
    private GameObject[] _flotsamItemPrefabs = default;
    [Tooltip("漂流物の敵プレハブ"), SerializeField]
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
        // 指定されたエリアをn * m分割してそこにa個ずつ漂流物を配置する。
        for (int i = 0; i < _verticalDivision; i++)// 改行
        {
            for (int j = 0; j < _horizontalDivision; j++) // 一つ左の区画へ
            {
                var xPos = UnityEngine.Random.Range(oneAreaWidth * i, oneAreaWidth * (i + 1));
                var yPos = UnityEngine.Random.Range(oneAreaHeight * j, oneAreaHeight * (j + 1));
                var generationPos = new Vector2(xPos, yPos) + new Vector2(_dropAreaTopLeft.x, -_dropAreaTopLeft.y);

                if (_waveAnimationer.WavesPulledCount % 2 == 0)
                {
                    for (int k = 0; k < _numberToPlaceItem; k++) // アイテムを生成する
                    {
                        var index = UnityEngine.Random.Range(0, _flotsamItemPrefabs.Length);
                        GameObject.Instantiate(_flotsamItemPrefabs[index], generationPos, Quaternion.identity);
                    }
                }
                else
                {
                    for (int k = 0; k < _numberToPlaceEnemy; k++) // 敵を生成する
                    {
                        var index = UnityEngine.Random.Range(0, _flotsamEnemyPrefabs.Length);
                        GameObject.Instantiate(_flotsamEnemyPrefabs[index], generationPos, Quaternion.identity);
                    }
                }
            }
        }
    }
}
