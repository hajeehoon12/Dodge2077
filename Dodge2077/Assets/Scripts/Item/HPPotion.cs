public class HPPotion : Item_Abstract
{
    public override void TakeItem(PlayerSkill _player)
    {
        _player.hpSystem.TakeDamage(-300.0f);
    }
    public override void TakeItem(PlayerSkill2 _player)
    {
        _player.hpSystem.TakeDamage(-300.0f);
    }
}