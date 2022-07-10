using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    [SerializeField] private BoundaryData _boundaryData;
    
    private PlayerData _playerData;

    private void Start()
    {
        _playerData = new PlayerData(25f, 10f);
    }

    public void HandleInput(float hValue, float vValue, bool isLeftShiftPressed)
    {
        var speed = isLeftShiftPressed ? _playerData.SlowSpeed : _playerData.NormalSpeed;

        var position = transform.position;
        var posX = position.x + speed * hValue * Time.deltaTime;
        var posY = position.y + speed * vValue * Time.deltaTime;
        position = new Vector3(
            Mathf.Clamp(posX, _boundaryData.xMin, _boundaryData.xMax),
            Mathf.Clamp(posY, _boundaryData.yMin, _boundaryData.yMax),
            0f
        );

        transform.position = position;
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        Debug.Log("Game Over!");
        GameManager.Instance.GameStateManager.GameOver();
    }
}
