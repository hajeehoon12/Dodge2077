
public class CollderSizeDown : Item_Abstract
{
    public override void TakeItem(PlayerSkill _player)
    {
        _player.collider.size *= 0.9f;

    }
    public override void TakeItem(PlayerSkill2 _player)
    {
        _player.colliders.size *= 0.9f;
    }
}