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

    //보스가 데미지를 받을 때 ( 매개변수에 음수를 넣어 체력 회복용도로도 가능 )
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

    //HP변경용 함수 ( 존재하는 이유는 BossMaxHP를 public하면 Inspector창에서 수정할 수 있기 때문에 오류 방지를 위해사 )
    public void ChangeMaxHP(float newMaxHP)
    {
        PlayerMaxHP = newMaxHP;
    }
    public void ChangeCurrentHP(float newCurrentHP)
    {
        PlayerCurrentHP = newCurrentHP;
    }
}
