using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class GameControlObjectPoolingController : MonoBehaviour {
    public class PoolingObject {
        public GameObject prefab;
        public bool isActive;
    }

    private List<PoolingObject> objectPoolList;

    [SerializeField] private GameObject poolingObjectPrefab;
    [SerializeField] private Transform parentTransform;
    
    [Space(10f)]
    
    [SerializeField] private int increaseCapacity;
    [SerializeField] private int maxCapacity;
    
    private int activeCount;
    private int returnCount;
    private int currentCapacity;

    
    private void Init() {
        this.objectPoolList = new();
        AddPoolItem();
    }
    
    private void Awake() {
        Init();
    }

    public GameObject GetPooledObject() {
        if (this.objectPoolList == null) {
            return null;
        }

        if (this.currentCapacity == this.activeCount) {
            if (this.maxCapacity == this.currentCapacity) {
                ReturnToPoolStack();    // TODO: 어떻게 해야 자연스러운 연출을 유지하면서 메모리 관리를 할 것인가?
            }
            
            AddPoolItem();
        }

        foreach (var VARIABLE in this.objectPoolList) {
            if (!VARIABLE.isActive) {
                VARIABLE.isActive = true;
                VARIABLE.prefab.SetActive(true);

                this.activeCount++;
                
                return VARIABLE.prefab;
            }
        }
        
        return null;
    }

    private void ReturnToPoolStack() {
        if (this.objectPoolList == null) {
            return;
        }

        foreach (var VARIABLE in this.objectPoolList) {
            if (VARIABLE.isActive) {
                VARIABLE.prefab.SetActive(false);
                VARIABLE.isActive = false;
                
                this.activeCount--;
                this.returnCount++;
            }

            if (this.returnCount == this.increaseCapacity) {
                return;
            }
        }
    }

    private void ReturnToPoolStack(GameObject targetObject) {   // Object DeActive
        if (this.objectPoolList == null) {
            return;
        }

        foreach (var VARIABLE in this.objectPoolList) {
            if (VARIABLE.prefab == targetObject) {
                VARIABLE.prefab.SetActive(false);
                VARIABLE.isActive = false;
                
                this.activeCount--;

                return;
            }
        }
    }

    private void AddPoolItem() {
        for (var i = 0; i < this.increaseCapacity; i++) {
            var objectInstance = new PoolingObject {
                prefab = GameObject.Instantiate(this.poolingObjectPrefab, this.parentTransform)
            };
            
            objectInstance.prefab.SetActive(false);
            objectInstance.isActive = false;
            
            this.objectPoolList.Add(objectInstance);
        }
        
        this.currentCapacity += this.increaseCapacity;
    }
}