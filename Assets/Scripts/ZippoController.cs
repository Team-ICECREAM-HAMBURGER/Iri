using UnityEngine;
using UnityEngine.EventSystems;

public class ZippoController : MonoBehaviour {
    [SerializeField] private Animator animator;
    
    
    public void OnHeadDisassembly() {
        this.animator.SetBool("isDisassembly", !this.animator.GetBool("isDisassembly"));
    }
}