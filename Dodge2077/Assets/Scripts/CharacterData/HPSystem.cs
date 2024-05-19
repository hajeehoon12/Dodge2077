using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HPSystem : MonoBehaviour
{
    private CharacterStatHandler statHandler;

    public event Action<float> OnDamage;        //����� ���� ��
    public event Action<float> OnHeal;          //�� ���� ��
    public event Action OnDeath;                //���� ��
    //public event Action OnInvincibilityEnd;     //���� ���� ��

    public float CurrentHealth{ get; private set; }
    public float MaxHealth => statHandler.CurrentStat.MaxHP;

    void Awake()
    {
        statHandler = GetComponent<CharacterStatHandler>();
    }

    void Start()
    {
        if (statHandler == null) Debug.Log("null");//
        CurrentHealth = MaxHealth;
    }

    void Update()
    {
        
    }

    //����� ���� �� �Լ� ( ���� ���� �� �Ű������� ������ �־��ָ� �ȴ� )
    public void TakeDamage(float _damage)
    {
        //������� ���� ����
        CurrentHealth -= _damage;

        //���̸� OnHeal�̺�Ʈ �߻�, ������� OnDamage�̺�Ʈ �߻�
        if (_damage < 0) OnHeal?.Invoke(_damage);
        if (_damage > 0) OnDamage?.Invoke(_damage);

        //0�̸�, �ִ�ü�� �ʰ��� �Ѿ�� �ʰ� �����Ѵ�.
        CurrentHealth = Mathf.Clamp(CurrentHealth, 0.0f, MaxHealth);

        //0������ ��, ���� �� �̺�Ʈ�� �ҷ��´�.
        if (CurrentHealth <= 0.0f) OnDeath?.Invoke();
    }
}
