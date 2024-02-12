using UnityEngine;

public class Home : MonoBehaviour
{
    [SerializeField] private Doors _doors;
    [SerializeField] private Sound _sound;

    private void Update()
    {
        _doors.OpenOrCloseDoor();
        _sound.IncreaseOrDecreaseVolume();
    }
}