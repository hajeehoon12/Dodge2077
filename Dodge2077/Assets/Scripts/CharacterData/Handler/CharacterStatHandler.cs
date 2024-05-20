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

    //½ºÅÈ Ãß°¡ (µ¡¼À)
    public void AddDamage(float _addDamage)
    {
        CurrentStat.Damage += _addDamage;
    }
    public void AddMoveSpeed(float _addMoveSpeed)
    {
        CurrentStat.MoveSpeed += _addMoveSpeed;
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