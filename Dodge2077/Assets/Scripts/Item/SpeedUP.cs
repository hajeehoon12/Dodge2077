

public class SpeedUP : Item_Abstract
{
    public override void TakeItem(PlayerSkill _player)
    {
        _player.playerStat.MultiplyMoveSpeed(1.1f);
    }
    public override void TakeItem(PlayerSkill2 _player)
    {
        _player.playerStat.MultiplyMoveSpeed(1.1f);
    }
}