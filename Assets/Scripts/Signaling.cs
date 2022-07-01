using System.Collections;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class Signaling : MonoBehaviour
{
    [SerializeField] private float _duration;

    private AudioSource _audioSource;

    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
        _audioSource.volume = 0;
    }

    public IEnumerator PlayTheAlarm(bool isReached)
    {
        if (isReached)
        {
            _audioSource.Play();
        }

        float endVolume = System.Convert.ToSingle(isReached);

        while (_audioSource.volume != endVolume)
        {
            ChangeVolume(endVolume);

            yield return null;
        }  
    }

    private void ChangeVolume(float endVolume)
    {
        _audioSource.volume = Mathf.MoveTowards(_audioSource.volume, endVolume, _duration * Time.deltaTime);

        if (_audioSource.volume == 0)
        {
            _audioSource.Stop();
        }
    }
}
