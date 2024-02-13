using System.Collections;
using UnityEngine;

public class Sound : MonoBehaviour
{
    [SerializeField] private float _speed = 0.1f;
    [SerializeField] private AudioSource _audioSource;

    private int _minVolume = 0;
    private int _maxVolume = 1;
    private Coroutine _adjustVolumeCoroutine;

    public void TurnSound()
    {
        _audioSource.Play();
        AdjustVolume(_maxVolume);
    }

    public void TurnOffSound()
    {
        AdjustVolume(_minVolume);
    }

    private IEnumerator AdjustVolumeCoroutine(int targetVolume)
    {
        while (_audioSource.volume != targetVolume)
        {
            _audioSource.volume = Mathf.MoveTowards(_audioSource.volume, targetVolume, _speed * Time.deltaTime);

            yield return null;
        }

        if (_audioSource.volume < _minVolume)
            _audioSource.Stop();
    }

    private void AdjustVolume(int targetVolume)
    {
        if (_adjustVolumeCoroutine != null)
            StopCoroutine(_adjustVolumeCoroutine);

        _adjustVolumeCoroutine = StartCoroutine(AdjustVolumeCoroutine(targetVolume));
    }
}