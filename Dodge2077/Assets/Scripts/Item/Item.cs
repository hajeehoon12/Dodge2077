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

//���ݷ� ����
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

//���ǵ� ����
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

//ȸ��
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

////���� ( 1ȸ ��ȣ, ��ø ���� )
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

////�Ѿ� �߻� ��, ������ Ȯ����ŭ �߰� źȯ �߻����ִ� ������
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

////�Ѿ��� ������ ��ȯ�� ( ���� �ð��� �־ �ð��� ������ ������ ȿ�� ����� )
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