using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class BossRotate : MonoBehaviour
{
    public WhiteHyuk _whiteHyuk;
    public DarkHyuk _darkHyuk;

    private bool isRotate = false;
    private bool isPatternEnd = false;

    Vector3 firstRotate = new Vector3(0, 0, 180);
    Vector3 secondRotate = new Vector3(0, 0, 360);

    public Coroutine BossCoroutine; // variable to call boss Coroutine


    // Update is called once per frame



    public void Start()
    {
        transform.DOMove(new Vector3(0, 2.8f, 0), 3f);

        Invoke("StartRotate", 3f);
    }

    private void StartRotate()
    {
        BossCoroutine=StartCoroutine(RotateBoss(5f)); // call main Coroutine after 5sec
    }

    public void StopRotate()
    {
        StopCoroutine(BossCoroutine); // make instance to call boss Coroutine
    }

    private void HyukPattern()
    {
        isPatternEnd = true;
        if (isRotate)
        {
            _whiteHyuk.CallWhite();
            //call WhiteHyuk Boss Pattern
        }
        else
        {
            _darkHyuk.CallDark();
            //call DarkHyuk Boss Pattern
        }
    }
    // UniTask
    private IEnumerator RotateBoss(float RotateTime) // Boss Rotate and call Pattern
    {
        while (true)
        {
            isPatternEnd = false;

            if (!isRotate)
            {              
                transform.DORotate(firstRotate, 1).onComplete += HyukPattern; // Rotate 180 degree in 1sec

                isRotate = true;
                yield return new WaitUntil(() => isPatternEnd); // wait until isPatterEnd is true
                yield return new WaitForSeconds(3f);  // wait 3 sec
            }
            else
            {       
                transform.DORotate(secondRotate, 1).onComplete += HyukPattern; // Rotate another 180 degree in 1sec
                isRotate = false;
                yield return new WaitUntil(() => isPatternEnd); // wait until isPatterEnd is true
                yield return new WaitForSeconds(3f); // wait 3 sec
            }
        }
    }
}