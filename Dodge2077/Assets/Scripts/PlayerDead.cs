using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDead : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Game Over!!");
    }

    private void OnParticleCollision(GameObject other)
    {
        Debug.Log("I crashed in particle");
    }
}
