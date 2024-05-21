using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MPSystem : MonoBehaviour
{
    public event Action<float> OnUseMana;        //���� ����� ��
    public event Action<float> OnFillMana;       //���� �� ��

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

        //���� ���
        CurrentMP -= _mana;

        //0�̸�, �ִ븶�� �ʰ��� �Ѿ�� �ʰ� �����Ѵ�.
        CurrentMP = Mathf.Clamp(CurrentMP, 0.0f, MaxMP);
    }
}
