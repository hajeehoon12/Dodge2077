using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using Unity.Mathematics;


public class DataManager : MonoBehaviour
{
    public static DataManager Instance;
    public bool is1P = true;
    public bool isEasy = true;

    public int highScore = 0;
    public int curScore = 0;

    public int playerHit = 0;



    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);

        
    }

    public void CallHighScore(GameObject HightText, Text HighText)
    {
        
        
        HightText.SetActive(true);
        Debug.Log("HighScore : " + PlayerPrefs.GetInt("BestScore").ToString());
        string inputText = "HighScore : " + PlayerPrefs.GetInt("BestScore").ToString();
        DOTween.To(() => "", str => HighText.text = str, inputText, 5f).OnComplete(() => HightText.SetActive(false));
        //HighText.DOText(, 5f).onComplete += HighTextOff;
        //HighText.DOColor(Color.black, 5f).onComplete += HighTextOff;
    }

 


    public bool IsHighScoreChanged(float Time)
    {
        highScore = PlayerPrefs.GetInt("BestScore");
        
        curScore = ((999999 / (int)Time) - playerHit * 10);
        //PlayCurScore.instance.text_score = curScore;
        

        if (curScore > highScore)
        {
            PlayerPrefs.SetInt("BestScore", curScore);
            Debug.Log(curScore);
            return true;
        }
        return false;

    }




}
