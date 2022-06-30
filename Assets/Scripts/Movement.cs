using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] private float _speed;

    private int _distance = 50;

    void Update()
    {
        Vector3 target = new Vector3(transform.position.x + _distance, transform.position.y, transform.position.z);

        transform.position = Vector3.MoveTowards(transform.position, target, _speed * Time.deltaTime);
    }
}
