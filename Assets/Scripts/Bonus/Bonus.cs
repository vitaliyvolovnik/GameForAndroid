using UnityEngine;
using TMPro;

public class Bonus : MonoBehaviour
{
    [SerializeField] private Vector2Int _bonusSizeRange;
    [SerializeField] private TMP_Text _view;

    private int _bonusSize;

    private void Start()
    {
        _bonusSize = Random.Range(_bonusSizeRange.x, _bonusSizeRange.y);

        _view.text = _bonusSize.ToString();
    }
    public int PickUp()
    {
        Destroy(gameObject);
        return _bonusSize;
    }
}
