using UnityEngine;

public class ItemInspectionReportController : MonoBehaviour {
    [Space(10f)]
    
    [SerializeField] private MobileConsoleStampController mobileConsoleStampController;
    [SerializeField] private Animator animator;
    

    private void Init() {
        this.mobileConsoleStampController.OnPaperStampOk.AddListener(OnPaperStampOk);
        this.mobileConsoleStampController.OnPaperStampNo.AddListener(OnPaperStampNo);
    }

    private void Awake() {
        Init();
    }

    private void OnPaperStampOk() {
        this.animator.SetTrigger("onPaperOut");
    }

    private void OnPaperStampNo() {
        this.animator.SetTrigger("onPaperOut");
    }
}