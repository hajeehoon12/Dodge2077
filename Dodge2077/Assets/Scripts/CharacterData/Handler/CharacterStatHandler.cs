using UnityEngine;
using System.Collections.Generic;
using Unity.VisualScripting;

public class CharacterStatHandler : MonoBehaviour
{
    [SerializeField] private CharacterStat baseStats;
    public CharacterStat CurrentStat { get; private set; }
    //���� ����Ʈ ( ������ ����âó�� �� �����Ǿ� �ִ� ��������Ʈ�� �����ϸ� �˴ϴ� )
    public List<CharacterStat> BuffList = new List<CharacterStat>();

    //���� �߰� ��������Ʈ �ۼ� ����
    //���� ���� ��������Ʈ �ۼ� ����

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

    //�ܺο��� ������ ������ �ڿ� �� �ҷ��;� �ϴ� �Լ� ( ������ ������ ���� ���� �ִ� �������� ������Ѿ� �ϱ� �����̴� )
    private void UpdateCharacterStat()
    {
        //���� ����Ʈ���� ��� ��������ִ� for��
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

    //���� �뵵��
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

    //�ܼ��� ���Ⱥ���뵵
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