using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereSpawner : MonoBehaviour
{
    [SerializeField] private GameObject _prefab;

    void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            var spawnObject = Instantiate(_prefab);
            spawnObject.transform.position = new Vector3(Random.Range(-20, 20), 20, 80);
        }
    }
}
