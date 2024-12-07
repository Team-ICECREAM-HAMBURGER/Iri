using UnityEngine;
using UnityEngine.EventSystems;

public class GameControlDragDropController : GameControlPointerManager {
    [Space(10f)]
    [SerializeField] private CanvasGroup canvasGroup;
    
    
    public override void OnPointerDown(PointerEventData eventData) {
        transform.SetAsLastSibling();
    }
    
    public override void OnBeginDrag(PointerEventData eventData) {
        if (this.canvasGroup != null) {
            this.canvasGroup.blocksRaycasts = false;
        }
    }

    public override void OnDrag(PointerEventData eventData) {
        this.targetRectTransform.anchoredPosition += (eventData.delta / this.targetCanvas.scaleFactor);
    }
    
    public override void OnEndDrag(PointerEventData eventData) {
        if (this.canvasGroup != null) {
            this.canvasGroup.blocksRaycasts = true;
        }
    }
}