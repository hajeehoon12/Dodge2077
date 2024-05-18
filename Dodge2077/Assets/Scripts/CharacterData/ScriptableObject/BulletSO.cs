using UnityEngine;

[CreateAssetMenu(fileName = "DefaultBulletSO", menuName = "Dodge2077/Bullets/Default", order = 0)]
public class BulletSO : ScriptableObject
{
    [Header("Bullet Info")]
    public float penetration;
    public float speed;
}