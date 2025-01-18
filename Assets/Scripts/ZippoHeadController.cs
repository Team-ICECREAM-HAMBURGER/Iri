using UnityEngine;

public class ZippoHeadController : MonoBehaviour {
    [SerializeField] private Animator animator;
    
    
    public void OnHeadControl() {
        this.animator.SetBool("isDisassembly", !this.animator.GetBool("isDisassembly"));
    }
}