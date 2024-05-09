using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowOnCollision : MonoBehaviour
{
    private Transform _transform;
    private Transform _destination;
    private bool _isMoving = false;

    [SerializeField] private float _speed = 2;

    // Start is called before the first frame update
    void Start()
    {
        _transform = transform;
    }

    void OnCollisionEnter(Collision other)
    {
        if (_isMoving) {
            _isMoving = false;
        } else if (!_isMoving) {
            _isMoving = true;
            _destination = other.transform;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if ( _isMoving ) {
            _transform.position = Vector3.Lerp(_transform.position, _destination.position, _speed * Time.deltaTime);
        }
    }
}
