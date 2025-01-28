using UnityEngine;

public class OfficeController : MonoBehaviour, IGameControlClickableObject {
    [SerializeField] private PlayerController playerController;
    
    [Space(10f)]
    
    [SerializeField] private Canvas punchInCanvas;
    
    
    public void OnClick() {
        this.playerController.OnPunchIn.Invoke();
        this.punchInCanvas.enabled = false;
    }
}