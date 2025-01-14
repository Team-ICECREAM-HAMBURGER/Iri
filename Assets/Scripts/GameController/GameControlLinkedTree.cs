public class GameControlLinkedTree<T> {
    public GameControlLinkedTreeNode<T> root;
    
    
    public GameControlLinkedTree(T rootData) {
        this.root = new(rootData);
    }

    public GameControlLinkedTreeNode<T> DFS(GameControlLinkedTreeNode<T> node, T target) {
        if (node == null) {
            return null;
        }

        if (node.data.Equals(target)) {
            return node;
        }

        foreach (var VARIABLE in node.children) {
            var result = DFS(VARIABLE,target);

            if (result != null) {
                return result;
            }
        }
        
        return null;
    }
}