using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float damage;
    public int per;


    Rigidbody2D rigid;
    PlayerController _bulletSpawnPos; // 총알을 쏘는 위치

    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        //_bulletSpawnPos = GetComponentInParent<PlayerController>();
    }

    public void Start()
    {
        
        //Init(1, 1, new Vector3(0, 1f, 0)); // 위로 데미지 1, 관통력 1, 속도와 방향 위로 1만큼나감

        
    }

    public void Update()
    {
        if (transform.position.y > 6)
        { 
            gameObject.SetActive(false);
        }
    }


    public void Init(float damage, int per, Vector3 dir) // dir = 속도 per = 관통
    {
        this.damage = damage; // this는 bullet의 데미지 오른쪽은 함수의 데미지
        this.per = per;

        if (per >= 0) {
            rigid.velocity = dir * 15f ; // 총알 속도 =15f
        }
    }

    void OnTriggerEnter2D(Collider2D collision) {

        if (!collision.CompareTag("Enemy") || per == -100) // 적과 충돌하지 아니하거나 관통력이 없는경우에는 실행안됨
            return;

        per--;

        if (per < 0) {
            rigid.velocity = Vector2.zero;
            gameObject.SetActive(false);
        }
    }

    void OnTriggerExit2D(Collider2D collision) {
        if (!collision.CompareTag("Area") || per == -100) // 적과 충돌하지 아니하거나 관통력이 없는경우에는 실행안됨
            return;

        gameObject.SetActive(false);

    }


}
