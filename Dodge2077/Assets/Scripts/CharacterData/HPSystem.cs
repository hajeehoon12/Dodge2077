using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HPSystem : MonoBehaviour
{
    private CharacterStatHandler statHandler;
    public BossRotate bossRotate;

    public event Action<float> OnDamage;        //대미지 받을 때
    public event Action<float> OnHeal;          //힐 받을 때
    public event Action OnDeath;                //죽을 때
    //public event Action OnInvincibilityEnd;     //무적 끝날 때

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

    //대미지 받을 때 함수 ( 힐을 받을 시 매개변수를 음수로 넣어주면 된다 )
    public void TakeDamage(float _damage)
    {
        //대미지나 힐을 받음
        CurrentHealth -= _damage;

        //힐이면 OnHeal이벤트 발생, 대미지면 OnDamage이벤트 발생
        if (_damage <= 0) OnHeal?.Invoke(_damage);
        if (_damage > 0) OnDamage?.Invoke(_damage);
        //OnDamage?.Invoke(_damage);
        //0미만, 최대체력 초과로 넘어가지 않게 조정한다.
        CurrentHealth = Mathf.Clamp(CurrentHealth, 0.0f, MaxHealth);
        //Debug.Log(CurrentHealth);//temp

        //0이하일 시, 죽을 때 이벤트를 불러온다.
        if (CurrentHealth <= 0.0f && !isDead)
        {
            isDead = true;
            OnDeath?.Invoke();
        }
    }
}
