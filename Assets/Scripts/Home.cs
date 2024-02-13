using UnityEngine;

public class Home : MonoBehaviour
{
    [SerializeField] private Sound _singalization;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Crook>())
            _singalization.TurnSound();
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.GetComponent<Crook>())
            _singalization.TurnOffSound();
    }
}