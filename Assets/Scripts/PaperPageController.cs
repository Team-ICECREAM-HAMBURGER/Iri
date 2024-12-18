using UnityEngine;

public class PaperPageController : MonoBehaviour {
    [SerializeField] private GameControlCircularLinkedListController gameControlCircularLinkedListController;
    
    private GameObject paperPage;
    
    
    public void OnNext() {
        this.paperPage = this.gameControlCircularLinkedListController.OnNext();
        this.gameControlCircularLinkedListController.OnListReset();
        
        this.paperPage.SetActive(true);
    }

    public void OnPrevious() {
        this.paperPage = this.gameControlCircularLinkedListController.OnPrevious();
        this.gameControlCircularLinkedListController.OnListReset();
        
        this.paperPage.SetActive(true);
    }
}