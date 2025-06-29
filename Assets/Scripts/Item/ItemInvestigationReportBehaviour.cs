using UnityEngine;

public class ItemInvestigationReportBehaviour : MonoBehaviour {
    [SerializeField] private ItemStampPunchBehaviour itemStampPunchBehaviour;
    [SerializeField] private GameControlObjectPoolingController okStampObjectPoolingController;
    [SerializeField] private GameControlObjectPoolingController noStampObjectPoolingController;
    
    private (string, bool) investigationResult;
    private Vector2 itemInitPosition;
    private RectTransform stampRectTransform;
    private GameObject stampObject;


    private void Init() {
        this.itemInitPosition = this.gameObject.transform.localPosition;
        
        this.itemStampPunchBehaviour.OnPaperStampOk.AddListener(OnPaperStampOK);
        this.itemStampPunchBehaviour.OnPaperStampNo.AddListener(OnPaperStampNO);

        this.gameObject.SetActive(false);
    }
    
    public void Init(Passenger.PassengerData passengerData) {
        this.gameObject.transform.localPosition = this.itemInitPosition;
        this.investigationResult = (passengerData.name, false);
        
        this.okStampObjectPoolingController.ReturnToPoolStack();
        this.noStampObjectPoolingController.ReturnToPoolStack();
        
        this.gameObject.SetActive(true);
    }

    private void Awake() {
        Init();
    }

    private void OnPaperStampOK(RectTransform punchRectTransform) {
        this.stampObject = this.okStampObjectPoolingController.GetPooledObject();

        if (this.stampObject == null) {
            return;
        }

        this.stampRectTransform = (RectTransform)this.stampObject.transform;
        this.stampRectTransform.position = punchRectTransform.position;
        
        this.stampObject.SetActive(true);
        this.investigationResult = (this.investigationResult.Item1, true);  // OK
    }

    private void OnPaperStampNO(RectTransform punchRectTransform) {
        this.stampObject = this.noStampObjectPoolingController.GetPooledObject();

        if (this.stampObject == null) {
            return;
        }
        
        this.stampRectTransform = (RectTransform)this.stampObject.transform;
        this.stampRectTransform.position = punchRectTransform.position;
        
        this.stampObject.SetActive(true);
        this.investigationResult = (this.investigationResult.Item1, false); // NO
    }
}