using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;

public class ItemInvestigationLogBehaviour : MonoBehaviour {
    [SerializeField] private TMP_Text nameField;
    [SerializeField] private TMP_Text genderField;
    [SerializeField] private TMP_Text dobField;
    [SerializeField] private TMP_Text investigateNoteField;
    
    private Vector2 itemInitPosition;    
    private ItemTossController itemTossController;


    private void Init() {
        this.itemTossController = this.GetComponent<ItemTossController>();
        this.itemTossController.onItemToss.AddListener(OnItemReturn);

        this.itemInitPosition = this.gameObject.transform.localPosition;
    }

    private void Awake() {
        Init();
    }

    public void Init(PassengerData passengerData) {
        this.gameObject.transform.localPosition = this.itemInitPosition;

        // 아이템 데이터 등록 //
        this.nameField.text = passengerData.name;
        this.genderField.text = passengerData.gender;
        this.dobField.text = passengerData.dob;
        this.investigateNoteField.text = passengerData.investigateNote;
        
        this.gameObject.SetActive(true);
    }

    private void OnItemReturn() {
        ItemInvestigateManager.Instance.InvestigationItemReturnCheck(GameControlTypeManager.ItemType.INSPECTION_LOG);
    }
}