public class GameControlLinkedTree<T> {
    public GameControlLinkedTreeNode<T> root;
    
    
    public GameControlLinkedTree(T rootData) {
        this.root = new(rootData);
    }
}