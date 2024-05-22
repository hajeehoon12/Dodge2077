using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class StartBtn : MonoBehaviour
{
    public Button startBtn;
    public Button HighScoreBtn;
    public Text HighText;
    public GameObject HighScoreObj;
    void Start()
    {
        startBtn.onClick.AddListener(() => GameManager.Instance.SceneChanged());
        HighScoreBtn.onClick.AddListener(() => DataManager.Instance.CallHighScore(HighScoreObj, HighText));
    }


}