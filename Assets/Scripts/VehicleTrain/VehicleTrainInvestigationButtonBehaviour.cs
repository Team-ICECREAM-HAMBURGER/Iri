using UnityEngine;
using UnityEngine.Events;

public class VehicleTrainInvestigationButtonBehaviour : MonoBehaviour {
    [HideInInspector] public UnityEvent OnInvestigate;
    
    
    public void OnClick() {
        this.OnInvestigate.Invoke();
    }
}