using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDead : MonoBehaviour
{
    private PlayerHPSystem hpSystem;

    private void Start()
    {
        hpSystem = GetComponent<PlayerHPSystem>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Collider Name : " + other.gameObject.name);
        DataManager.Instance.playerHit += 10;


        if (hpSystem != null)
        {
            hpSystem.TakeDamage(10.0f);
            if(other.name != "BulletEnemyTriangle")
            other.gameObject.SetActive(false);
        }

    }

    private void OnParticleCollision(GameObject other)
    {
        Debug.Log("Particle Name :" + other.gameObject.name);
        DataManager.Instance.playerHit += 1;

        if (hpSystem != null) hpSystem.TakeDamage(1.0f);
    }
}
