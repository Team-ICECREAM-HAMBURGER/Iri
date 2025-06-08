using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class PunchButtonBehaviour : MonoBehaviour {
    [HideInInspector] public UnityEvent OnPunchIn;
    
    [SerializeField] private Canvas punchInCanvas;
    [SerializeField] private Image iconImage;


    private void Start() {
        StartCoroutine(IconNotify());
    }

    private IEnumerator IconNotify() {
        while (true) {
            yield return new WaitForSeconds(0.5f);
            this.iconImage.enabled = !this.iconImage.IsActive();    
        }
    }
    
    public void OnClick() {
        StopCoroutine(IconNotify());
        this.iconImage.enabled = true;
        this.punchInCanvas.enabled = false;
        
        this.OnPunchIn.Invoke();
    }
}