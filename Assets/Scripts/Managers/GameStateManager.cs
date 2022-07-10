using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum GameState
{
    Ready,
    Running,
    Finished,
}

public class GameStateManager : MonoBehaviour
{
    public GameState State { get; private set; }


    public void PrepareGame()
    {
        Time.timeScale = 0f;
        State = GameState.Ready;
    }

    public void StartGame()
    {
        Time.timeScale = 1f;
        State = GameState.Running;
    }

    public void GameOver()
    {
        Time.timeScale = 0f;
        State = GameState.Finished;
    }

    public void RestartGame()
    {
        Time.timeScale = 1f;
        State = GameState.Ready;

        SceneManager.LoadScene("Scenes/Main");
    }

    public void QuitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }

    private void Start()
    {
        PrepareGame();
    }

    private void Update()
    {
        switch (State)
        {
            case GameState.Ready:
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    StartGame();
                }
                break;
            case GameState.Running:
                break;
            case GameState.Finished:
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    RestartGame();
                }

                if (Input.GetKeyDown(KeyCode.Escape))
                {
                    QuitGame();
                }
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }
    }
}
