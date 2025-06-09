using UnityEngine;
using UnityEngine.EventSystems;

public class GameControlExpandMenuDragController : GameControlPointerManager {
    [SerializeField] private Animator animator;
    [SerializeField] private int swipeLevel;

    private float swipeDirection;
    private Vector2 swipeStartPosition;
    private Vector2 swipeEndPosition;

    
    public override void OnPointerDown(PointerEventData eventData) {
    }

    public override void OnBeginDrag(PointerEventData eventData) {
        this.swipeStartPosition = (eventData.position / this.targetCanvas.scaleFactor);
    }

    public override void OnDrag(PointerEventData eventData) {
    }
    
    public override void OnEndDrag(PointerEventData eventData) {
        this.swipeEndPosition = (eventData.position / this.targetCanvas.scaleFactor);
        this.swipeDirection = (this.swipeEndPosition - this.swipeStartPosition).normalized.y;
        
        if (this.swipeDirection < 0) {
            this.swipeLevel -= 1;
        }
        else if (this.swipeDirection > 0) {
            this.swipeLevel += 1;
        }        
        
        this.swipeLevel = Mathf.Clamp(this.swipeLevel, 0, 2);
        
        this.animator.SetFloat("direction", this.swipeDirection);
        this.animator.SetInteger("swipeLevel", this.swipeLevel);
        this.animator.SetTrigger("onSwipe");
    }
}