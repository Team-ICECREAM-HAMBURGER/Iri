using UnityEngine;

public class GameControlObjectClickManager : MonoBehaviour {
    private void OnClick() {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out RaycastHit hit)) {
            if (hit.transform.gameObject.layer == LayerMask.NameToLayer("Clickable Object")) {
                hit.transform.gameObject.GetComponent<IGameControlClickableObject>().OnClick();
            }
        }
    }
}