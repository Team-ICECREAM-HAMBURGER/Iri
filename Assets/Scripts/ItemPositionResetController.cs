using UnityEngine;

public class ItemPositionResetController : MonoBehaviour {
    [SerializeField] private ItemPositionResetManager itemPositionResetManager;
    
    [Space(10f)]
    
    [SerializeField] private RectTransform targetRectTransform;
    [SerializeField] private Canvas targetCanvas;
    
    private Vector2 resetPosition;
    
    
    private void Init() {
        this.itemPositionResetManager.OnItemPositionReset.AddListener(OnItemPositionReset);
        this.resetPosition = this.targetRectTransform.anchoredPosition;
    }

    private void Awake() {
        Init();
    }

    private void OnItemPositionReset() {
        this.targetRectTransform.anchoredPosition = this.resetPosition;
    }
}