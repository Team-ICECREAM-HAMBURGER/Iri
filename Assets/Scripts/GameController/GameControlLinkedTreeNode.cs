using System.Collections.Generic;

public class GameControlLinkedTreeNode<T> {
    public T data;
    public List<GameControlLinkedTreeNode<T>> children;
    
    
    public GameControlLinkedTreeNode(T data) {
        this.data = data;
        this.children = new();
    }

    public void AddChild(GameControlLinkedTreeNode<T> child) {
        this.children.Add(child);
    }
}