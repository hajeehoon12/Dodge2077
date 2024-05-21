using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingBullets : MonoBehaviour
{
    public GameObject _bullet;
    public GameObject _poolManager;

    private CharacterStatHandler playerStat;

    private void Awake()
    {
        playerStat = GetComponent<CharacterStatHandler>();
    }



    void Start()
    {
        StartCoroutine(Fire()); // coolTime ���� �Ѿ��� �߻��϶�
    }

    private IEnumerator Fire()
    {
        yield return null;  //���� ������ ù źȯ �ӵ� ������ 0���� �Ǿ ������ �������ڸ��� 1������ �Ŀ� �߻�ǵ��� �Ͽ���.
        while (true)
        {
            Shoot();
            yield return new WaitForSeconds(playerStat.CurrentStat.BulletCoolTime);
        }
    }

    private void Shoot()
    {
        float _damage = playerStat.CurrentStat.Damage;
        int _per = playerStat.CurrentStat.Penetration;
        float _bulletSpeed = playerStat.CurrentStat.BulletSpeed;

        AudioManager.instance.PlaySFX("Bullet", 0.01f);
        GameObject bullet = PoolManager.Instance.Get(0); // case 0 �� �ƴϱ⿡ prefabId�� �Ѿ˹�ȣ�� ��
        bullet.transform.position = transform.position;

        bullet.transform.localEulerAngles = new Vector3(0, 0, 0); // �Ѿ��� ȸ����
        //Debug.Log("test");
        bullet.GetComponent<Bullet>().Init(_damage, _per, _bulletSpeed); // �Ѿ� ������, �����, �ӷ�
    }
}
