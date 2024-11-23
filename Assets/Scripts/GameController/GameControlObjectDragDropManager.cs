using UnityEngine;
using UnityEngine.EventSystems;

public class GameControlObjectDragDropManager : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IDragHandler, IEndDragHandler {
    [SerializeField] private RectTransform targetRectTransform;
    [SerializeField] private Canvas targetCanvas;
    [SerializeField] private Animator animator;

    // private float currentDelta;
    private Vector2 swipeStartPosition;
    private Vector2 swipeEndPosition;
    private float swipeDirection;
    private int swipeLevel;


    private void Init() {
        this.swipeDirection = 0f;
        this.swipeLevel = 0;

        this.animator.SetBool("isEndLevel", true);
        this.animator.SetFloat("direction", this.swipeDirection);
    }

    private void Awake() {
        Init();
    }
    
    public void OnPointerDown(PointerEventData eventData) {
        Debug.Log("OnPointerDown");
    }

    public void OnBeginDrag(PointerEventData eventData) {
        Debug.Log("OnBeginDrag");
        this.swipeStartPosition = (eventData.position / this.targetCanvas.scaleFactor);
    }

    public void OnDrag(PointerEventData eventData) {
        Debug.Log("OnDrag");
        // this.currentDelta = (eventData.delta.y / this.targetCanvas.scaleFactor);
        // this.targetRectTransform.anchoredPosition = new Vector2(0, Mathf.Clamp((this.targetRectTransform.anchoredPosition.y + this.currentDelta), -140f, 1190f));
    }
    
    public void OnEndDrag(PointerEventData eventData) {
        Debug.Log("OnEndDrag");
        
        // TODO: MENU DRAG
        this.swipeEndPosition = (eventData.position / this.targetCanvas.scaleFactor);
        this.swipeDirection = (this.swipeEndPosition - this.swipeStartPosition).normalized.y;

        Debug.Log(this.swipeDirection);
        
        switch (this.swipeDirection) {
            case > 0:
                this.swipeLevel -= 1;
                break;
            case < 0:
                this.swipeLevel += 1;
                break;
        }
        
        Debug.Log(this.swipeLevel);
        
        this.animator.SetFloat("direction", this.swipeDirection);
        this.animator.SetBool("isEndLevel", (this.swipeLevel is -1 or 3));  // TODO: 번호가 이상하게 바뀌고 있음;
        this.animator.SetTrigger("onSwipe");
    }
}