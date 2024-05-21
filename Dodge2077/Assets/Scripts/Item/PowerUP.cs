
public class PowerUP : Item_Abstract
{
    public override void TakeItem(PlayerSkill _player)
    {
        _player.playerStat.AddDamage(0.5f);
    }
    public override void TakeItem(PlayerSkill2 _player)
    {
        _player.playerStat.AddDamage(0.5f);
    }
}