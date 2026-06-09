public class Node
{
    public int Data { get; set; }
    public Node? Right { get; private set; }
    public Node? Left { get; private set; }

    public Node(int data)
    {
        this.Data = data;
    }

public void Insert(int value)
{
    // Ignore duplicates
    if (value == Data)
    {
        return;
    }

    if (value < Data)
    {
        // Insert to the left
        if (Left is null)
            Left = new Node(value);
        else
            Left.Insert(value);
    }
    else
    {
        // Insert to the right
        if (Right is null)
            Right = new Node(value);
        else
            Right.Insert(value);
    }
}

public bool Contains(int value)
{
    // Base case: found the value
    if (value == Data)
    {
        return true;
    }

    // Go left if value is smaller
    if (value < Data)
    {
        if (Left == null)
            return false;

        return Left.Contains(value);
    }

    // Go right if value is greater
    else
    {
        if (Right == null)
            return false;

        return Right.Contains(value);
    }
}

public int GetHeight()
{
    int leftHeight = (Left == null) ? 0 : Left.GetHeight();
    int rightHeight = (Right == null) ? 0 : Right.GetHeight();

    return 1 + Math.Max(leftHeight, rightHeight);
}
}