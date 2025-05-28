using UnityEngine;
using UnityEngine.Serialization;

public class OfficeController : MonoBehaviour, IGameControlClickableObject {
    [FormerlySerializedAs("playerController")] [SerializeField] private PlayerBehaviour playerBehaviour;
    
    [Space(10f)]
    
    [SerializeField] private Canvas punchInCanvas;
    
    
    public void OnClick() {
        this.playerBehaviour.OnPunchIn.Invoke();
        this.punchInCanvas.enabled = false;
    }
}