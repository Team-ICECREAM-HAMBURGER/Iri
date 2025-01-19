using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Random = UnityEngine.Random;

public class TrainSpawnManager : MonoBehaviour {
    [HideInInspector] public UnityEvent<string> OnTransformReset;
    [HideInInspector] public UnityEvent<GameObject, float, float> OnTrainRespawn;
    
    [SerializeField] private GameSaveDataManager gameSaveDataManager;
    [SerializeField] private PlayerController playerController;
    
    [Space(10f)]
    
    [SerializeField] private List<GameObject> trains;
    
    private List<GameObject> spawnTrains;
    
    
    private void Init() {
        this.spawnTrains = new();
        
        this.playerController.OnPunchIn.AddListener(InitTrainSpawn);
        this.OnTrainRespawn.AddListener(TrainRespawn);
    }

    private void InitTrainSpawn() {
        foreach (var VARIABLE in this.gameSaveDataManager.HeadChapterData.vehicleTypes) {
            this.spawnTrains.Add(this.trains[(int)VARIABLE]);
            StartCoroutine(TrainSpawnCoroutine(this.spawnTrains[(int)VARIABLE]));
        }
    }
    
    private void Awake() {
        Init();
    }

    private void TrainRespawn(GameObject train, float spawnTime, float spawnTimeMargin) {
        TrainTransformReset(train);
        StartCoroutine(TrainSpawnCoroutine(
            RespawnTrainRandomSelect(this.spawnTrains), spawnTime, spawnTimeMargin));
    }
    
    private void TrainTransformReset(GameObject train) {
        this.OnTransformReset.Invoke(train.tag);
        train.SetActive(false);
    }
    
    private GameObject RespawnTrainRandomSelect(List<GameObject> trains) {
        var index = Random.Range(0, trains.Count);
        
        while (trains[index].activeSelf) {
            index = Random.Range(0, trains.Count);
        }
        
        return trains[index];
    }
    
    private IEnumerator TrainSpawnCoroutine(GameObject train, float spawnTime = 0f, float spawnTimeMargin = 5f) { 
        yield return new WaitForSeconds(spawnTime + Random.Range(-spawnTimeMargin, spawnTimeMargin));
        train.SetActive(true);
    }
}