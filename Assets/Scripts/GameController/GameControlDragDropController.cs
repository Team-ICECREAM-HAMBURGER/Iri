using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Serialization;

public class GameControlDragDropController : GameControlPointerManager {
    [Space(25f)]
    
    [SerializeField] private float anchorPositionMin;
    [SerializeField] private float anchorPositionMax;
    
    private float currentDelta;
    
    
    public override void OnPointerDown(PointerEventData eventData) {
    }

    public override void OnBeginDrag(PointerEventData eventData) {
    }

    public override void OnDrag(PointerEventData eventData) {
        this.currentDelta = (eventData.delta.y / this.targetCanvas.scaleFactor);
        this.targetRectTransform.anchoredPosition = new Vector2(this.targetRectTransform.anchoredPosition.x, Mathf.Clamp((this.targetRectTransform.anchoredPosition.y + this.currentDelta), this.anchorPositionMin, this.anchorPositionMax));
    }

    public override void OnEndDrag(PointerEventData eventData) {
    }
}