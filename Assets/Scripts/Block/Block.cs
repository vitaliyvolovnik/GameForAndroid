using UnityEngine;
using UnityEngine.Events;

public class Block : MonoBehaviour
{
    [SerializeField] private Vector2Int _destroyPriceRange;
    [SerializeField] private SpriteRenderer _spriteRenderer;
    [SerializeField] private SpriteRenderer _spriteInnerBlockRenderer;

    private int _destroyPrice = 0;
    private int _filling;
    private int LeftToFild => _destroyPrice - _filling;

    public event UnityAction<int> FillingProgress;


    private void Start()
    {
        _destroyPrice = Random.Range(_destroyPriceRange.x, _destroyPriceRange.y);
        ChangeColor();
        FillingProgress?.Invoke(LeftToFild);
    }

    public void Fill()
    {
        _filling++;
        FillingProgress?.Invoke(LeftToFild);

        ChangeColor();

        if (_filling == _destroyPrice) Destroy(gameObject);

    }



    public float GetDestroyProgress()
    {
        var progress = LeftToFild - _destroyPriceRange.x;
        return (((float)progress / (_destroyPriceRange.y - _destroyPriceRange.x - 1)) > 0) ? (float)progress / (_destroyPriceRange.y - _destroyPriceRange.x - 1) : 0;
    }
    private void ChangeColor()
    {
        Color color;
        if (GetDestroyProgress() >= 0.40f)
        {
            color = new Color(1, 1f - GetDestroyProgress(), 0);
        }
        else
        {
            color = new Color(GetDestroyProgress() * 2, 1, 0);
        }
        _spriteRenderer.color = color;
        _spriteInnerBlockRenderer.color = color;
    }
}
