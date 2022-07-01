using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Signaling))]
public class Detector : MonoBehaviour
{
    private Signaling _signaling;
    private bool _isThiefInTheHouse;

    private void Start()
    {
        _signaling = GetComponent<Signaling>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<Thief>(out Thief thief))
        {
            _isThiefInTheHouse = true;

            _signaling.Activate(_isThiefInTheHouse);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent<Thief>(out Thief thief))
        {
            _isThiefInTheHouse = false;

            _signaling.Activate(_isThiefInTheHouse);
        }
    }
}
