using System;
using System.Collections.Generic;
using UnityEngine;

public class GameControlCircularLinkedListController : MonoBehaviour {
    [SerializeField] private List<GameObject> objectsList;
    
    private int currentIndex;
    private int nextIndex;
    private int previousIndex;


    private void Init() {
        OnListReset();
        
        this.currentIndex = 0;
        this.nextIndex = (this.currentIndex + 1) % this.objectsList.Count;
        this.previousIndex = (this.objectsList.Count - 1);
        
        this.objectsList[this.currentIndex].SetActive(true);
    }

    private void Awake() {
        Init();
    }

    public GameObject OnNext() {
        this.previousIndex = this.currentIndex;
        this.currentIndex = nextIndex;
        this.nextIndex = ((this.currentIndex + 1) % this.objectsList.Count);

        return this.objectsList[this.currentIndex];
    }

    public GameObject OnPrevious() {
        this.nextIndex = this.currentIndex;
        this.currentIndex = previousIndex;
        this.previousIndex = ((this.currentIndex - 1 + this.objectsList.Count) % this.objectsList.Count);
        
        return this.objectsList[this.currentIndex];
    }

    public void OnListReset() {
        foreach (var VARIABLE in this.objectsList) {
            VARIABLE.SetActive(false);
        }
    }
}