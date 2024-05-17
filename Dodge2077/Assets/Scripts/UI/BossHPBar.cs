using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossHPBar : MonoBehaviour
{
    [SerializeField] private GameObject bossHPBar = null;
    [SerializeField] private Slider hpBarSlider = null;

    private float BossMaxHP;
    private float BossCurrentHP;

    void Start()
    {
        Invoke("StartBossHPBar", 2.0f);
        bossHPBar.SetActive(false);

        //Temp
        BossMaxHP = 100.0f;         //여기 임의로 설정
        BossCurrentHP = BossMaxHP;
    }

    void Update()
    {
        
    }

    public void StartBossHPBar()
    {
        bossHPBar.SetActive(true);
        Debug.Log("Start");
    }

    //보스가 데미지를 받을 때 ( 매개변수에 음수를 넣어 체력 회복용도로도 가능 )
    public void TakeDamage(float damage)
    {
        BossCurrentHP -= damage;
        if (BossCurrentHP < 0.0f) BossCurrentHP = 0.0f;
        else if (BossCurrentHP > BossMaxHP) BossCurrentHP = BossMaxHP;
        SetHPBar();
    }

    public void SetHPBar()
    {
        hpBarSlider.value = BossCurrentHP / BossMaxHP;
    }
}
