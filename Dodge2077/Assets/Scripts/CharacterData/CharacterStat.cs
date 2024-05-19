public enum StatsChangeType
{
    Override,       // 0, 스탯을 덧씌워주는 것
    Add,            // 1, 스탯을 더해주는 것
    Multiple,       // 2, 스탯을 곱해주는 것
}

[System.Serializable]

public class CharacterStat
{
    public StatsChangeType statsChangeType;
    public float MaxHP;         //최대 체력
    public float MoveSpeed;     //이동 속도
    public float Damage;        //공격력
    public int Penetration;     //관통력
    public float BulletSpeed;   //총알 스피드
}