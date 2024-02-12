using UnityEngine;

public class Mover : MonoBehaviour
{
    private const string AnimMoveXParameter = "AnimMoveX";
    private const string HorizontalAxis = "Horizontal";

    [SerializeField] private float _speed = 5f;
    [SerializeField] private Rigidbody2D _rigibody;
    [SerializeField] private Animator _animator;

    private void Update()
    {
        Move();
        Animate();
    }

    private void Move()
    {
        float horizontal = Input.GetAxis(HorizontalAxis);
        Vector2 moveDirection = new Vector2(horizontal, 0);
        Vector2 newPosition = _rigibody.position + moveDirection.normalized * _speed * Time.deltaTime;

        _rigibody.MovePosition(newPosition);
    }

    private void Animate()
    {
        _animator.SetFloat(AnimMoveXParameter, Input.GetAxis(HorizontalAxis));
    }
}