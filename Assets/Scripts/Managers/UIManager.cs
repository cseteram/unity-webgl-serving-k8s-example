using System;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] private Text timeText;
    [SerializeField] private Text messageText;

    private float _elapsedTime;
    private GameStateManager _gameStateManager;

    private void Start()
    {
        _elapsedTime = 0f;
        _gameStateManager = GameManager.Instance.GameStateManager;
    }

    private void Update()
    {
        switch (_gameStateManager.State)
        {
            case GameState.Ready:
                HandleGameReady();
                break;
            case GameState.Running:
                HandleGameRunning();
                break;
            case GameState.Finished:
                HandleGameFinished();
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }
    }

    private void HandleGameReady()
    {
        timeText.text = $"00:00.00";
        messageText.text = "Press [Space] to Start";
    }

    private void HandleGameRunning()
    {
        _elapsedTime += Time.deltaTime;
        var time = TimeSpan.FromSeconds(_elapsedTime);
        timeText.text = time.ToString("mm':'ss'.'ff");
        messageText.text = "";
    }

    private void HandleGameFinished()
    {
        messageText.text = "Game Over! Press [Space] To Restart";
    }
}
