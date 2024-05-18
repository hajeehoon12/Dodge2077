public enum StatsChangeType
{
    Add,            // 0, ������ �����ִ� ��
    Multiple,       // 1, ������ �����ִ� ��
    Override,       // 2, ������ �������ִ� ��
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