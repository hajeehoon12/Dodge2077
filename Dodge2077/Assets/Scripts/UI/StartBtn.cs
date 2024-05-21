using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class StartBtn : MonoBehaviour
{
    public Button startBtn;
    void Start()
    {
        startBtn.onClick.AddListener(() => GameManager.Instance.SceneChanged());
    }

    
}
