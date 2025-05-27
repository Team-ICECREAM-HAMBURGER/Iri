using UnityEngine;
using UnityEngine.Events;

public class TrafficStatusTrigger : MonoBehaviour {
    [SerializeField] private GameControlTypeManager.TrainLocationType triggerStatus;
    
    [HideInInspector] public UnityEvent<GameControlTypeManager.TrainLocationType> OnTrafficApproach;
    [HideInInspector] public UnityEvent OnTriggerSwitch;


    private void Init() {
        this.OnTriggerSwitch.AddListener(TriggerSwitch);
    }

    private void Awake() {
        Init();
    }
    
    private void OnTriggerEnter(Collider other) {
        if (other.CompareTag(this.tag)) {
            this.OnTrafficApproach?.Invoke(this.triggerStatus);
            TriggerSwitch();
        }
    }

    private void TriggerSwitch() {
        this.gameObject.SetActive(!this.gameObject.activeSelf);
    }
}