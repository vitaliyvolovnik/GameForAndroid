using UnityEngine;
using UnityEngine.Events;

public class Block : MonoBehaviour
{
    [SerializeField] private Vector2Int _destroyPriceRange;

    private int _destroyPrice = 0;
    private int _filling;
    private int LeftToFild => _destroyPrice - _filling;

    public event UnityAction<int> FillingProgress;


    private void Start()
    {
        _destroyPrice = Random.Range(_destroyPriceRange.x, _destroyPriceRange.y);
        FillingProgress?.Invoke(LeftToFild);
    }

    public void Fill()
    {
        _filling++;
        FillingProgress?.Invoke(LeftToFild);
        if (_filling == _destroyPrice) Destroy(gameObject);

    }
}
