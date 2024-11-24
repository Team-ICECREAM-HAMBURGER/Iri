using UnityEngine;
using UnityEngine.EventSystems;

public abstract class GameControlPointerManager : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IDragHandler, IEndDragHandler {
    public RectTransform targetRectTransform;
    public Canvas targetCanvas;
    
    
    public abstract void OnPointerDown(PointerEventData eventData);
    public abstract void OnBeginDrag(PointerEventData eventData);
    public abstract void OnDrag(PointerEventData eventData);
    public abstract void OnEndDrag(PointerEventData eventData);
}