using System.Collections;
using UnityEngine;

public class Volume : MonoBehaviour
{
    [SerializeField] private float _duration;

    private float _minVolume = 0;
    private float _maxVolume = 1;
    private float _durationRunning;
    private AudioSource _audioSource;

    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
        _audioSource.volume = _minVolume;
    }

    public IEnumerator ChangeVolume(bool isReached)
    {
        if (isReached)
        {
            _audioSource.Play();

            while (_audioSource.volume < 1)
            {
                ChangeVolume(_minVolume, _maxVolume);

                if (_audioSource.volume == 1)
                {
                    _durationRunning = 0;
                }

                yield return null;
            }
        }
        else if (!isReached)
        {
            while (_audioSource.volume > 0)
            {
                ChangeVolume(_maxVolume, _minVolume);

                if (_audioSource.volume == 0)
                {
                    _durationRunning = 0;
                    _audioSource.Stop();
                }

                yield return null;
            }
        }
    }

    private void ChangeVolume(float initialVolume, float endVolume)
    {
        _durationRunning += Time.deltaTime;
        _audioSource.volume = Mathf.MoveTowards(initialVolume, endVolume, _durationRunning / _duration);
    }
}
