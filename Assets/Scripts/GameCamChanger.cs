using UnityEngine;

public class GameCamChanger : MonoBehaviour {
    [SerializeField] private Camera[] cameras;

    [Space(10f)] 
    
    [SerializeField] private Canvas flipTargetCanvas;
    [SerializeField] private Vector3 targetCanvasFlipPreset;
    
    private int index;
    private bool isFlipped;
    private Vector3 targetCanvasOriginalPreset;
    

    private void Init() {
        this.index = 0;
        this.isFlipped = false;
        this.targetCanvasOriginalPreset = this.flipTargetCanvas.transform.rotation.eulerAngles;
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
        
        // TODO: World UI Canvas Flip; 뒤집을 Canvas가 정말 1개로 끝인가?
        if (this.isFlipped) {
            this.isFlipped = false;
            this.flipTargetCanvas.transform.rotation = Quaternion.Euler(this.targetCanvasOriginalPreset);
        }
        else {
            this.isFlipped = true;        
            this.flipTargetCanvas.transform.rotation = Quaternion.Euler(this.targetCanvasFlipPreset);
        }
    }
}
