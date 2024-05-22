using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawner : MonoBehaviour
{

    [SerializeField] private GameObject powerUP;            //20%
    [SerializeField] private GameObject speedUP;            //20%
    [SerializeField] private GameObject bulletAttackSpeedUP;//10%
    [SerializeField] private GameObject collderSizeDown;    //10%
    [SerializeField] private GameObject hpPotion;           //20%
    [SerializeField] private GameObject mpPotion;           //20%


    private int powerUPPer;
    private int speedUPPer;
    private int bulletAttackSpeedUPPer;
    private int collderSizeDownPer;
    private int hpPotionPer;
    private int mpPotionPer;

    void Awake()
    {
        powerUPPer = 20;
        speedUPPer = powerUPPer + 20;
        bulletAttackSpeedUPPer = speedUPPer + 10;
        collderSizeDownPer = bulletAttackSpeedUPPer + 10;
        hpPotionPer = collderSizeDownPer + 20;
        mpPotionPer = hpPotionPer + 20;
    }

    void Start()
    {
        StartCoroutine(SpawnItem());
    }

    void Update()
    {
        
    }

    private IEnumerator SpawnItem()
    {
        while (true)
        {
            yield return new WaitForSeconds(15.0f);

            int itemType = Random.Range(1, 101);

            if (itemType <= powerUPPer) Instantiate(powerUP, Vector2.zero, Quaternion.identity);
            else if (itemType <= speedUPPer) Instantiate(speedUP, Vector2.zero, Quaternion.identity);
            else if (itemType <= bulletAttackSpeedUPPer) Instantiate(bulletAttackSpeedUP, Vector2.zero, Quaternion.identity);
            else if (itemType <= hpPotionPer) Instantiate(hpPotion, Vector2.zero, Quaternion.identity);
            else if (itemType <= mpPotionPer) Instantiate(mpPotion, Vector2.zero, Quaternion.identity);
        }
    }
}
