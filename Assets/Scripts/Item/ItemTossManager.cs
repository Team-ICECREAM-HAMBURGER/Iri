using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ItemTossManager : MonoBehaviour, IDropHandler, IPointerUpHandler, IPointerEnterHandler, IPointerExitHandler {
    [SerializeField] private List<GameObject> tossIndicatorObject;
    
    
    public void OnDrop(PointerEventData eventData) {
        if (eventData.pointerDrag != null) {
            eventData.pointerDrag.GetComponent<ItemTossController>().onItemToss.Invoke();
            TossIndicatorControl(false);
        }
    }

    public void OnPointerEnter(PointerEventData eventData) {
        if (eventData.pointerDrag != null) {
            TossIndicatorControl(true);
        }
    }

    public void OnPointerUp(PointerEventData eventData) {
        if (eventData.pointerDrag != null) {
            TossIndicatorControl(false);
        }
    }
    
    public void OnPointerExit(PointerEventData eventData) {
        if (eventData.pointerDrag != null) {
            TossIndicatorControl(false);
        }
    }

    private void TossIndicatorControl(bool isActive) {
        if (this.tossIndicatorObject != null) {
            foreach (var VARIABLE in this.tossIndicatorObject) {
                VARIABLE.SetActive(isActive);
            }
        }
    }
}