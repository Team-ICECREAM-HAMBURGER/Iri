using UnityEngine;

public class GameCamChanger : MonoBehaviour {
    [SerializeField] private Camera[] cameras;

    private int index;


    private void Init() {
        this.index = 0;
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
    }
}
