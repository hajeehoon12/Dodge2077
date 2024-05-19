using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossHPManager : MonoBehaviour
{
    [SerializeField] private Slider hpBarSlider = null;

    private float BossMaxHP;
    private float BossCurrentHP;

    void Update()
    {
        
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

    //HP변경용 함수 ( 존재하는 이유는 BossMaxHP를 public하면 Inspector창에서 수정할 수 있기 때문에 오류 방지를 위해사 )
    public void ChangeMaxHP(float newMaxHP)
    {
        BossMaxHP = newMaxHP;
    }
    public void ChangeCurrentHP(float newCurrentHP)
    {
        BossCurrentHP = newCurrentHP;
    }
}
