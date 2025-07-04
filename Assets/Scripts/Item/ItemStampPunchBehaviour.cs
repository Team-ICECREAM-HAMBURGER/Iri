using UnityEngine;
using UnityEngine.Events;

public class ItemStampPunchBehaviour : MonoBehaviour {
    [HideInInspector] public UnityEvent<RectTransform> OnPaperStampOk;
    [HideInInspector] public UnityEvent<RectTransform> OnPaperStampNo;
    
    [SerializeField] private RectTransform rectTransform;
    
    
    public void OnStampOk() {
        this.OnPaperStampOk.Invoke(this.rectTransform);
    }

    public void OnStampNo() {
        this.OnPaperStampNo.Invoke(this.rectTransform);
    }
}