
//스피드 증가
public class SpeedUP : Item_Abstract
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
        statHandler.AddMoveSpeed(0.5f);
    }
}