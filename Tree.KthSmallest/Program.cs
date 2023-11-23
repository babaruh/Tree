var solution = new Solution();

// Приклад 1
var root1 = new TreeNode(3, new TreeNode(1, null, new TreeNode(2)), new TreeNode(4));
Console.WriteLine(solution.KthSmallest(root1, 1)); // Output: 1

// Приклад 2
var root2 = new TreeNode(5, new TreeNode(3, new TreeNode(2, new TreeNode(1)), new TreeNode(4)), new TreeNode(6));
Console.WriteLine(solution.KthSmallest(root2, 3)); // Output: 3

return;

public class Solution
{
    private int _number;
    private int _count;

    public int KthSmallest(TreeNode root, int k)
    {
        _count = k;
        Inorder(root);
        return _number;
    }

    private void Inorder(TreeNode node)
    {
        while (true)
        {
            if (node.Left is not null) 
                Inorder(node.Left);

            _count--;
            if (_count == 0)
            {
                _number = node.Val;
                return;
            }

            if (node.Right is not null)
            {
                node = node.Right;
                continue;
            }

            break;
        }
    }
}

public class TreeNode(int val = 0, TreeNode? left = null, TreeNode? right = null)
{
    public readonly int Val = val;
    public readonly TreeNode? Left = left;
    public readonly TreeNode? Right = right;
}
