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

    //������ �������� ���� �� ( �Ű������� ������ �־� ü�� ȸ���뵵�ε� ���� )
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

    //HP����� �Լ� ( �����ϴ� ������ BossMaxHP�� public�ϸ� Inspectorâ���� ������ �� �ֱ� ������ ���� ������ ���ػ� )
    public void ChangeMaxHP(float newMaxHP)
    {
        BossMaxHP = newMaxHP;
    }
    public void ChangeCurrentHP(float newCurrentHP)
    {
        BossCurrentHP = newCurrentHP;
    }
}
