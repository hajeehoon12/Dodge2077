using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class BossRotate : MonoBehaviour
{
    public GameObject LightBoss;
    public GameObject DarkBoss;

    private bool isRotate = false; 

    // Update is called once per frame

    public void Start()
    {
        transform.DOMove(new Vector3(0, 2.5f, 0), 3f);
        Invoke("StartRotate", 5f);
    }

    private void StartRotate()
    {
        StartCoroutine(RotateBoss(5f));
    }


    private IEnumerator RotateBoss(float RotateTime)
    {
        while (true)
        {
            if (!isRotate)
            {
                transform.DORotate(new Vector3(0, 0, 180), 1);
                isRotate = true;
                yield return new WaitForSeconds(RotateTime);
            }
            else
            {
                transform.DORotate(new Vector3(0, 0, 360), 1);
                isRotate = false;
                yield return new WaitForSeconds(RotateTime);
            }
        }
    }
}
