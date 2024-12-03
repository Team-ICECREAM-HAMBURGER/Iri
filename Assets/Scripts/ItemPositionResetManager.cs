using UnityEngine;
using UnityEngine.Events;

public class ItemPositionResetManager : MonoBehaviour {
    [HideInInspector] public UnityEvent OnItemPositionReset;
    
    
    public void OnClick() {
        // Items Position Reset
        OnItemPositionReset.Invoke();
    }
}