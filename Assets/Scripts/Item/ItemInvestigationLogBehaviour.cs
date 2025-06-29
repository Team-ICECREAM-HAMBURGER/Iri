using System;
using TMPro;
using UnityEngine;

public class ItemInvestigationLogBehaviour : MonoBehaviour {
    [SerializeField] private TMP_Text nameField;
    [SerializeField] private TMP_Text genderField;
    [SerializeField] private TMP_Text dobField;
    [SerializeField] private TMP_Text personalNoteField;

    private string name;
    private string gender;
    private string dob;
    private string personalNote;
    private Vector2 itemInitPosition;

    
    public void Init(Passenger.PassengerData passengerData) {
        this.name = passengerData.name;        
        this.gender = passengerData.gender;
        this.dob = passengerData.dob;
        this.personalNote = passengerData.personalNote;
        
        this.nameField.text = this.name;
        this.genderField.text = this.gender;
        this.dobField.text = this.dob;
        this.personalNoteField.text = this.personalNote;
        
        this.gameObject.transform.localPosition = this.itemInitPosition;
        this.gameObject.SetActive(true);
    }
    
    private void Awake() {
        this.itemInitPosition = this.gameObject.transform.localPosition; // TODO: 위치가 안맞음!
        this.gameObject.SetActive(false);
    }
}