using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;

public class TrafficStatusTrigger : MonoBehaviour {
    [FormerlySerializedAs("triggerStatus")] [SerializeField] private GameControlTypeManager.TrafficState triggerState;
    
    [HideInInspector] public UnityEvent<GameControlTypeManager.TrafficState> OnTrafficApproach;
    [HideInInspector] public UnityEvent OnTriggerSwitch;


    private void Init() {
        this.OnTriggerSwitch.AddListener(TriggerSwitch);
    }

    private void Awake() {
        Init();
    }
    
    private void OnTriggerEnter(Collider other) {
        if (other.CompareTag(this.tag)) {
            this.OnTrafficApproach?.Invoke(this.triggerState);
            TriggerSwitch();
        }
    }

    private void TriggerSwitch() {
        this.gameObject.SetActive(!this.gameObject.activeSelf);
    }
}