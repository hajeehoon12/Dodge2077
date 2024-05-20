﻿
//스피드 증가
public class SpeedUP : Item_Abstract
{
    SpeedUP(float _duration)
    {
        Duration = _duration;
    }

    public override void Setting()
    {

    }

    public override void TakeItem(CharacterStatHandler statHandler)
    {
        statHandler.AddMoveSpeed(0.5f);
    }
}