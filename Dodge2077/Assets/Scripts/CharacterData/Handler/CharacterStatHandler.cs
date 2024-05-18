using UnityEngine;
using System.Collections.Generic;
using Unity.VisualScripting;

public class CharacterStatHandler : MonoBehaviour
{
    [SerializeField] private CharacterStat baseStats;
    public CharacterStat CurrentStat { get; private set; }
    public List<CharacterStat> statsModifiers = new List<CharacterStat>();

    private void Awake()
    {
        UpdateCharacterStat();
    }

    private void UpdateCharacterStat()
    {
        CurrentStat = new CharacterStat();
        CurrentStat.statsChangeType = baseStats.statsChangeType;
        CurrentStat.maxHP = baseStats.maxHP;
        CurrentStat.speed = baseStats.speed;
        CurrentStat.damage = baseStats.damage;
        CurrentStat.penetration = baseStats.penetration;
        CurrentStat.bulletSpeed = baseStats.bulletSpeed;

        foreach (CharacterStat addStat in statsModifiers)
        {
            switch (addStat.statsChangeType)
            {
                case StatsChangeType.Add:
                    AddStat(addStat);
                    break;
                case StatsChangeType.Multiple:
                    MultipleStat(addStat);
                    break;
                case StatsChangeType.Override:
                    OverrideStat(addStat);
                    break;
            }
        }
    }

    private void AddStat(in CharacterStat stat)
    {
        CurrentStat.maxHP += stat.maxHP;
        CurrentStat.speed += stat.speed;
        CurrentStat.damage += stat.damage;
        CurrentStat.penetration += stat.penetration;
        CurrentStat.bulletSpeed += stat.bulletSpeed;
    }

    private void MultipleStat(in CharacterStat stat)
    {
        CurrentStat.maxHP *= stat.maxHP;
        CurrentStat.speed *= stat.speed;
        CurrentStat.damage *= stat.damage;
        CurrentStat.penetration *= stat.penetration;
        CurrentStat.bulletSpeed *= stat.bulletSpeed;
    }

    private void OverrideStat(in CharacterStat stat)
    {
        CurrentStat.maxHP = stat.maxHP;
        CurrentStat.speed = stat.speed;
        CurrentStat.damage = stat.damage;
        CurrentStat.penetration = stat.penetration;
        CurrentStat.bulletSpeed = stat.bulletSpeed;
    }
}