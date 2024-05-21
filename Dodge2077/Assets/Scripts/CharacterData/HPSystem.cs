using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HPSystem : MonoBehaviour
{
    private CharacterStatHandler statHandler;
    public BossRotate bossRotate;

    public event Action<float> OnDamage;        //����� ���� ��
    public event Action<float> OnHeal;          //�� ���� ��
    public event Action OnDeath;                //���� ��
    //public event Action OnInvincibilityEnd;     //���� ���� ��

    public bool isDead = false; // make true if dead 

    public float CurrentHealth{ get; set; }
    public float MaxHealth => statHandler.CurrentStat.MaxHP;

    void Awake()
    {
        statHandler = GetComponent<CharacterStatHandler>();
        //bossRotate = GetComponentInParent<BossRotate>();
    }

    void Start()
    {
        if (statHandler == null) Debug.Log("null");//
        CurrentHealth = MaxHealth;
        OnDeath += bossRotate.BossPhase; // Call func BossPhase()
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
        if (_damage <= 0) OnHeal?.Invoke(_damage);
        if (_damage > 0) OnDamage?.Invoke(_damage);
        //OnDamage?.Invoke(_damage);
        //0�̸�, �ִ�ü�� �ʰ��� �Ѿ�� �ʰ� �����Ѵ�.
        CurrentHealth = Mathf.Clamp(CurrentHealth, 0.0f, MaxHealth);
        //Debug.Log(CurrentHealth);//temp

        //0������ ��, ���� �� �̺�Ʈ�� �ҷ��´�.
        if (CurrentHealth <= 0.0f && !isDead)
        {
            isDead = true;
            OnDeath?.Invoke();
        }
    }
}
