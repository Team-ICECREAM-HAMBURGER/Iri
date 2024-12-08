using System.Collections.Generic;
using UnityEngine;

public class GameControlObjectPoolingController : MonoBehaviour {
    private class PoolingObject {
        public GameObject prefab;
        public bool isActive;
    }
    
    private Stack<PoolingObject> objectPoolStack;

    [SerializeField] private GameObject objectPrefab;
    
    [Space(10f)]
    
    [SerializeField] private bool collectionCheck;
    [SerializeField] private int poolStackCapacity;
    [SerializeField] private int maxCapacity;
    [SerializeField] private int increaseCapacity;

    private int activeCount;
    
    
    private void Init() {
        this.objectPoolStack = new();
        AddPoolItem();
    }
    
    private void Awake() {
        Init();
    }

    private GameObject GetPooledObject() {    // Object Active
        if (this.objectPoolStack == null) {
            return null;
        }

        if (this.maxCapacity == this.activeCount) {
            AddPoolItem();
        }

        foreach (var VARIABLE in this.objectPoolStack) {
            if (!VARIABLE.isActive) {
                VARIABLE.isActive = true;
                VARIABLE.prefab.SetActive(true);
                this.activeCount++;

                return VARIABLE.prefab;
            }
        }

        return null;
    }

    private void ReturnToPoolStack(GameObject targetObject) {   // Object DeActive
        if (this.objectPoolStack == null) {
            return;
        }

        foreach (var VARIABLE in this.objectPoolStack) {
            if (VARIABLE.prefab == targetObject) {
                VARIABLE.prefab.SetActive(false);
                VARIABLE.isActive = false;
                this.activeCount--;

                return;
            }
        }
    }

    private void AddPoolItem() {
        this.maxCapacity += this.increaseCapacity;

        for (var i = 0; i < this.increaseCapacity; i++) {
            var objectInstance = new PoolingObject {
                prefab = GameObject.Instantiate(this.objectPrefab)
            };
            
            objectInstance.prefab.SetActive(false);
            objectInstance.isActive = false;
            
            this.objectPoolStack.Push(objectInstance);
        }
    }
}