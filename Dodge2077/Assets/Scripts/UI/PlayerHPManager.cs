using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHPManager : MonoBehaviour
{
    [SerializeField] private Slider hpBarSlider = null;

    private float PlayerMaxHP;
    private float PlayerCurrentHP;

    void Update()
    {
        
    }

    //������ �������� ���� �� ( �Ű������� ������ �־� ü�� ȸ���뵵�ε� ���� )
    public void TakeDamage(float damage)
    {
        PlayerCurrentHP -= damage;
        if (PlayerCurrentHP < 0.0f) PlayerCurrentHP = 0.0f;
        else if (PlayerCurrentHP > PlayerMaxHP) PlayerCurrentHP = PlayerMaxHP;
        SetHPBar();
    }

    public void SetHPBar()
    {
        hpBarSlider.value = PlayerCurrentHP / PlayerMaxHP;
    }

    //HP����� �Լ� ( �����ϴ� ������ BossMaxHP�� public�ϸ� Inspectorâ���� ������ �� �ֱ� ������ ���� ������ ���ػ� )
    public void ChangeMaxHP(float newMaxHP)
    {
        PlayerMaxHP = newMaxHP;
    }
    public void ChangeCurrentHP(float newCurrentHP)
    {
        PlayerCurrentHP = newCurrentHP;
    }
}
