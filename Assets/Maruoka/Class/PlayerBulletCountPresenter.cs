using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerBulletCountPresenter : MonoBehaviour
{
    [SerializeField]
    private Text _countText = default;

    private PlayerAttackController _attackController;
    void Start()
    {
        _attackController = GetComponent<PlayerAttackController>();
    }
    void Update()
    {
        _countText.text = $"{_attackController.bulletCount}";
    }
}
