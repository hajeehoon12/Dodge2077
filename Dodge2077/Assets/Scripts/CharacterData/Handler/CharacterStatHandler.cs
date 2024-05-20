using UnityEngine;
using System.Collections.Generic;
using Unity.VisualScripting;

public class CharacterStatHandler : MonoBehaviour
{
    [SerializeField] private CharacterStat baseStats;
    public CharacterStat CurrentStat { get; private set; }
    //버프 리스트 ( 메이플 버프창처럼 쭉 나열되어 있는 버프리스트라 생각하면 됩니다 )
    public List<CharacterStat> BuffList = new List<CharacterStat>();

    //버프 추가 델리게이트 작성 예정
    //버프 삭제 델리게이트 작성 예정

    private void Awake()
    {
        CurrentStat = new CharacterStat();
        CurrentStat.statsChangeType = baseStats.statsChangeType;
        CurrentStat.MaxHP = baseStats.MaxHP;
        CurrentStat.MoveSpeed = baseStats.MoveSpeed;
        CurrentStat.Damage = baseStats.Damage;
        CurrentStat.Penetration = baseStats.Penetration;
        CurrentStat.BulletSpeed = baseStats.BulletSpeed;
    }

    //외부에서 스탯을 변경한 뒤에 꼭 불러와야 하는 함수 ( 스탯을 변경한 다음 남아 있는 버프들을 적용시켜야 하기 때문이다 )
    private void UpdateCharacterStat()
    {
        //버프 리스트들을 모두 적용시켜주는 for문
        foreach (CharacterStat addStat in BuffList)
        {

            switch (addStat.statsChangeType)
            {
                case StatsChangeType.Add:
                    Buff_AddStat(addStat);
                    break;
                case StatsChangeType.Multiple:
                    Buff_MultipleStat(addStat);
                    break;
                case StatsChangeType.Override:
                    Buff_OverrideStat(addStat);
                    break;
            }

        }

    }

    //버프 용도들
    private void Buff_AddStat(in CharacterStat stat)
    {
        CurrentStat.MaxHP += stat.MaxHP;
        CurrentStat.MoveSpeed += stat.MoveSpeed;
        CurrentStat.Damage += stat.Damage;
        CurrentStat.Penetration += stat.Penetration;
        CurrentStat.BulletSpeed += stat.BulletSpeed;
    }
    private void Buff_MultipleStat(in CharacterStat stat)
    {
        CurrentStat.MaxHP *= stat.MaxHP;
        CurrentStat.MoveSpeed *= stat.MoveSpeed;
        CurrentStat.Damage *= stat.Damage;
        CurrentStat.Penetration *= stat.Penetration;
        CurrentStat.BulletSpeed *= stat.BulletSpeed;
    }
    private void Buff_OverrideStat(in CharacterStat stat)
    {
        CurrentStat.MaxHP = stat.MaxHP;
        CurrentStat.MoveSpeed = stat.MoveSpeed;
        CurrentStat.Damage = stat.Damage;
        CurrentStat.Penetration = stat.Penetration;
        CurrentStat.BulletSpeed = stat.BulletSpeed;
    }

    //단순한 스탯변경용도
    public void ChangeMaxHP(float _maxHP)
    {
        CurrentStat.MaxHP = _maxHP;
        UpdateCharacterStat();
    }
    public void ChangeMoveSpeed(float _moveSpeed)
    {
        CurrentStat.MoveSpeed = _moveSpeed;
        UpdateCharacterStat();
    }
    public void ChangeDamage(float _damage)
    {
        CurrentStat.Damage = _damage;
        UpdateCharacterStat();
    }
    public void ChangePenetration(int _penetration)
    {
        CurrentStat.Penetration = _penetration;
        UpdateCharacterStat();
    }
    public void ChangeBulletSpeed(float _bulletSpeed)
    {
        CurrentStat.BulletSpeed = _bulletSpeed;
        UpdateCharacterStat();
    }

    public void AddDamage(float _addDamage)
    {
        CurrentStat.Damage += _addDamage;
        //UpdateCharacterStat();
    }
    public void AddMoveSpeed(float _addMoveSpeed)
    {
        CurrentStat.MoveSpeed += _addMoveSpeed;
        //UpdateCharacterStat();
    }
}