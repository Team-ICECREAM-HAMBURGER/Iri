using UnityEngine;
using UnityEngine.EventSystems;

public class GameControlDragDropSnapController : MonoBehaviour, IDropHandler {
    public void OnDrop(PointerEventData eventData) {
        Debug.Log("OnDrop");
    }
}