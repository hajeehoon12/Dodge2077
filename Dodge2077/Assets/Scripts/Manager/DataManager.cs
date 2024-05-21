using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


public class DataManager : MonoBehaviour
{
    public static DataManager Instance;
    public bool is1P = true;
    public bool isEasy = true;

    public int highScore = 0;
    public int curScore = 0;


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


    public bool isHighScoreChanged(float Time)
    {
        highScore = PlayerPrefs.GetInt("BestScore");
        curScore = (int)Time;


        if (curScore > highScore)
        {
            PlayerPrefs.SetInt("BestScore", curScore);
            Debug.Log("curScore");
            return true;
        }
        return false;

    }




}
