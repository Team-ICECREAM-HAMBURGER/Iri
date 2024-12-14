using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemInspectionReportController : MonoBehaviour {
    [Space(10f)]
    
    [SerializeField] private MobileConsoleStampController mobileConsoleStampController;
    [SerializeField] private GameControlObjectPoolingController gameControlObjectPoolingController;
    
    [Space(10f)] 
    
    [SerializeField] private RectTransform okStampRectTransform;
    [SerializeField] private RectTransform noStampRectTransform;
    

    private void Init() {
        this.mobileConsoleStampController.OnPaperStampOk.AddListener(OnPaperStampOk);
        this.mobileConsoleStampController.OnPaperStampNo.AddListener(OnPaperStampNo);
        this.okStampRectTransform = this.gameControlObjectPoolingController.GetPooledObject();

        // this.okStampRectTransform.gameObject.SetActive(false);
        // this.noStampRectTransform.gameObject.SetActive(false);
    }

    private void Awake() {
        Init();
    }

    private void OnPaperStampOk(RectTransform rectTransform) {
        this.stampsStack
        
        
        
        
        // this.okStampRectTransform.position = rectTransform.position;
        // this.okStampRectTransform.gameObject.SetActive(true);
    }

    private void OnPaperStampNo(RectTransform rectTransform) {
        // this.noStampRectTransform.position = rectTransform.position;
        // this.noStampRectTransform.gameObject.SetActive(true);
    }
}