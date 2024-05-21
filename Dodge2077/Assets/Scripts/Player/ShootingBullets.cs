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
        StartCoroutine(Fire()); // coolTime 마다 총알을 발사하라
    }

    private IEnumerator Fire()
    {
        yield return null;  //넣은 이유는 첫 탄환 속도 설정이 0으로 되어서 게임이 시작하자마자 1프레임 후에 발사되도록 하였다.
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
        GameObject bullet = PoolManager.Instance.Get(0); // case 0 이 아니기에 prefabId에 총알번호가 들어감
        bullet.transform.position = transform.position;

        bullet.transform.localEulerAngles = new Vector3(0, 0, 0); // 총알의 회전값
        //Debug.Log("test");
        bullet.GetComponent<Bullet>().Init(_damage, _per, _bulletSpeed); // 총알 데미지, 관통력, 속력
    }
}
