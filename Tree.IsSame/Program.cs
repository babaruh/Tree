// Приклад 1
var p1 = new TreeNode(1, new TreeNode(2), new TreeNode(3));
var q1 = new TreeNode(1, new TreeNode(2), new TreeNode(3));
Console.WriteLine(IsSameTree(p1, q1)); // Output: true

// Приклад 2
var p2 = new TreeNode(1, new TreeNode(2));
var q2 = new TreeNode(1, null, new TreeNode(2));
Console.WriteLine(IsSameTree(p2, q2)); // Output: false

// Приклад 3
var p3 = new TreeNode(1, new TreeNode(2), new TreeNode(1));
var q3 = new TreeNode(1, new TreeNode(1), new TreeNode(2));
Console.WriteLine(IsSameTree(p3, q3)); // Output: false
return;

bool IsSameTree(TreeNode? p, TreeNode? q)
{
    if (p is null && q is null)
        return true;

    if (p is null || q is null)
        return false;

    if (p.Val != q.Val)
        return false;

    return IsSameTree(p.Left, q.Left) && IsSameTree(p.Right, q.Right);
}

public class TreeNode(int val = 0, TreeNode? left = null, TreeNode? right = null)
{
    public readonly int Val = val;
    public readonly TreeNode? Left = left;
    public readonly TreeNode? Right = right;
}
