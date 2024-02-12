using UnityEngine;

public class Doors : MonoBehaviour
{
    private const string IsOpenParameter = "IsOpen";
    private const string CloseParameter = "Close";
    private const string OpenParameter = "Open";

    [SerializeField] private Animator _animator;

    private bool _hasCrook = false;
     
    public bool HasCrook => _hasCrook;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Crook>())
            _hasCrook = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.GetComponent<Crook>())
            _hasCrook = false;
    }

    public void Open()
    {
        _animator.SetBool(CloseParameter, false);
        _animator.SetBool(OpenParameter, true);
        _animator.SetBool(IsOpenParameter, true);
    }

    public void Close()
    {
        _animator.SetBool(OpenParameter, false);
        _animator.SetBool(CloseParameter, true);
        _animator.SetBool(IsOpenParameter, false);
    }

    public void OpenOrCloseDoor()
    {
        if (_hasCrook == true)
            Open();
        else if (_hasCrook == false)
            Close();
    }
}