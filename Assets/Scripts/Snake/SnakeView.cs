using TMPro;
using UnityEngine;

[RequireComponent(typeof(Snake))]
public class SnakeView : MonoBehaviour
{
    [SerializeField] private TMP_Text _view;

    private Snake _snake;
    

    private void Awake() => _snake = GetComponent<Snake>();
    private void OnEnable() => _snake.SizeUpdate += OnSizeUpdate;
    private void OnDisable() => _snake.SizeUpdate -= OnSizeUpdate;
    private void OnSizeUpdate(int update) => _view.text = update.ToString();

}
