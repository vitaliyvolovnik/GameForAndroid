using UnityEngine;
using UnityEngine.UI;

public class GameStateChecker : MonoBehaviour
{
    [SerializeField] private SnakeHead _snakeHead;
    [SerializeField] private Snake _snake;
    [SerializeField] private Button _reloadButton;

    [Header("Finish")]
    [SerializeField] private FinishScreen _finishScreen;

    [Header("GameOver")]
    [SerializeField] private GameOverScreen _gameOverScreen;


    private void OnEnable()
    {
        _snakeHead.Finish += OnFinish;
        _snake.GameOver += OnGameOver;
        
    }
    public void OnDisable()
    {
        _snakeHead.Finish -= OnFinish;
        _snake.GameOver -= OnGameOver;
    }
    private void OnFinish()
    {
        _finishScreen.gameObject.SetActive(true);
        _reloadButton.interactable = true;
        _reloadButton.gameObject.SetActive(true);
    }

    private void OnGameOver()
    {
        _gameOverScreen.gameObject.SetActive(true);
        _reloadButton.interactable = true;
        _reloadButton.gameObject.SetActive(true);
        Destroy(_snakeHead);

    }


}
