using UnityEngine;
using UnityEngine.EventSystems;

public class GameControlObjectDragDropManager : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IDragHandler, IEndDragHandler {
    [SerializeField] private RectTransform draggingObjectRectTransform;
    [SerializeField] private Canvas canvas;
    [SerializeField] private Animator pivotAnimator;
    [SerializeField] private AnimationClip[] pivotAnimationClips;
    
    private float _achoredPosition;
    
    
    public void OnPointerDown(PointerEventData eventData) {
        Debug.Log("OnPointerDown");
        this._achoredPosition = eventData.position.y;
    }

    public void OnBeginDrag(PointerEventData eventData) {
        Debug.Log("OnBeginDrag");
    }

    public void OnDrag(PointerEventData eventData) {
        Debug.Log("OnDrag");
        // this.draggingObjectRectTransform.anchoredPosition = new Vector2(0, Mathf.Clamp((this.draggingObjectRectTransform.anchoredPosition.y + (eventData.delta.y / this.canvas.scaleFactor)), -146.25f, 1176.45f));
    }
    
    public void OnEndDrag(PointerEventData eventData) {
        Debug.Log("OnEndDrag");
        
        // MENU DRAG ANI
        var direction = (eventData.position.y - this._achoredPosition);
        
        // TODO: 접힌 상태에서 한 번 더 접거나, 펼친 상태에서 한 번 더 펼치면 이전 제스처가 다음 행동 때 중첩으로 적용되는 버그 발생
        if (direction < 0) {    // DOWN
            this.pivotAnimator.SetTrigger("Down");
        }
        else if (direction > 0) {   // UP
            this.pivotAnimator.SetTrigger("Up");
        }
    }
}