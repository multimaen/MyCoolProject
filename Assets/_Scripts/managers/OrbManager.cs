using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbManager : MonoBehaviour
{
    private List<Transform> _orbsInScene = new List<Transform>();

    [SerializeField] private GameObject _prefab;
    [SerializeField] private int _orbMaxCount = 3;

    public Vector3 FindPosition() {
        return new Vector3(Random.Range(-8,8), 0, Random.Range(-4.5f, 4.5f));
    }

    public void SpawnOrbs() {
        for (int i = 0; i < _orbMaxCount; i++) {
            if (_orbsInScene.Count < _orbMaxCount) {
                GameObject instance = Instantiate(_prefab, FindPosition(), Quaternion.identity);
                _orbsInScene.Add(instance.transform);
            }
        }
    }

    public void NotifyDestroy(Transform t) {
        if (_orbsInScene.Count > 0) {
            _orbsInScene.Remove(t);
            Debug.Log("destroyed" + t.name);
        }
    }
}
