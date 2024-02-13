using System.Collections;
using UnityEngine;

public class Signalization : MonoBehaviour
{
    [SerializeField] private float _speed = 0.1f;
    [SerializeField] private AudioSource _audioSource;

    private int _minVolume = 0;
    private int _maxVolume = 1;
    private Coroutine _adjustVolumeCoroutine;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Crook>())
        {
            _audioSource.Play();

            if (_adjustVolumeCoroutine != null)
                StopCoroutine(_adjustVolumeCoroutine);

            _adjustVolumeCoroutine = StartCoroutine(AdjustVolumeCoroutine(_maxVolume));
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.GetComponent<Crook>())
        {
            if (_adjustVolumeCoroutine != null)
                StopCoroutine(_adjustVolumeCoroutine);

            _adjustVolumeCoroutine = StartCoroutine(AdjustVolumeCoroutine(_minVolume));
        }
    }

    private IEnumerator AdjustVolumeCoroutine(int targetVolume)
    {
        while (_audioSource.volume != targetVolume)
        {
            _audioSource.volume = Mathf.MoveTowards(_audioSource.volume, targetVolume, _speed * Time.deltaTime);

            if (_audioSource.volume == 0)
                _audioSource.Stop();

            yield return null;
        }
    }
}