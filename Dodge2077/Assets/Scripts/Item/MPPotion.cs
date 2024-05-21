public class MPPotion : Item_Abstract
{
    public override void TakeItem(PlayerSkill _player)
    {
        _player.mpSystem.UseMana(-50.0f);
    }
    public override void TakeItem(PlayerSkill2 _player)
    {
        _player.mpSystem.UseMana(-50.0f);
    }
}