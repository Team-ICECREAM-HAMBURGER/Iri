using UnityEngine;

public class ItemInspectionReportBehaviour : MonoBehaviour {
    private Vector2 itemInitPosition;
    
    
    public void Init() {
        this.gameObject.transform.localPosition = this.itemInitPosition;
        this.gameObject.SetActive(true);
    }

    private void Awake() {
        this.itemInitPosition = this.gameObject.transform.localPosition;
        this.gameObject.SetActive(false);
    }
}