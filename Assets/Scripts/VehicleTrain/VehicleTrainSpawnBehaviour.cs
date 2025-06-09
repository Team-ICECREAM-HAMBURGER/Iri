using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VehicleTrainSpawnBehaviour : MonoBehaviour {
    [field:SerializeField] private List<GameObject> spawnPrefabs;
    [SerializeField] private float spawnTime;
    [SerializeField] private float spawnTimeRandomValue;
    
    private Vector3 vehicleSpawnPosition;
    private Vector3 vehicleSpawnRotation;
    private List<GameObject> spawnTrain;
    
    
    private void Init() {
        PlayerBehaviour.Instance.OnPunchIn.AddListener(TrainSpawn);
        
        this.spawnTrain = new();
        this.vehicleSpawnPosition = this.spawnPrefabs[0].transform.position;
        this.vehicleSpawnRotation = this.spawnPrefabs[0].transform.rotation.eulerAngles;
    }
    
    private void OnTriggerEnter(Collider other) {
        other.gameObject.SetActive(false);
        StartCoroutine(TrainSpawnCoroutine());
    }
    
    private void Awake() {
        Init();
    }

    private void TrainSpawn() {
        foreach (var VARIABLE in this.spawnPrefabs) {
            var obj 
                = Instantiate(VARIABLE, this.vehicleSpawnPosition, Quaternion.Euler(vehicleSpawnRotation));
            
            obj.SetActive(false);
            this.spawnTrain.Add(obj);
        }
        
        StartCoroutine(TrainSpawnCoroutine());
        
        foreach (var VARIABLE in this.spawnPrefabs) {
            Destroy(VARIABLE);
        }
    }
    
    private IEnumerator TrainSpawnCoroutine() {
        var target = SpawnTrainRandomSelect(this.spawnTrain);
        target.transform.position = this.vehicleSpawnPosition;

        yield return new WaitForSeconds(
            this.spawnTime + Random.Range(-this.spawnTimeRandomValue, this.spawnTimeRandomValue));
            
        target.SetActive(true);
    }
    
    private GameObject SpawnTrainRandomSelect(List<GameObject> trains) {
        GameObject target;
        
        do {
            target = trains[Random.Range(0, trains.Count)];

        } while (target.activeSelf);
        
        return target;
    }
}