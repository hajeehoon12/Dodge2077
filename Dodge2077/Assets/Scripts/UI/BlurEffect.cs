using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using Unity.Mathematics;
using static UnityEditor.Experimental.GraphView.GraphView;


public class BlurEffect : MonoBehaviour
{
    RawImage image;
    Color color;

    public Image imgP1;
    public GameObject P1Obj;
    public Image imgP2;
    public GameObject P2Obj;

    private bool isButtonPressed = false;

    //private bool bluroff = false;

    // Start is called before the first frame update
    private void Awake()
    {
        image = GetComponent<RawImage>();
        image.DOFade(0, 0f);
        imgP1.DOFade(0, 0f);
        imgP2.DOFade(0, 0f);

        //imgP2.
        //gameObject.set
    }

    void Start()
    {
        image.DOFade(1, 10f);
        imgP1.DOFade(1, 10f);
        //imgP2.DOFade(1, 10f);
        //DOTween.To(() => color.a, x => color.a = x, 255, 10);
    }

    public void ButtonPressed()
    {
        if (!isButtonPressed)
        {
            isButtonPressed = true;
            DataManager.Instance.is1P = false;
            imgP1.DOFade(0, 3f);
            imgP2.DOFade(1, 3f);      
        }
        else
        {
            isButtonPressed = false;
            DataManager.Instance.is1P = true;
            imgP2.DOFade(0, 3f);
            imgP1.DOFade(1, 3f);

        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}