using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillTriangle : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject _player;
    public ShootingBullets _shootingBullets;
    public float nextFire;
    public float fireRate = 0.5f;
    public Coroutine coroutine;

    private CharacterStatHandler playerStat;

    // Update is called once per frame
    void Start()
    {
        //StartCoroutine(Firing(_shootingBullets.coolTime));
        playerStat = _player.GetComponent<CharacterStatHandler>();
    }

    public void StartFire(float cooltime)
    {
        coroutine = StartCoroutine(Firing(cooltime));
    }



    public IEnumerator Firing(float coolTime)
    {
        while (true)
        {
            Shooting();
            yield return new WaitForSeconds(coolTime);
        }
    }

    public void StopFire()
    {
        StopCoroutine(coroutine);
    }


    //private void Update()
    //{
     //   if (Time.time > nextFire)
     //   {
     //       nextFire = Time.time + fireRate;
     //       Shooting();
     //   }
    //}

    private void Shooting()
    {
        float _damage = playerStat.CurrentStat.Damage;
        int _per = playerStat.CurrentStat.Penetration;
        float _bulletSpeed = playerStat.CurrentStat.BulletSpeed;

        AudioManager.instance.PlaySFX("Bullet", 0.01f);
        GameObject bullet = PoolManager.Instance.Get(0); // case 0 �� �ƴϱ⿡ prefabId�� �Ѿ˹�ȣ�� ��
        bullet.transform.position = transform.position;

        bullet.transform.localEulerAngles = new Vector3(0, 0, 0); // �Ѿ��� ȸ����
        
        bullet.GetComponent<Bullet>().Init(_damage, _per, _bulletSpeed); // �Ѿ� ������, �����, �ӷ�
    }


}
