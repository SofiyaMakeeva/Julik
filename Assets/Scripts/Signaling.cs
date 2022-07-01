using System.Collections;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class Signaling : MonoBehaviour
{
    [SerializeField] private float _duration;

    private float _minVolume = 0;
    private float _maxVolume = 1;
    private Coroutine _alarm;
    private AudioSource _audioSource;

    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
        _audioSource.volume = _minVolume;
    }

    public void Activate(bool isReached)
    {
        if (isReached)
        {
            ActivateAlarm(_maxVolume);

            _audioSource.Play();   
        }
        else
        {
            ActivateAlarm(_minVolume);

            if (_audioSource.volume == 0)
            {
                _audioSource.Stop();
            }
        }
    }

    private void ActivateAlarm(float volume)
    {
        if (_alarm != null)
        {
            StopCoroutine(_alarm);
        }
        _alarm = StartCoroutine(ChangeVolume(volume));

        StartCoroutine(ChangeVolume(volume));
    }

    private IEnumerator ChangeVolume(float volume)
    {
        while (_audioSource.volume != volume)
        {
            _audioSource.volume = Mathf.MoveTowards(_audioSource.volume, volume, _duration * Time.deltaTime);

            yield return null;
        }  
    }
}
