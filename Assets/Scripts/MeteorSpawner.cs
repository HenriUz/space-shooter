using System.Collections.Generic;
using UnityEngine;

public class MeteorSpawner : MonoBehaviour {
    private List<Transform> _spawnPoints;
    [SerializeField] private List<GameObject> meteorsPrefabs;
    
    private void Awake() {
        _spawnPoints = new List<Transform>();
        foreach (Transform child in transform) {
            _spawnPoints.Add(child);
        }
    }

    private void Start() {
        InvokeRepeating(nameof(SpawnMeteor), 0, 1);
    }
    
    private void SpawnMeteor() {
        var spawnPosition = Random.Range(0, _spawnPoints.Count);
        var prefabs = Random.Range(0, meteorsPrefabs.Count);
        
        Instantiate(meteorsPrefabs[prefabs],  _spawnPoints[spawnPosition].position, Quaternion.identity);
    }
}
