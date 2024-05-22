using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GameOverBtn : MonoBehaviour
{
    public Button restartBtn;
    //public Button HighScoreBtn;
    void Start()
    {
        restartBtn.onClick.AddListener(() => GameManager.Instance.GoMain());
        
    }


}