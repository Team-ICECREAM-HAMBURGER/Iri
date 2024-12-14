using UnityEngine;

public class ItemInspectionReportStampController : MonoBehaviour {
    [Space(10f)]
    
    [SerializeField] private MobileConsoleStampController mobileConsoleStampController;
    
    [Space(10f)]
    
    [SerializeField] private GameControlObjectPoolingController okStampObjectPoolingController;
    [SerializeField] private GameControlObjectPoolingController noStampObjectPoolingController;
    
    private RectTransform okStampRectTransform;
    private RectTransform noStampRectTransform;
    private GameObject _stampObject;
    
    
    private void Init() {
        this.mobileConsoleStampController.OnPaperStampOk.AddListener(OnPaperStampOk);
        this.mobileConsoleStampController.OnPaperStampNo.AddListener(OnPaperStampNo);
        
        // this.okStampRectTransform.gameObject.SetActive(false);
        // this.noStampRectTransform.gameObject.SetActive(false);
    }

    private void Awake() {
        Init();
    }

    private void OnPaperStampOk(RectTransform rectTransform) {
        this._stampObject = this.okStampObjectPoolingController.GetPooledObject();
        
        if (this._stampObject == null) {
            return;
        }
        
        this.okStampRectTransform = (RectTransform)this._stampObject.transform;
        
        this.okStampRectTransform.position = rectTransform.position;
        this.okStampRectTransform.gameObject.SetActive(true);
        
        // this.okStampRectTransform.position = rectTransform.position;
        // this.okStampRectTransform.gameObject.SetActive(true);
    }

    private void OnPaperStampNo(RectTransform rectTransform) {
        this._stampObject = this.noStampObjectPoolingController.GetPooledObject();
        
        if (this._stampObject == null) {
            return;
        }

        this.noStampRectTransform = (RectTransform)this._stampObject.transform;

        this.noStampRectTransform.position = rectTransform.position;
        this.noStampRectTransform.gameObject.SetActive(true);
        
        // this.noStampRectTransform.position = rectTransform.position;
        // this.noStampRectTransform.gameObject.SetActive(true);
    }
}