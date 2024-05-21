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

    //������ �������� ���� �� ( �Ű������� ������ �־� ü�� ȸ���뵵�ε� ���� )
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

    //HP����� �Լ� ( �����ϴ� ������ BossMaxHP�� public�ϸ� Inspectorâ���� ������ �� �ֱ� ������ ���� ������ ���ػ� )
    public void ChangeMaxMP(float newMaxMP)
    {
        PlayerMaxMP = newMaxMP;
    }
    public void ChangeCurrentMP(float newCurrentMP)
    {
        PlayerCurrentMP = newCurrentMP;
    }
}
