using UnityEngine;
using UnityEngine.Events;

public class MobileConsoleStampController : MonoBehaviour {
    [HideInInspector] public UnityEvent<RectTransform> OnPaperStampOk;
    [HideInInspector] public UnityEvent<RectTransform> OnPaperStampNo;
    [HideInInspector] public UnityEvent OnPaperStampReset;
    
    [SerializeField] private RectTransform rectTransform;
    
    
    public void OnStampOk() {
        this.OnPaperStampOk.Invoke(this.rectTransform);
    }

    public void OnStampNo() {
        this.OnPaperStampNo.Invoke(this.rectTransform);
    }

    public void OnStampReset() {
        this.OnPaperStampReset.Invoke();
    }
}