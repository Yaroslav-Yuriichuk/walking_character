using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppleSpawner : MonoBehaviour
{

    [SerializeField] private GameObject _applePrefab;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnApple", 3f, 7f);
    }

    private void SpawnApple()
    {
        GameObject go = Instantiate(_applePrefab,
            new Vector3(Random.Range(-20f, 20f), 8f, Random.Range(-20f, 20f)),
            Quaternion.identity);
        go.transform.parent = gameObject.transform;
    }
}
