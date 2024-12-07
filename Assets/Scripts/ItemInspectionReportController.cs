using UnityEngine;

public class ItemInspectionReportController : MonoBehaviour {ㅅ
    [Space(10f)]
    
    [SerializeField] private MobileConsoleStampController mobileConsoleStampController;
    
    [Space(10f)]

    [SerializeField] private RectTransform okStampRectTransform;
    [SerializeField] private RectTransform noStampRectTransform;
    

    private void Init() {
        this.mobileConsoleStampController.OnPaperStampOk.AddListener(OnPaperStampOk);
        this.mobileConsoleStampController.OnPaperStampNo.AddListener(OnPaperStampNo);
        
        this.okStampRectTransform.gameObject.SetActive(false);
        this.noStampRectTransform.gameObject.SetActive(false);
    }

    private void Awake() {
        Init();
    }

    private void OnPaperStampOk(RectTransform rectTransform) {
        this.okStampRectTransform.position = rectTransform.position;
        this.okStampRectTransform.gameObject.SetActive(true);
    }

    private void OnPaperStampNo(RectTransform rectTransform) {
        this.noStampRectTransform.position = rectTransform.position;
        this.noStampRectTransform.gameObject.SetActive(true);
    }
}