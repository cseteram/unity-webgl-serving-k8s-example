[System.Serializable]
public class PlayerData
{
    private float _normalSpeed;
    private float _slowSpeed;

    public float NormalSpeed => _normalSpeed;
    public float SlowSpeed => _slowSpeed;
    
    public PlayerData(float normalSpeed, float slowSpeed)
    {
        _normalSpeed = normalSpeed;
        _slowSpeed = slowSpeed;
    }
}
