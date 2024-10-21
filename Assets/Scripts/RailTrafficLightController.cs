using UnityEngine;
using UnityEngine.Events;

public class RailTrafficLightController : MonoBehaviour {
    public UnityEvent<GameControlTypeManager.TrafficStatus> OnTrafficLightControl;
    
    [SerializeField] private GameControlTypeManager.TrafficStatus trafficLightStatus;

    
    private void Init() {
        this.OnTrafficLightControl.AddListener(this.TrafficLightUpdate);
    }

    private void Awake() {
        Init();
    }

    private void Update() {
        if (Input.GetMouseButtonDown(0)) {  // TODO: 코드 정리
            Ray mousePointerRay = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(mousePointerRay, out var mousePointerHit)) {
                if (mousePointerHit.transform.CompareTag(this.transform.tag)) {
                    this.OnTrafficLightControl.Invoke(this.trafficLightStatus);
                }
            }
        }
    }

    private void TrafficLightUpdate(GameControlTypeManager.TrafficStatus trafficStatusType) {
        // TODO: 조명 제어
        Debug.Log("!:" + trafficStatusType.ToString());
    }
}