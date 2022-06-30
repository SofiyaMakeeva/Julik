using System.Collections;
using UnityEngine;

public class Signaling : MonoBehaviour
{
    private Volume _volume;
    private bool _isThiefInTheHouse;

    private void Start()
    {
        _volume = GetComponent<Volume>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<Thief>(out Thief thief))
        {
            _isThiefInTheHouse = true;
            
            StartCoroutine(_volume.ChangeVolume(_isThiefInTheHouse));
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent<Thief>(out Thief thief))
        {
            _isThiefInTheHouse = false;

            StartCoroutine(_volume.ChangeVolume(_isThiefInTheHouse));
        }
    }
}
