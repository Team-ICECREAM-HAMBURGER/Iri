using UnityEngine;
using UnityEngine.Events;

public class MobileConsoleStampController : MonoBehaviour {
    [HideInInspector] public UnityEvent OnPaperStampOk;
    [HideInInspector] public UnityEvent OnPaperStampNo;
    
    
    public void OnStampOk() {
        this.OnPaperStampOk.Invoke();
    }

    public void OnStampNo() {
        this.OnPaperStampNo.Invoke();
    }
}