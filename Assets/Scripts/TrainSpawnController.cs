using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;
using Random = UnityEngine.Random;

public class TrainSpawnController : MonoBehaviour {
    private List<GameObject> trains;

    [HideInInspector] public UnityEvent OnTransformReset;
    
    
    private void Init() {
        this.trains = this.transform.Cast<Transform>().Select(child => { child.gameObject.SetActive(false); return child.gameObject; }).ToList();
    }

    private void Awake() {
        Init();
    }

    private void OnTriggerEnter(Collider other) {
        if (other.transform.CompareTag(this.gameObject.tag)) {
            TrainTransformReset(other.transform.parent.gameObject);
        }
    }

    private void TrainTransformReset(GameObject train) {
        this.OnTransformReset.Invoke();
        train.SetActive(false);
    }
    
    private GameObject TrainRandomSelect(List<GameObject> trains) {
        var index = Random.Range(0, trains.Count);
        
        return trains[index];
    }
}