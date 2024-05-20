

public class SpeedUP : Item_Abstract
{
    public override void TakeItem(CharacterStatHandler statHandler)
    {
        statHandler.MultiplyMoveSpeed(1.1f);
    }
}