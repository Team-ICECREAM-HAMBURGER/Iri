using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;
using Random = UnityEngine.Random;

public class TrainSpawnController : MonoBehaviour {
    [HideInInspector] public UnityEvent OnTransformReset;
    
    [field: SerializeField] public float SpawnTimeNormal { get; set; }
    [SerializeField] private float marginTime;
    
    private List<GameObject> trains;
    
    
    private void Init() {
        this.trains = this.transform.Cast<Transform>().Select(child => child.gameObject).ToList();
    }

    private void Awake() {
        Init();
    }

    private void OnTriggerEnter(Collider other) {
        if (other.transform.CompareTag(this.gameObject.tag)) {
            TrainTransformReset(other.transform.parent.gameObject);
            StartCoroutine(TrainRespawnCoroutine(TrainRandomSelect(this.trains)));
        }
    }

    private void TrainTransformReset(GameObject train) {
        this.OnTransformReset.Invoke();
        train.SetActive(false);
    }
    
    private GameObject TrainRandomSelect(List<GameObject> trains) {
        var index = Random.Range(0, trains.Count);
        
        while (trains[index].activeSelf) {
            index = Random.Range(0, trains.Count);
        }
        
        return trains[index];
    }

    private IEnumerator TrainRespawnCoroutine(GameObject train) {
        yield return new WaitForSeconds(this.SpawnTimeNormal + Random.Range(-this.marginTime, this.marginTime));
        
        train.SetActive(true);
    }
}