using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ClickPointRunAgent : MonoBehaviour
{
    [SerializeField] private UnityEngine.AI.NavMeshAgent _agent;
    // Start is called before the first frame update
    void Start()
    {
        if (_agent == null) {
            _agent = GetComponent<NavMeshAgent>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0)) {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit)) {
                _agent.SetDestination(hit.point);
            }
        }
    }
}
