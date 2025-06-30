using TMPro;
using UnityEngine;

public class ItemInvestigationReportBehaviour : MonoBehaviour {
    [SerializeField] private TMP_Text nameField;
    [Space(10f)]
    [SerializeField] private ItemStampPunchBehaviour itemStampPunchBehaviour;
    [SerializeField] private GameControlObjectPoolingController okStampObjectPoolingController;
    [SerializeField] private GameControlObjectPoolingController noStampObjectPoolingController;
    
    private ItemTossController itemTossController;
    private Vector2 itemInitPosition;
    private RectTransform stampRectTransform;
    private GameObject stampObject;


    private void Init() {
        this.itemTossController = this.GetComponent<ItemTossController>();
        this.itemTossController.onItemToss.AddListener(OnItemReturn);
        
        this.itemInitPosition = this.gameObject.transform.localPosition;
        
        this.itemStampPunchBehaviour.OnPaperStampOk.AddListener(OnPaperStampOK);
        this.itemStampPunchBehaviour.OnPaperStampNo.AddListener(OnPaperStampNO);
    }
    
    public void Init(PassengerData passengerData) {
        this.gameObject.transform.localPosition = this.itemInitPosition;
        
        this.nameField.text = passengerData.name;
        
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
        
        ItemInvestigateManager.Instance.isOK = true;
    }

    private void OnPaperStampNO(RectTransform punchRectTransform) {
        this.stampObject = this.noStampObjectPoolingController.GetPooledObject();

        if (this.stampObject == null) {
            return;
        }
        
        this.stampRectTransform = (RectTransform)this.stampObject.transform;
        this.stampRectTransform.position = punchRectTransform.position;
        
        this.stampObject.SetActive(true);
        
        ItemInvestigateManager.Instance.isOK = false;
    }

    private void OnItemReturn() {
        ItemInvestigateManager.Instance.InvestigationItemReturnCheck(GameControlTypeManager.ItemType.INSPECTION_REPORT);
    }
}