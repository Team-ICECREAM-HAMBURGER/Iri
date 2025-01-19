using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class GameCamChanger : MonoBehaviour {
    [SerializeField] private Camera[] cameras;

    [Space(10f)] 
    
    [SerializeField] private List<Canvas> flipTargetCanvases;
    [SerializeField] private Vector3 targetCanvasFlipPreset;
    
    private int index;
    private bool isFlipped;
    private List<Vector3> targetCanvasOriginalPresets;
    

    private void Init() {
        this.index = 0;
        this.isFlipped = false;
        this.targetCanvasOriginalPresets = new List<Vector3>();

        foreach (var VARIABLE in this.flipTargetCanvases) {
            this.targetCanvasOriginalPresets.Add(VARIABLE.transform.rotation.eulerAngles);
        }
    }

    private void Awake() {
        Init();
    }

    public void OnClick() {
        this.cameras[this.index].gameObject.SetActive(false);
        this.index += 1;
        
        if (this.index >= this.cameras.Length) {
            this.index = 0;
        }
        
        this.cameras[this.index].gameObject.SetActive(true);
        
        if (this.isFlipped) {
            this.isFlipped = false;
            var i = 0;

            foreach (var VARIABLE in this.flipTargetCanvases) {
                VARIABLE.transform.rotation = Quaternion.Euler(this.targetCanvasOriginalPresets[i]);
                i++;
            }
        }
        else {
            this.isFlipped = true;        
            
            foreach (var VARIABLE in this.flipTargetCanvases) {
                VARIABLE.transform.rotation = Quaternion.Euler(this.targetCanvasFlipPreset);
            }
        }
    }
}
