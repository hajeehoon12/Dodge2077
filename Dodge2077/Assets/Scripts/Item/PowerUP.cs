﻿
public class PowerUP : Item_Abstract
{
    //protected override IEnumerator DeleteThisItem()
    //{
    //    yield return new WaitForSeconds(10.0f);
    //    Destroy(gameObject);
    //}
    public override void TakeItem(CharacterStatHandler statHandler)
    {
        statHandler.AddDamage(0.5f);
    }
}