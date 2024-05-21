public class BulletAttackSpeedUP : Item_Abstract
{
    public override void TakeItem(PlayerSkill _player)
    {
        _player.playerStat.MultiplyBulletSpeed(1.1f);
        _player.playerStat.MultiplyBulletCoolTime(0.5f);
    }
    public override void TakeItem(PlayerSkill2 _player)
    {
        _player.playerStat.MultiplyBulletSpeed(1.1f);
        _player.playerStat.MultiplyBulletCoolTime(0.5f);
    }
}