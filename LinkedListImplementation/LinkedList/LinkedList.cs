namespace LinkedList;

public class LinkedList<T> : ILinkedList<T>
{
    private Node<T>? _head;
    private Node<T>? _tail;
    private int _count;

    public Node<T>? Begin()
    {
        return _head;
    }

    public Node<T>? End()
    {
        return _tail?.Next;
    }

    /// <summary>
    /// Adds an element at the end of the linked list.
    /// </summary>
    /// <param name="data">An element to add.</param>
    /// <exception cref="ArgumentNullException">If data is null.</exception>
    public void PushBack(T? data)
    {
        if (data == null) throw new ArgumentNullException(nameof(data), "The data's PushBack argument cannot be null.");

        ++_count;
        Node<T> cur = new Node<T>(data);

        if (_head == null)
        {
            _head = cur;
            _tail = cur;
            return;
        }

        if (_tail == null) return; // not necessary, but compiler give warnings otherwise

        cur.Prev = _tail;
        _tail.Next = cur;
        _tail = cur;
        cur.Next = null;
    }

    /// <summary>
    /// Removes the give node from the list.
    /// </summary>
    /// <param name="node">Node to remove.</param>
    /// <returns>The next node or null.</returns>
    /// <exception cref="NullReferenceException">If given node is null or list is empty.</exception>
    public Node<T>? Erase(Node<T>? node)
    {
        if (node == null || _head == null) throw new NullReferenceException("Cannot erase null.");

        --_count;

        if (node == _head && node == _tail)
        {
            _head = null;
            _tail = null;
            return null;
        }

        if (node == _head)
        {
            _head = _head.Next;
            _head!.Prev = null;
            return _head;
        }

        if (node == _tail)
        {
            _tail = node.Prev;
            _tail!.Next = null;
            return null;
        }

        node.Prev!.Next = node.Next;
        node.Next!.Prev = node.Prev;
        return node.Next;
    }

    /// <summary>
    /// Inserts a new node before the given one.
    /// </summary>
    /// <param name="node">New node to insert.</param>
    /// <param name="before">Note before which will be inserted.</param>
    /// <returns>New inserted node.</returns>
    public Node<T>? InsertBefore(Node<T>? node, Node<T>? before)
    {
        if (node == null || before == null)
            return node;

        ++_count;

        if (before == _head)
        {
            node.Next = _head;
            node.Prev = null;
            if (_head != null)
                _head.Prev = node;
            _head = node;
            return _head;
        }

        before!.Prev!.Next = node;
        node.Prev = before.Prev;
        before.Prev = node;
        node.Next = before;

        return node;
    }

    /// <summary>
    /// Finds first instances of the given element in the linked list and returns its index or -1.
    /// </summary>
    /// <param name="data">Element to find.</param>
    /// <returns>Index of the found element or -1 if the element was not found.</returns>
    /// <exception cref="ArgumentNullException">If given element is null.</exception>
    public int FirstOf(T? data)
    {
        if (data == null) throw new ArgumentNullException(nameof(data), "Linked list cannot contain null elements.");

        int index = 0;
        for (Node<T>? cur = _head; cur != _tail?.Next; cur = cur?.Next)
        {
            if (cur!.Data!.Equals(data)) return index;
            ++index;
        }

        return -1;
    }

    /// <summary>
    /// Returns an element of the list with the given index.
    /// </summary>
    /// <param name="pos">Index of the element.</param>
    /// <returns>An element in the linked list with given pos.</returns>
    /// <exception cref="ArgumentNullException">If given pos is null.</exception>
    /// <exception cref="ArgumentOutOfRangeException">If given pos is less than 0 or greater than linked list size.</exception>
    public Node<T>? GetAtPos(int? pos)
    {
        if (pos == null) throw new ArgumentNullException(nameof(pos), "Linked list index can not be null.");
        if (pos < 0 || pos > _count) throw new ArgumentOutOfRangeException(nameof(pos), "Index out of range.");

        int index = 0;
        for (Node<T>? cur = _head; cur != _tail?.Next; cur = cur?.Next)
        {
            if (index == pos)
                return cur;
            ++index;
        }

        return null;
    }

    /// <summary>
    /// Returns the number of elements in the linked list.
    /// </summary>
    /// <returns>Size of the linked list.</returns>
    public int Size()
    {
        return _count;
    }
}