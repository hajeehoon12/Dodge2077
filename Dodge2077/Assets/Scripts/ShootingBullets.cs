using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingBullets : MonoBehaviour
{
    public GameObject _bullet;
    public GameObject _poolManager;

    public float _damage; // �Ѿ� ������
    public int _per; // �Ѿ� �����
    public float _bulletSpeed; // �Ѿ� �ӷ�

    public float coolTime = 1f;
    private float lastFireTime;

    // Start is called before the first frame update


    private void Awake()
    {
        
    }



    void Start()
    {
        _damage = 1;
        _per = 1;
        StartCoroutine(Fire(coolTime)); // coolTime ���� �Ѿ��� �߻��϶�
    }

    private IEnumerator Fire(float coolTime)
    {
        while (true)
        {
            Shoot();
            yield return new WaitForSeconds(coolTime);
        }
    }

    private void Shoot()
    {
        GameObject bullet = GameManager.Instance.pool.Get(0); // case 0 �� �ƴϱ⿡ prefabId�� �Ѿ˹�ȣ�� ��
        bullet.transform.position = transform.position;

        bullet.transform.localEulerAngles = new Vector3(0, 0, 0); // �Ѿ��� ȸ����
        //Debug.Log("test");
        bullet.GetComponent<Bullet>().Init(_damage, _per, new Vector3(0,_bulletSpeed,0)); // �Ѿ� ������, �����, �ӷ�
    }

}
