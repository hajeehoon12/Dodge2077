using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TestBossStat : MonoBehaviour
{
    [SerializeField] private Slider hpBar;

    public float MaxHP;
    public float CurrentHP;

    bool IsDead = false;

    // Start is called before the first frame update
    void Start()
    {
        MaxHP = 100.0f;
        CurrentHP = MaxHP;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void TakeDamage(float damage)
    {
        CurrentHP -= damage;
        if (CurrentHP < 0) CurrentHP = 0;
        else if(CurrentHP > MaxHP) CurrentHP = MaxHP;

        ChageHPBar();
    }

    void ChageHPBar()
    {
        hpBar.value = CurrentHP / MaxHP;
    }
}
