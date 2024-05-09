using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbSpawner : MonoBehaviour
{
    private OrbManager _orbManager;
    
    void Start()
    {
        _orbManager = GameObject.FindGameObjectWithTag("orbManager").GetComponent<OrbManager>();
    }

    void OnTriggerEnter(Collider other)
    {
        _orbManager.SpawnOrbs();
    }
}
