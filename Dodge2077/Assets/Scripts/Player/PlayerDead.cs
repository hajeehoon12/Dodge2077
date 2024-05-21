using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDead : MonoBehaviour
{
    private HPSystem hpSystem;

    private void Start()
    {
        hpSystem = GetComponent<HPSystem>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Collider Name : " + other.gameObject.name);
        DataManager.Instance.playerHit += 10;

        //if(other.gameObject.CompareTag("EnemyBullet"))
        //{

        //}

        if (hpSystem != null) hpSystem.TakeDamage(1.0f);
    }

    private void OnParticleCollision(GameObject other)
    {
        Debug.Log("Particle Name :" + other.gameObject.name);
        DataManager.Instance.playerHit += 1;

        if (hpSystem != null) hpSystem.TakeDamage(1.0f);
    }
}
