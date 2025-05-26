using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UIElements;

public class GameControlPopupMenuController : MonoBehaviour {
    [SerializeField] private UIDocument uiDocument;
    [SerializeField] private string popupMenuName;
    
    private Button popupMenu;


    private void Init() {
        this.popupMenu = this.uiDocument.rootVisualElement.Q<Button>(this.popupMenuName) as Button;
        this.popupMenu.RegisterCallback<ClickEvent>(OnPopupMenuClicked);

    }

    private void Awake() {
        Init();
    }
    
    private void OnPopupMenuClicked(ClickEvent clickEvent) {
        Debug.Log("OnPopupMenuClicked");
        // TODO; Game Speed => 0
    }

    private void OnDisable() {
        this.popupMenu.UnregisterCallback<ClickEvent>(OnPopupMenuClicked);
    }
}
