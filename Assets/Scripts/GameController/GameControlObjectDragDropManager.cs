using UnityEngine;
using UnityEngine.EventSystems;

public class GameControlObjectDragDropManager : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IDragHandler, IEndDragHandler {
    [SerializeField] private RectTransform targetRectTransform;
    [SerializeField] private Canvas targetCanvas;
    [SerializeField] private Animator animator;
    
    
    public void OnPointerDown(PointerEventData eventData) {
        Debug.Log("OnPointerDown");
    }

    public void OnBeginDrag(PointerEventData eventData) {
        Debug.Log("OnBeginDrag");
    }

    public void OnDrag(PointerEventData eventData) {
        Debug.Log("OnDrag");
        this.targetRectTransform.anchoredPosition = new Vector2(0, Mathf.Clamp((this.targetRectTransform.anchoredPosition.y + (eventData.delta.y / this.targetCanvas.scaleFactor)), -146.25f, 1176.45f));
    }
    
    public void OnEndDrag(PointerEventData eventData) {
        Debug.Log("OnEndDrag");
        
        // TODO: MENU DRAG ANI
        
    }
}