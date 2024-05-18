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
    public float maxHP;         //�ִ� ü��
    public float speed;         //�̵� �ӵ�
    public float damage;        //���ݷ�
    public int penetration;     //�����
    public float bulletSpeed;   //�Ѿ� ���ǵ�
}