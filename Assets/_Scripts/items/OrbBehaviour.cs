using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbBehaviour : MonoBehaviour
{
    private OrbManager _orbManager;
    private Transform _transform;
    private Transform _destination;
    private bool _isMoving = false;

    [SerializeField] private float _speed = 2;

    // Start is called before the first frame update
    void Start()
    {
        _transform = transform;
        _orbManager = GameObject.FindGameObjectWithTag("orbManager").GetComponent<OrbManager>();
        _destination = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    void OnCollisionEnter(Collision other)
    {
        if (_isMoving) {
            _isMoving = false;
            if (other.gameObject.tag == "Player") {
                _orbManager.NotifyDestroy(_transform);
                Destroy(gameObject);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if ( _isMoving ) {
            _transform.position = Vector3.Lerp(_transform.position, _destination.position, _speed * Time.deltaTime);
        }

        if (Vector3.Distance(_transform.position, _destination.position) < 2) {
            _isMoving = true;
        }
    }
}
