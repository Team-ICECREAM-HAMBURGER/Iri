using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class GameControlObjectClickController : MonoBehaviour {
    [SerializeField] private List<GraphicRaycaster> graphicRaycasters;  // GraphicRaycaster를 필드로 추가
    
    private List<RaycastResult> raycastResults;


    private void Init() {
        this.raycastResults = new List<RaycastResult>();
    }

    private void Awake() {
        Init();
    }
    
    private bool IsPointerOverUI() {
        PointerEventData pointerEventData = new PointerEventData(EventSystem.current) {
            position = Mouse.current.position.ReadValue()
        };

        // UI 이벤트를 처리할 RaycastResult 리스트
        foreach (var VARIABLE in this.graphicRaycasters) {
            VARIABLE.Raycast(pointerEventData, this.raycastResults);
        }
        
        // UI가 클릭된 경우 true
        return (this.raycastResults.Count > 0);
    }
    
    private void OnSelect() {
        if (IsPointerOverUI()) {    // UI 오브젝트 클릭 시 true
            this.raycastResults.Clear();
            return;
        }
        
        Physics.queriesHitTriggers = true; // 트리거도 Raycast에 반응하도록 설정
        Ray ray = Camera.main.ScreenPointToRay(Mouse.current.position.ReadValue());

        if (Physics.Raycast(ray, out RaycastHit hit)) {
            if (hit.transform.gameObject.layer == LayerMask.NameToLayer("Clickable Object")) {
                hit.transform.gameObject.GetComponent<IGameControlClickableObject>().OnClick();
            }
        }
    }
}