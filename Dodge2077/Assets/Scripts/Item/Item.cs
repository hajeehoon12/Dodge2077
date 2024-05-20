using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Item : MonoBehaviour
{
    protected CharacterStat changeStat;
    public float Duration { get; protected set; }

    public abstract void Setting();
    public abstract void TakeItem(CharacterStatHandler statHandler);
}

//공격력 증가
public class PowerUP : Item
{
    PowerUP(float _duration)
    {
        Duration = _duration;
        changeStat = new CharacterStat { statsChangeType = StatsChangeType.Add, Damage = 0.5f };
    }

    public override void Setting()
    {

    }

    public override void TakeItem(CharacterStatHandler statHandler)
    {
        statHandler.BuffList.Add(changeStat);
    }
}

//스피드 증가
public class SpeedUP : Item
{
    SpeedUP(float _duration)
    {
        Duration = _duration;
        changeStat = new CharacterStat{ statsChangeType = StatsChangeType.Add, MoveSpeed = 0.5f };
    }

    public override void Setting()
    {

    }

    public override void TakeItem(CharacterStatHandler statHandler)
    {
        statHandler.BuffList.Add(changeStat);
    }
}

//회복
//public class HealMedichne : Item
//{
//    HealMedichne() { }

//    public override void Setting()
//    {

//    }

//    public override void TakeItem(CharacterStatHandler statHandler)
//    {

//    }
//}

////쉴드 ( 1회 보호, 중첩 가능 )
//public class Shiled : Item
//{
//    Shiled() { }
//    public override void Setting()
//    {

//    }

//    public override void TakeItem(CharacterStatHandler statHandler)
//    {

//    }
//}

////총알 발사 시, 임의의 확률만큼 추가 탄환 발사해주는 아이템
//public class BonusBullet : Item
//{
//    BonusBullet() { }
//    public override void Setting()
//    {

//    }

//    public override void TakeItem(CharacterStatHandler statHandler)
//    {

//    }
//}

////총알이 유도로 전환됨 ( 제한 시간이 있어서 시간이 끝나면 아이템 효과 사라짐 )
//public class Homing : Item
//{
//    Homing() { }

//    public override void Setting()
//    {

//    }

//    public override void TakeItem(CharacterStatHandler statHandler)
//    {

//    }
//}