using UnityEngine;
using UnityEngine.Events;

public class TrafficStatusTrigger : MonoBehaviour {
    [SerializeField] private GameControlTypeManager.TrafficStatus triggerStatus;
    
    [HideInInspector] public UnityEvent<GameControlTypeManager.TrafficStatus> OnTrafficApproach;
    [HideInInspector] public UnityEvent OnTriggerSwitch;


    private void Init() {
        this.OnTriggerSwitch.AddListener(TriggerSwitch);
    }

    private void Awake() {
        Init();
    }
    
    private void OnTriggerEnter(Collider other) {
        if (other.CompareTag(this.tag)) {
            Debug.Log(this.triggerStatus);
            this.OnTrafficApproach?.Invoke(this.triggerStatus);
            TriggerSwitch();
        }
    }

    private void TriggerSwitch() {
        this.gameObject.SetActive(!this.gameObject.activeSelf);
    }
}