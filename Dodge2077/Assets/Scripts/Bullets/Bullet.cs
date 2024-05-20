using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float damage;
    public int per;


    public Rigidbody2D rigid;
    PlayerController _bulletSpawnPos; // �Ѿ��� ��� ��ġ

    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        //_bulletSpawnPos = GetComponentInParent<PlayerController>();
    }

    public void Start()
    {
        
        //Init(1, 1, new Vector3(0, 1f, 0)); // ���� ������ 1, ����� 1, �ӵ��� ���� ���� 1��ŭ����


    }

    public void OnAble()
    {
        
    }

    public void Update()
    {
        
        if (Mathf.Abs(transform.position.y) > 10 || Mathf.Abs(transform.position.x) > 10 )
        { 
            gameObject.SetActive(false);
        }
    }


    public void Init(float damage, int per, float velocity) // dir = �ӵ� per = ����
    {
        this.damage = damage; // this�� bullet�� ������ �������� �Լ��� ������
        this.per = per;

        if (per >= 0) {
            rigid.velocity = transform.up * 15 * velocity ; // �Ѿ� �ӵ� =15f
        }
    }

    void OnTriggerEnter2D(Collider2D collision) {

        if (!collision.CompareTag("Enemy") || per == -100) // ���� �浹���� �ƴ��ϰų� ������� ���°�쿡�� ����ȵ�
            return;

        per--;

        if (per < 0) {
            rigid.velocity = Vector2.zero;
            gameObject.SetActive(false);
        }
    }

    void OnTriggerExit2D(Collider2D collision) {
        if (!collision.CompareTag("Area") || per == -100) // ���� �浹���� �ƴ��ϰų� ������� ���°�쿡�� ����ȵ�
            return;

        gameObject.SetActive(false);

    }


}