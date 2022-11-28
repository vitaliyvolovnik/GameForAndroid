using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class SnakeHead : MonoBehaviour
{

    private Rigidbody2D _rigidbody2D;

    private void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }
    public void Move(Vector3 newPosition)
    {
        _rigidbody2D.MovePosition(newPosition);
    }


    private void OnCollisionState2D(Collision2D other)
    {
        if (other.gameObject.TryGetComponent(out Block block))
            block.Fill();
    }
}
