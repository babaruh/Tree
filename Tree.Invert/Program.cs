using System.Text;

// Приклад 1
var root1 = new TreeNode(4,
    new TreeNode(2, new TreeNode(1), new TreeNode(3)),
    new TreeNode(7, new TreeNode(6), new TreeNode(9)));
var invertedRoot1 = InvertTree(root1);
Console.WriteLine(invertedRoot1?.ToString());  // Output: [4,7,2,9,6,3,1]

// Приклад 2
var root2 = new TreeNode(2, new TreeNode(1), new TreeNode(3));
var invertedRoot2 = InvertTree(root2);
Console.WriteLine(invertedRoot2?.ToString()); // Output: [2,3,1]

// Приклад 3
var root3 = new TreeNode();
var invertedRoot3 = InvertTree(root3);
Console.WriteLine(invertedRoot3?.ToString());  // Output: [0]

return;

TreeNode? InvertTree(TreeNode? root)
{
    if (root is null)
        return null;

    var temp = root.Left;
    root.Left = InvertTree(root.Right);
    root.Right = InvertTree(temp);
    return root;
}

public class TreeNode(int val = 0, TreeNode? left = null, TreeNode? right = null)
{
    public readonly int Val = val;
    public TreeNode? Left = left;
    public TreeNode? Right = right;

    public override string ToString()
    {
        var sb = new StringBuilder();
        DFS(this, sb);
        if (sb.Length > 0) 
            sb.Length--;

        return $"[{sb}]";
    }

    private static void DFS(TreeNode? node, StringBuilder sb)
    {
        while (true)
        {
            if (node == null) return;
            sb.Append(node.Val).Append(',');
            DFS(node.Left, sb);
            node = node.Right;
        }
    }
} 
