using System.Collections;
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
        
        switch (this.swipeDirection) {
            case < 0:
                this.swipeLevel -= 1;
                break;
            case > 0:
                this.swipeLevel += 1;
                break;
        }        
        
        this.swipeLevel = Mathf.Clamp(this.swipeLevel, 0, 1);
        
        this.animator.SetFloat("direction", this.swipeDirection);
        this.animator.SetInteger("swipeLevel", this.swipeLevel);
        this.animator.SetTrigger("onSwipe");
    }
    
    public void InvestigatePanelActive() {
        StartCoroutine(DelayAction());
        return;

        // Local Method
        IEnumerator DelayAction() {
            yield return new WaitForSeconds(1.5f);
            
            this.swipeLevel = 0;
            this.swipeDirection = -1;
            this.animator.SetFloat("direction", this.swipeDirection);
            this.animator.SetInteger("swipeLevel", this.swipeLevel);
            this.animator.SetTrigger("onSwipe");
        }
    }
}