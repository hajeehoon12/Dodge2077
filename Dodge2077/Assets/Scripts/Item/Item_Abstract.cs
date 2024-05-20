using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.WSA;

public abstract class Item_Abstract : MonoBehaviour
{
    [SerializeField] private float speed;
    private Rigidbody2D rb;
    public float Duration { get; protected set; }

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Launcher();
        StartCoroutine(DeleteThisItem());
    }

    private void Launcher()
    {
        float x = Random.Range(0, 2) == 0 ? -1 : 1;
        float y = Random.Range(0, 2) == 0 ? -1 : 1;

        rb.velocity = new Vector2(x * speed, y * speed);
    }

    private void FixedUpdate()
    {
        if(transform.position.x < -3.0f || transform.position.x > 3.0f)
        {
            rb.velocity = new Vector2(rb.velocity.x * -1.0f, rb.velocity.y);
        }
        if(transform.position.y < -5.0f || transform.position.y > 5.0f)
        {
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * -1.0f);
        }
    }

    private IEnumerator DeleteThisItem()
    {
        yield return new WaitForSeconds(3.0f);
        Debug.Log("Destroy");
        Destroy(gameObject);
    }

    public abstract void TakeItem(CharacterStatHandler statHandler);
}

////쉴드 ( 1회 보호, 중첩 가능 )
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

////작은 비행기 추가
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

////총알이 유도로 전환됨 ( 제한 시간이 있어서 시간이 끝나면 아이템 효과 사라짐 )
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