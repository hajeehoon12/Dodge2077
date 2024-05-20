using UnityEngine;

public class PowerUP : Item_Abstract
{
    PowerUP(float _duration)
    {
        Duration = _duration;
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
        statHandler.AddDamage(0.5f);
    }
}