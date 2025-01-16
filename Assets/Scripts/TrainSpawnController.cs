using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;
using Random = UnityEngine.Random;

public class TrainSpawnController : MonoBehaviour {
    [HideInInspector] public UnityEvent OnTransformReset;
    
    [SerializeField] private GameSaveDataManager gameSaveDataManager;
    [SerializeField] private PlayerController playerController;
    
    [Space(25f)]
    
    [SerializeField] private List<GameObject> trains;
    
    [Space(10f)]
    
    [SerializeField] private float marginTime;
    [field: SerializeField] public float SpawnTimeNormal { get; set; }
    
    [Space(10f)]
    
    private List<GameControlTypeManager.vehicleType> trainTypes;
    
    
    private void Init() {
        this.trainTypes = new();
        this.playerController.OnPunchIn.AddListener(SpawnTrainSet);
    }

    private void Awake() {
        Init();
    }
    
    private void OnTriggerEnter(Collider other) {
        // TODO: 충돌 감지를 어떻게?? Box Collider 구분을 어떻게 할 것인가?
        TrainTransformReset(other.transform.parent.gameObject);
        StartCoroutine(TrainRespawnCoroutine(TrainRandomSelect(this.trains)));
    }

    private void SpawnTrainSet() {  // Game Save Data 정보를 가지고 등장하는 열차 제어 중
        this.trainTypes = this.gameSaveDataManager.HeadChapterData.vehicleType;
        StartCoroutine(TrainRespawnCoroutine(TrainRandomSelect(this.trains)));
    }
    
    private void TrainTransformReset(GameObject train) {
        this.OnTransformReset.Invoke();
        train.SetActive(false);
    }
    
    private GameObject TrainRandomSelect(List<GameObject> trains) {
        // TODO: 열차가 무조건 1대씩만 생성되는 중. 여러 대 생성 기능 복구 필요.
        var index = Random.Range(0, this.trainTypes.Count);
        
        while (trains[index].activeSelf) {
            index = Random.Range(0, this.trainTypes.Count);
        }
        
        return trains[index];
    }

    private IEnumerator TrainRespawnCoroutine(GameObject train) {
        train.SetActive(true);
        yield return new WaitForSeconds(this.SpawnTimeNormal + Random.Range(-this.marginTime, this.marginTime));
    }
}