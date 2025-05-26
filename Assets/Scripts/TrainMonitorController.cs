using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UIElements;

public class TrainMonitorController : GameControlExpandMenuController {
    [HideInInspector] public UnityEvent<object> OnTrainSelected;
    
    
    private void Init() {
        base.Init();
        
        for (var i = 0; i < 4; i++) {
            var btn = base.uiDocument.rootVisualElement.Q<Button>($"Train{i}Button");
            btn.userData = (GameControlTypeManager.vehicleType)i;
            btn.RegisterCallback<ClickEvent>(OnTrainSelectClicked);
        }
    }

    private void OnTrainSelectClicked(ClickEvent clickEvent) {
        var btn = clickEvent.currentTarget as Button;
        
        if (btn != null) {
            Debug.Log($"OnTrainSelectClicked {btn.userData}");
            this.OnTrainSelected?.Invoke(btn.userData);
        }
    }
    
    private void Awake() {
        Init();
    }
    
}
