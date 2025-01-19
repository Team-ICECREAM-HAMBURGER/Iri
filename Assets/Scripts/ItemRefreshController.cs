using System.Collections.Generic;
using UnityEngine;

public class ItemRefreshController : MonoBehaviour {
    [SerializeField] private ItemRefreshManager itemRefreshManager;

    [Space(10f)]
    
    [SerializeField] private GameControlTypeManager.ItemType itemType;
    
    [Space(10f)]
    
    [SerializeField] private RectTransform targetRectTransform;
    [SerializeField] private Canvas targetCanvas;
    
    private Vector2 resetPosition;
    private GameSaveDataPassenger passenger;
    
    
    private void Init() {
        this.itemRefreshManager.OnItemRefresh.RemoveListener(ItemRefresh);
        this.itemRefreshManager.OnItemRefresh.AddListener(ItemRefresh);
        
        this.resetPosition = this.targetRectTransform.anchoredPosition;
    }

    private void Awake() {
        Init();
    }
    
    private void ItemRefresh(Stack<GameSaveDataPassenger> passengerStack) {
        // TODO: 신규 아이템 로드 (다른 승객 증거품으로 교환) -> 모든 서류 제출이 끝났을 때만
        this.targetRectTransform.anchoredPosition = this.resetPosition;
        this.gameObject.SetActive(true);
    }
}