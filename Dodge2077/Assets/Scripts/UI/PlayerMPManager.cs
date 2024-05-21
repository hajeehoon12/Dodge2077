using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMPManager : MonoBehaviour
{
    [SerializeField] private Slider hpBarSlider = null;

    private float PlayerMaxMP;
    private float PlayerCurrentMP;

    void Update()
    {
        
    }

    //보스가 데미지를 받을 때 ( 매개변수에 음수를 넣어 체력 회복용도로도 가능 )
    public void UseMana(float mana)
    {
        PlayerCurrentMP -= mana;
        if (PlayerCurrentMP < 0.0f) PlayerCurrentMP = 0.0f;
        else if (PlayerCurrentMP > PlayerMaxMP) PlayerCurrentMP = PlayerMaxMP;
        SetMPBar();
    }

    public void SetMPBar()
    {
        hpBarSlider.value = PlayerCurrentMP / PlayerMaxMP;
    }

    //HP변경용 함수 ( 존재하는 이유는 BossMaxHP를 public하면 Inspector창에서 수정할 수 있기 때문에 오류 방지를 위해사 )
    public void ChangeMaxMP(float newMaxMP)
    {
        PlayerMaxMP = newMaxMP;
    }
    public void ChangeCurrentMP(float newCurrentMP)
    {
        PlayerCurrentMP = newCurrentMP;
    }
}
