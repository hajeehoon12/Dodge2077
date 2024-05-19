public enum StatsChangeType
{
    Override,       // 0, ������ �������ִ� ��
    Add,            // 1, ������ �����ִ� ��
    Multiple,       // 2, ������ �����ִ� ��
}

[System.Serializable]

public class CharacterStat
{
    public StatsChangeType statsChangeType;
    public float MaxHP;         //�ִ� ü��
    public float MoveSpeed;     //�̵� �ӵ�
    public float Damage;        //���ݷ�
    public int Penetration;     //�����
    public float BulletSpeed;   //�Ѿ� ���ǵ�
}