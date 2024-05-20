using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public abstract class Item_Abstract : MonoBehaviour
{
    private Rigidbody2D rb;

    public float speed = 3.0f;

    protected CharacterStat changeStat;
    public float Duration { get; protected set; }

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Launch();
    }

    public abstract void Setting();
    public abstract void TakeItem(CharacterStatHandler statHandler);

    private void Launch()
    {
        float x = Random.Range(0, 2) == 0 ? -1 : 1;
        float y = Random.Range(0, 2) == 0 ? -1 : 1;

        rb.velocity = new Vector2(x * speed, y * speed);
    }
}

//ȸ��
//public class AddSkillPoint : Item_Abstract
//{
//    AddSkillPoint() { }

//    public override void Setting()
//    {

//    }

//    public override void TakeItem(CharacterStatHandler statHandler)
//    {

//    }
//}

////���� ( 1ȸ ��ȣ, ��ø ���� )
//public class Shield : Item_Abstract
//{
//    Shiled() { }
//    public override void Setting()
//    {

//    }

//    public override void TakeItem(CharacterStatHandler statHandler)
//    {

//    }
//}

////���� ����� �߰�
//public class AddTriangle : Item_Abstract
//{
//    AddTriangle() { }
//    public override void Setting()
//    {

//    }

//    public override void TakeItem(CharacterStatHandler statHandler)
//    {

//    }
//}

////�Ѿ��� ������ ��ȯ�� ( ���� �ð��� �־ �ð��� ������ ������ ȿ�� ����� )
//public class Homing : Item_Abstract
//{
//    Homing() { }

//    public override void Setting()
//    {

//    }

//    public override void TakeItem(CharacterStatHandler statHandler)
//    {

//    }
//}



//private void Launch()
//{
//    float x = Random.Range(0, 2) == 0 ? -1 : 1;
//    float y = Random.Range(0, 2) == 0 ? -1 : 1;

//    rigidbody.velocity = new Vector2(x * speed, y * speed);
//}