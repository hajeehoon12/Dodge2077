using UnityEngine;
using System.Collections.Generic;
using Unity.VisualScripting;

public class CharacterStatHandler : MonoBehaviour
{
    [SerializeField] private CharacterStat baseStats;
    public CharacterStat CurrentStat { get; private set; }

    private void Awake()
    {
        CurrentStat = new CharacterStat();
        CurrentStat.MaxHP = baseStats.MaxHP;
        CurrentStat.MoveSpeed = baseStats.MoveSpeed;
        CurrentStat.Damage = baseStats.Damage;
        CurrentStat.Penetration = baseStats.Penetration;
        CurrentStat.BulletSpeed = baseStats.BulletSpeed;
        CurrentStat.BulletCoolTime = baseStats.BulletCoolTime;
    }

    public void PlayerInit_Easy()
    {
        CurrentStat.MaxHP = 1000.0f;
        CurrentStat.MoveSpeed = 2.5f;
        CurrentStat.Damage = 3f;
        CurrentStat.Penetration = 0;
        CurrentStat.BulletSpeed = 1.0f;
        CurrentStat.BulletCoolTime = 0.2f;
    }

    public void PlayerInit_Hard()
    {
        CurrentStat.MaxHP = 500.0f;
        CurrentStat.MoveSpeed = 2.0f;
        CurrentStat.Damage = 1f;
        CurrentStat.Penetration = 0;
        CurrentStat.BulletSpeed = 1.0f;
        CurrentStat.BulletCoolTime = 0.5f;
    }

    //´Ü¼øÇÑ ½ºÅÈº¯°æ¿ëµµ
    public void ChangeMaxHP(float _maxHP)
    {
        CurrentStat.MaxHP = _maxHP;
    }
    public void ChangeMoveSpeed(float _moveSpeed)
    {
        CurrentStat.MoveSpeed = _moveSpeed;
    }
    public void ChangeDamage(float _damage)
    {
        CurrentStat.Damage = _damage;
    }
    public void ChangePenetration(int _penetration)
    {
        CurrentStat.Penetration = _penetration;
    }
    public void ChangeBulletSpeed(float _bulletSpeed)
    {
        CurrentStat.BulletSpeed = _bulletSpeed;
    }
    public void ChangeBulletCoolTime(float _bulletCoolTime)
    {
        CurrentStat.BulletCoolTime = _bulletCoolTime;
    }

    //½ºÅÈ Ãß°¡ (µ¡¼À)
    public void AddDamage(float _addDamage)
    {
        CurrentStat.Damage += _addDamage;
    }
    public void AddMoveSpeed(float _addMoveSpeed)
    {
        CurrentStat.MoveSpeed += _addMoveSpeed;
    }
    public void AddPenetration(int _addPenetration)
    {
        CurrentStat.Penetration += _addPenetration;
    }
    public void AddBulletSpeed(float _addBulletSpeed)
    {
        CurrentStat.BulletSpeed += _addBulletSpeed;
    }
    public void AddBulletCoolTime(float _addBulletCollTime)
    {
        CurrentStat.BulletCoolTime += _addBulletCollTime;
    }

    //½ºÅÈ Ãß°¡ (°ö¼À)
    public void MultiplyDamage(float _multiplyDamage)
    {
        CurrentStat.Damage *= _multiplyDamage;
    }
    public void MultiplyMoveSpeed(float _multiplyMoveSpeed)
    {
        CurrentStat.MoveSpeed *= _multiplyMoveSpeed;
    }
    public void MultiplyBulletSpeed(float _multiplyBulletSpeed)
    {
        CurrentStat.BulletSpeed *= _multiplyBulletSpeed;
    }
    public void MultiplyBulletCoolTime(float _multiplyBulletCoolTime)
    {
        CurrentStat.BulletCoolTime *= _multiplyBulletCoolTime;
    }

    //±âÅ¸ ±â´É
    public void HalfMoveSpeed()
    {
        CurrentStat.MoveSpeed /= 2;
    }
    public void CallBackMoveSpeed()
    {
        CurrentStat.MoveSpeed *= 2;
    }

}