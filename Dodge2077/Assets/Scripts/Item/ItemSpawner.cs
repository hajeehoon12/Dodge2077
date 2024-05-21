using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawner : MonoBehaviour
{

    [SerializeField] private GameObject powerUP;            //30%
    [SerializeField] private GameObject speedUP;            //30%
    [SerializeField] private GameObject bulletAttackSpeedUP;//15%
    [SerializeField] private GameObject collderSizeDown;    //25%

    private int powerUPPer;
    private int speedUPPer;
    private int bulletAttackSpeedUPPer;
    private int collderSizeDownPer;

    void Awake()
    {
        powerUPPer = 30;
        speedUPPer = powerUPPer + 30;
        bulletAttackSpeedUPPer = speedUPPer + 15;
        collderSizeDownPer = bulletAttackSpeedUPPer + 25;
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
            yield return new WaitForSeconds(3.0f);

            int itemType = Random.Range(1, 101);

            if (itemType <= powerUPPer) Instantiate(powerUP, Vector2.zero, Quaternion.identity);
            else if (itemType <= speedUPPer) Instantiate(speedUP, Vector2.zero, Quaternion.identity);
            else if (itemType <= bulletAttackSpeedUPPer) Instantiate(bulletAttackSpeedUP, Vector2.zero, Quaternion.identity);
            else if (itemType <= collderSizeDownPer) Instantiate(collderSizeDown, Vector2.zero, Quaternion.identity);
        }
    }
}
