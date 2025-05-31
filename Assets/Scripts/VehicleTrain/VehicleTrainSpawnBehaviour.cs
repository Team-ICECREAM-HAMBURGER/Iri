using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VehicleTrainSpawnBehaviour : MonoBehaviour {
    [Header("Spawn Settings")]
    [field:SerializeField] private List<GameObject> spawnableTrain;
    [Space(10f)]
    [SerializeField] private float spawnTime;
    [SerializeField] private float spawnTimeRandomValue;
    
    private Vector3 vehicleSpawnPosition;
    private Vector3 vehicleSpawnRotation;
    private List<GameObject> spawnedTrain;
    private bool isTrainSpawned;
    
    
    private void Init() {
        PlayerBehaviour.Instance.OnPunchIn.AddListener(TrainSpawn);
        
        this.isTrainSpawned = false;
        this.spawnedTrain = new();
        this.vehicleSpawnPosition = this.spawnableTrain[0].transform.position;
        this.vehicleSpawnRotation = this.spawnableTrain[0].transform.rotation.eulerAngles;
    }
    
    private void OnTriggerEnter(Collider other) {
        this.isTrainSpawned = false;
        StartCoroutine(TrainSpawnCoroutine());
    }
    
    private void Awake() {
        Init();
    }

    private void TrainSpawn() {
        foreach (var VARIABLE in this.spawnableTrain) {
            var obj 
                = Instantiate(VARIABLE, this.vehicleSpawnPosition, Quaternion.Euler(vehicleSpawnRotation));
            
            obj.SetActive(false);
            this.spawnedTrain.Add(obj);
        }
        
        StartCoroutine(TrainSpawnCoroutine());
        
        foreach (var VARIABLE in this.spawnableTrain) {
            Destroy(VARIABLE);
        }
    }
    
    private IEnumerator TrainSpawnCoroutine() {
        if (!this.isTrainSpawned) {
            var target = SpawnTrainRandomSelect(this.spawnedTrain);
            
            yield return new WaitForSeconds(this.spawnTime 
                                            + Random.Range(-this.spawnTimeRandomValue, this.spawnTimeRandomValue));
            
            target.SetActive(true);
            this.isTrainSpawned = true;
        }
    }
    
    private GameObject SpawnTrainRandomSelect(List<GameObject> trains) {
        GameObject target;
        
        do {
            target = trains[Random.Range(0, trains.Count)];

        } while (target.activeSelf);
        
        return target;
    }
}