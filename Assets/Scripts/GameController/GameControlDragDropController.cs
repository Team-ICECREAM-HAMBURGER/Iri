using UnityEngine;
using UnityEngine.EventSystems;

public class GameControlDragDropController : GameControlPointerManager {
    public override void OnPointerDown(PointerEventData eventData) {
        transform.SetAsLastSibling();
    }
    
    public override void OnBeginDrag(PointerEventData eventData) {
    }

    public override void OnDrag(PointerEventData eventData) {
        this.targetRectTransform.anchoredPosition = new Vector2(this.targetRectTransform.anchoredPosition.x + (eventData.delta.x / this.targetCanvas.scaleFactor), 
            this.targetRectTransform.anchoredPosition.y + (eventData.delta.y / this.targetCanvas.scaleFactor));
    }
    
    public override void OnEndDrag(PointerEventData eventData) {
    }
}