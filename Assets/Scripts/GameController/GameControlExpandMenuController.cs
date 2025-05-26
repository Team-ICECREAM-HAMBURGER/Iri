using UnityEngine;
using UnityEngine.UIElements;

public abstract class GameControlExpandMenuController : MonoBehaviour /*GameControlPointerManager*/ {
    [SerializeField] protected UIDocument uiDocument;
    [SerializeField] protected string expandMenuParentName;
    [SerializeField] protected string expandMenuName;
    
    [Space(10f)] 
    [SerializeField] protected string expandStyleClassName;
    
    protected Button expandMenu;
    protected VisualElement settingParent;

    
    protected void Init() {
        this.expandMenu = this.uiDocument.rootVisualElement.Q<Button>(this.expandMenuName);
        this.settingParent = this.uiDocument.rootVisualElement.Q<VisualElement>(this.expandMenuParentName);
        
        this.expandMenu.RegisterCallback<ClickEvent>(OnExpandMenuClicked);
        this.settingParent.AddToClassList(this.expandStyleClassName);
    }
    
    protected void OnExpandMenuClicked(ClickEvent clickEvent) {
        // Debug.Log("OnExpandMenuClicked");
        if (this.settingParent.ClassListContains(this.expandStyleClassName)) {
            this.settingParent.RemoveFromClassList(this.expandStyleClassName);
        }
        else {
            this.settingParent.AddToClassList(this.expandStyleClassName);
        }
    }

    protected void OnDisable() {
        this.expandMenu.UnregisterCallback<ClickEvent>(OnExpandMenuClicked);
    }
}