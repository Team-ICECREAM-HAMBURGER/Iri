using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class GameControlObjectClickController : MonoBehaviour {
    private void OnSelect() {
        if (EventSystem.current.IsPointerOverGameObject()) {    // UI 오브젝트 클릭 시 true
            return;
        }
        
        Ray ray = Camera.main.ScreenPointToRay(Mouse.current.position.ReadValue());

        if (Physics.Raycast(ray, out RaycastHit hit)) {
            if (hit.transform.gameObject.layer == LayerMask.NameToLayer("Clickable Object")) {
                hit.transform.gameObject.GetComponent<IGameControlClickableObject>().OnClick();
            }
        }
    }
}