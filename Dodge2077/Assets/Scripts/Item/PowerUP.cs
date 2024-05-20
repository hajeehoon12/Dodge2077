using UnityEngine;

public class PowerUP : Item_Abstract
{
    PowerUP(float _duration)
    {
        Duration = _duration;
        changeStat = new CharacterStat { statsChangeType = StatsChangeType.Add, Damage = 0.5f };
    }

    //protected override void Start()
    //{
    //    base.Start();
    //}

    public override void Setting()
    {

    }

    public override void TakeItem(CharacterStatHandler statHandler)
    {
        statHandler.BuffList.Add(changeStat);
        statHandler.AddDamage(0.5f);
    }
}