using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickPointRun : MonoBehaviour
{
    private Transform _transform;
    private Vector3 _destination;
    bool _isMoving = false;
    [SerializeField] private float _speed = 3;

    // Start is called before the first frame update
    void Start()
    {
        _transform = transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0)) {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit)) {
                _destination = hit.point;
                _isMoving = true;
            }
        }

        if (Vector3.Distance(_transform.position, _destination) < .1f) {
            _isMoving = false;
        }
        
        if (_isMoving) {
            _transform.position = Vector3.Lerp(_transform.position, _destination, _speed * Time.deltaTime);
        }
    }
}
