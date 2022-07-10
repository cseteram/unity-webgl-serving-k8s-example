[System.Serializable]
public class EnemyData
{
    private float _speed;

    public float Speed => _speed;

    public EnemyData(float speed)
    {
        _speed = speed;
    }
}
