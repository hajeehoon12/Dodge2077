using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MPSystem : MonoBehaviour
{
    public event Action<float> OnUseMana;        //마나 사용할 때
    public event Action<float> OnFillMana;       //마나 찰 때

    public float CurrentMP;
    public float MaxMP;

    private void Awake()
    {
        MaxMP = 100.0f;
        CurrentMP = MaxMP;
    }

    void Update()
    {
        if (CurrentMP < MaxMP) UseMana(-0.05f);
    }

    public void UseMana(float _mana)
    {
        if (_mana <= 0) OnFillMana?.Invoke(_mana);
        else
        {
            if (CurrentMP < _mana) return;
            else OnUseMana?.Invoke(_mana);
        }

        //마나 사용
        CurrentMP -= _mana;

        //0미만, 최대마나 초과로 넘어가지 않게 조정한다.
        CurrentMP = Mathf.Clamp(CurrentMP, 0.0f, MaxMP);
    }
}
