using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 漂流物ドロップクラス
public class FlotsamDrop
{
    [Tooltip("アイテムをドロップするエリア左上の座標"), SerializeField]
    private Vector3 _dropAreaTopLeft;
    [Tooltip("アイテムをドロップするエリア右下の座標"), SerializeField]
    private Vector3 _dropAreaBottomRight;
    [Tooltip("横の分割数"), SerializeField, Range(1, 10)]
    private int _horizontalDivision = 1;
    [Tooltip("縦の分割数"), SerializeField, Range(1, 10)]
    private int _verticalDivision = 1;
    [Tooltip("1区画に配置するアイテムの数"), SerializeField, Range(1, 3)]
    private int _numberToPlace = 1;
    [Tooltip("漂流物のプレハブ"), SerializeField]
    private GameObject[] _flotsamPrefabs = default;

    public void Drop()
    {
        // 指定されたエリアをn * m分割してそこにa個ずつ漂流物を配置する。
    }
}
