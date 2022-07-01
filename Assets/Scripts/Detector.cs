using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Signaling))]
public class Detector : MonoBehaviour
{
    private Signaling _volume;
    private bool _isThiefInTheHouse;

    private void Start()
    {
        _volume = GetComponent<Signaling>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<Thief>(out Thief thief))
        {
            _isThiefInTheHouse = true;
            
            StartCoroutine(_volume.PlayTheAlarm(_isThiefInTheHouse));
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent<Thief>(out Thief thief))
        {
            _isThiefInTheHouse = false;

            StartCoroutine(_volume.PlayTheAlarm(_isThiefInTheHouse));
        }
    }
}
