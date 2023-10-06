namespace LinkedList;

public interface ILinkedList<T>
{
    public void PushBack(T data);

    public Node<T>? Begin();

    public Node<T>? End();

    public Node<T>? Erase(Node<T>? node);

    public Node<T>? InsertBefore(Node<T>? node, Node<T>? before);

    public int Size();

    public int FirstOf(T? data);

    public Node<T>? GetAtPos(int? pos);
}