using System.Collections;
using UnityEngine;

public class Sound : MonoBehaviour
{
    [SerializeField] private float _speed = 0.1f;
    [SerializeField] private float _delay = 1f;
    [SerializeField] private AudioSource _audioSource;

    private int _minVolume = 0;
    private int _maxVolume = 1;
    private bool _hasCrook = false;

    public bool HasCrook => _hasCrook;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Crook>())
        {
            _hasCrook = true;
            _audioSource.Play();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.GetComponent<Crook>())
            _hasCrook = false;
    }

    private IEnumerator IncreaseVolumeCoroutine()
    {
        while (_audioSource.volume < _maxVolume)
        {
            _audioSource.volume = Mathf.MoveTowards(_audioSource.volume, _maxVolume, _speed * Time.deltaTime);

            yield return new WaitForSeconds(_delay);
        }
    }

    private IEnumerator DecreaseVolumeCoroutine()
    {
        while (_audioSource.volume > _minVolume)
        {
            _audioSource.volume = Mathf.MoveTowards(_audioSource.volume, _minVolume, _speed * Time.deltaTime);

            yield return new WaitForSeconds(_delay);
        }

        _audioSource.Stop();
    }

    public void IncreaseOrDecreaseVolume()
    {
        if (_hasCrook)
            StartCoroutine(IncreaseVolumeCoroutine());
        else if (_hasCrook == false)
            StartCoroutine(DecreaseVolumeCoroutine());
    }
}