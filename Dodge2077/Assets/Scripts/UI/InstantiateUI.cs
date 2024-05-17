using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantiateUI : MonoBehaviour
{
    [SerializeField] private GameObject BossHPBarPrefab = null;

    private Vector2 BossHPBarPrefabPosition = Vector2.zero;

    void Start()
    {
        //BossHPBarPrefab ����
        GameObject bossHPBarObject = Instantiate(BossHPBarPrefab, BossHPBarPrefabPosition, Quaternion.identity,
            GameObject.Find("Canvas").transform);
        bossHPBarObject.transform.position += GameObject.Find("Canvas").transform.position; //������ ����
    }
}
