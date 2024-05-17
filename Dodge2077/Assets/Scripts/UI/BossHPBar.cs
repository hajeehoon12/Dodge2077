using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossHPBar : MonoBehaviour
{
    [SerializeField] private GameObject bossHPBar = null;

    private float BossMaxHP;
    private float BossCurrentHP;

    void Start()
    {
        Invoke("StartBossHPBar", 2.0f);
        bossHPBar.SetActive(false);
    }

    void Update()
    {
        
    }

    public void StartBossHPBar()
    {
        bossHPBar.SetActive(true);
        Debug.Log("Start");
    }

    //������ �������� ���� �� ( �Ű������� ������ �־� ü�� ȸ���뵵�ε� ���� )
    public void TakeDamage(float damage)
    {
        BossCurrentHP -= damage;
        if (BossCurrentHP < 0.0f) BossCurrentHP = 0.0f;
        else if (BossCurrentHP > BossMaxHP) BossCurrentHP = BossMaxHP;
    }
}
