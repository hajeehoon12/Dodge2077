using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class BossRotate : MonoBehaviour
{
    public GameObject LightBoss;
    public GameObject DarkBoss;

    private bool isRotate = false;
    private bool isPatternEnd = false;

    Vector3 firstRotate = new Vector3(0, 0, 180);
    Vector3 secondRotate = new Vector3(0, 0, 360);

    public Coroutine BossCoroutine;
    

    // Update is called once per frame

    public void Start()
    {
        transform.DOMove(new Vector3(0, 2.5f, 0), 3f);
        Invoke("StartRotate", 5f);
    }

    private void StartRotate()
    {
        BossCoroutine=StartCoroutine(RotateBoss(5f));
    }

    public void StopRotate()
    {
        StopCoroutine(BossCoroutine);
    }

    private void HyukPattern()
    {
        // PatternCall
        isPatternEnd = true;
    }
    // UniTask
    private IEnumerator RotateBoss(float RotateTime)
    {
        while (true)
        {
            isPatternEnd = false;

            if (!isRotate)
            {              
                transform.DORotate(firstRotate, 1).onComplete += HyukPattern;

                isRotate = true;
                yield return new WaitUntil(() => isPatternEnd);
                yield return new WaitForSeconds(4f);
            }
            else
            {       
                transform.DORotate(secondRotate, 1).onComplete += HyukPattern;
                isRotate = false;
                yield return new WaitUntil(() => isPatternEnd);
                yield return new WaitForSeconds(4f);
            }
        }
    }
}