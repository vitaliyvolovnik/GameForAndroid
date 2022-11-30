using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class Snake : MonoBehaviour
{

    [SerializeField] private SnakeHead _head;
    [SerializeField] private float _speed;
    [SerializeField] private float _tailSpringness;
    [SerializeField] private int _tailSize;

    private TailGenerator _tailGenerator;
    private SnakeInput _snakeInput;
    private List<Segment> _tail;

    public event UnityAction<int> SizeUpdate;

    void Start()
    {
        _tailGenerator = GetComponent<TailGenerator>();
        _snakeInput = GetComponent<SnakeInput>();

        _tail = _tailGenerator.Generate(_tailSize);
        SizeUpdate?.Invoke(_tail.Count);
    }
    private void OnEnable()
    {
        _head.BlockCollided += OnBlockCollided;
        _head.PickUpBonus += OnPickUpBonus;
    }
    private void OnDisable()
    {
        _head.BlockCollided -= OnBlockCollided;
        _head.PickUpBonus -= OnPickUpBonus;
    }
    void FixedUpdate()
    {
        Move(_head.transform.position + _head.transform.up * (_speed * Time.fixedDeltaTime));
        _head.transform.up = _snakeInput.getDirectionToClick(_head.transform.position);
    }

    private void Move(Vector3 nextPosition)
    {
        var previosPosition = _head.transform.position;
        Vector3 tempPosition;
        foreach (var tailSigment in _tail)
        {
            tempPosition = tailSigment.transform.position;


            tailSigment.transform.position = Vector2.Lerp(tailSigment.transform.position, previosPosition, _tailSpringness * Time.fixedDeltaTime);

            previosPosition = tempPosition;

        }
        _head.Move(nextPosition);
    }

    private void OnBlockCollided()
    {
        var deletedSegment = _tail[^1];
        _tail.Remove(deletedSegment);
        Destroy(deletedSegment.gameObject);
        SizeUpdate?.Invoke(_tail.Count);
    }

    private void OnPickUpBonus(int bonusVakue)
    {
        _tail.AddRange(_tailGenerator.Generate(bonusVakue));


        SizeUpdate?.Invoke(_tail.Count);
    }

}
