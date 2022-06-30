using System.Collections;
using UnityEngine;

public class Signaling : MonoBehaviour
{
    private Volume _volume;
    public bool IsThiefInTheHouse { get; private set; }

    private void Start()
    {
        _volume = GetComponent<Volume>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<Thief>(out Thief thief))
        {
            IsThiefInTheHouse = true;
            
            StartCoroutine(_volume.ChangeVolume(IsThiefInTheHouse));
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent<Thief>(out Thief thief))
        {
            IsThiefInTheHouse = false;

            StartCoroutine(_volume.ChangeVolume(IsThiefInTheHouse));
        }
    }
}
