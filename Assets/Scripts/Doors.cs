using UnityEngine;

public class Doors : MonoBehaviour
{
    private const string IsOpenParameter = "IsOpen";
    private const string CloseParameter = "Close";
    private const string OpenParameter = "Open";

    [SerializeField] private Animator _animator;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Crook>())
            Open();
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.GetComponent<Crook>())
            Close();
    }

    private void Open()
    {
        _animator.SetBool(CloseParameter, false);
        _animator.SetBool(OpenParameter, true);
        _animator.SetBool(IsOpenParameter, true);
    }
     
    private void Close()
    {
        _animator.SetBool(OpenParameter, false);
        _animator.SetBool(CloseParameter, true);
        _animator.SetBool(IsOpenParameter, false);
    }
}