// Приклад 1
var node1 = new TreeNode();
var node2 = new TreeNode();
var node3 = new TreeNode();
var node4 = new TreeNode();

node1.Left = node2;
node2.Left = node3;
node2.Right = node4;

var solution1 = new Solution();
var cameras1 = solution1.MinCameraCover(node1); // Output: 1
Console.WriteLine(cameras1);

// Приклад 2
var node5 = new TreeNode();
var node6 = new TreeNode();
var node7 = new TreeNode();
var node8 = new TreeNode();
var node9 = new TreeNode();

node5.Left = node6;
node6.Left = node7;
node7.Right = node8;
node8.Right = node9;

var solution2 = new Solution();
var cameras2 = solution2.MinCameraCover(node5); // Output: 2
Console.WriteLine(cameras2);

public class Solution
{
    private const int NotMonitored = 0;
    private const int MonitoredNoCamera = 1;
    private const int MonitoredWithCamera = 2;
    private int _cameras;

    public int MinCameraCover(TreeNode? root)
    {
        var top = Dfs(root);
        return _cameras + (top == NotMonitored ? 1 : 0);
    }

    private int Dfs(TreeNode? node)
    {
        if (node is null)
            return MonitoredNoCamera;

        int left = Dfs(node.Left), right = Dfs(node.Right);

        if (left == MonitoredNoCamera && right == MonitoredNoCamera)
            return NotMonitored;

        if (left != NotMonitored && right != NotMonitored) 
            return MonitoredNoCamera;
        
        _cameras++;
        
        return MonitoredWithCamera;
    }
}

public class TreeNode(int val = 0, TreeNode? left = null, TreeNode? right = null)
{
    public readonly int Val = val;
    public TreeNode? Left = left;
    public TreeNode? Right = right;
}

