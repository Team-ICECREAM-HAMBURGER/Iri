using UnityEngine;

public class GameControlColliderBoundsManager : MonoBehaviour {
    [SerializeField] private BoxCollider combineCollider;

    private Bounds combineColliderBounds;
    
    public delegate Bounds BoundsCalculatorHandler(); 
    public event BoundsCalculatorHandler OnBoundsCalculator;
    
    
    private void Init() {
        this.combineColliderBounds = new(this.transform.position, Vector3.zero);
        
        if (OnBoundsCalculator != null) {
            this.combineColliderBounds.Encapsulate(this.OnBoundsCalculator());
        }
        
        this.combineCollider.center = (this.combineColliderBounds.center - this.combineCollider.transform.position);
        this.combineCollider.size = this.combineColliderBounds.size;
    }
    
    private void Start() {  // Manager
        this.Init();
    }
}
