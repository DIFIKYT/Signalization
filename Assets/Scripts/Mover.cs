using UnityEngine;

public class Mover : MonoBehaviour
{
    private const string _animMoveXParameter = "AnimMoveX";
    private const string _horizontalAxis = "Horizontal";

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
        float horizontal = Input.GetAxis(_horizontalAxis);
        Vector2 moveDirection = new Vector2(horizontal, 0);
        Vector2 newPosition = _rigibody.position + moveDirection.normalized * _speed * Time.deltaTime;

        _rigibody.MovePosition(newPosition);
    }

    private void Animate()
    {
        _animator.SetFloat(_animMoveXParameter, Input.GetAxis(_horizontalAxis));
    }
}