using UnityEngine;
using UnityEngine.InputSystem;

public class GameControlObjectClickController : MonoBehaviour {
    private void OnSelect() {
        Ray ray = Camera.main.ScreenPointToRay(Mouse.current.position.ReadValue());

        if (Physics.Raycast(ray, out RaycastHit hit)) {
            if (hit.transform.gameObject.layer == LayerMask.NameToLayer("Clickable Object")) {
                hit.transform.gameObject.GetComponent<IGameControlClickableObject>().OnClick();
            }
        }
    }
}