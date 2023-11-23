// Приклад 1
var root1 = new TreeNode(1,
    new TreeNode(2, new TreeNode(3), new TreeNode(4)),
    new TreeNode(2, new TreeNode(4), new TreeNode(3)));
Console.WriteLine(IsSymmetric(root1)); // Output: true

// Приклад 2
var root2 = new TreeNode(1,
    new TreeNode(2, null, new TreeNode(3)),
    new TreeNode(2, null, new TreeNode(3)));
Console.WriteLine(IsSymmetric(root2)); // Output: false

// Приклад 3
var root3 = new TreeNode(1,
    new TreeNode(2, new TreeNode(1)),
    new TreeNode(1, new TreeNode(2)));
Console.WriteLine(IsSymmetric(root3)); // Output: false
return;

bool IsSymmetric(TreeNode? root)
{
    return root is null || IsMirror(root.Left, root.Right);
}

bool IsMirror(TreeNode? node1, TreeNode? node2)
{
    if (node1 is null && node2 is null)
        return true;

    if (node1 is null || node2 is null)
        return false;

    return node1.Val == node2.Val
           && IsMirror(node1.Right, node2.Left)
           && IsMirror(node1.Left, node2.Right);
}

public class TreeNode(int val = 0, TreeNode? left = null, TreeNode? right = null)
{
    public readonly int Val = val;
    public readonly TreeNode? Left = left;
    public readonly TreeNode? Right = right;
}
