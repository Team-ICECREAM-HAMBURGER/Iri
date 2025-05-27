using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UIElements;

public class TrainInformationMonitorController : GameControlExpandMenuController {
    public static UnityEvent<GameControlTypeManager.TrainType, 
        GameControlTypeManager.TrainLocationType> OnTrainLocationInfoUpdate;
    
    [SerializeField] private GameControlSerializableDictionary.TrainLocationText trainLocationText;   // L type : L str
    
    private Dictionary<GameControlTypeManager.TrainType, TextElement> trainLocationTextElement;
    
    [HideInInspector] public UnityEvent<object> OnTrainSelected;
    
    
    private void Init() {
        base.Init();

        this.trainLocationTextElement = new();
        OnTrainLocationInfoUpdate = new();
        
        OnTrainLocationInfoUpdate.AddListener(TrainLocationInfoUpdate);
        
        for (var i = 0; i < 4; i++) {
            var btn = base.uiDocument.rootVisualElement.Q<Button>($"Train{i}Button");
            var btnTrainLocationLabel = base.uiDocument.rootVisualElement.Q<TextElement>($"Train{i}_Location");
            var typ = (GameControlTypeManager.TrainType)i;
            
            btn.userData = typ;
            btn.RegisterCallback<ClickEvent>(OnTrainSelectClicked);
            this.trainLocationTextElement[typ] = btnTrainLocationLabel;
        }
    }
    
    private void Awake() {
        Init();
    }
    
    private void OnTrainSelectClicked(ClickEvent clickEvent) {
        var btn = clickEvent.currentTarget as Button;
        
        if (btn != null) {
            this.OnTrainSelected?.Invoke(btn.userData);
        }
    }
    
    private void TrainLocationInfoUpdate(GameControlTypeManager.TrainType trainType, 
        GameControlTypeManager.TrainLocationType trainLocationType) {
        this.trainLocationTextElement[trainType].text = this.trainLocationText[trainLocationType];
    }
}