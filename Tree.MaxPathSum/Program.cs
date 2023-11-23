var solution = new Solution();

// Приклад 1
var root1 = new TreeNode(1)
{
    Left = new TreeNode(2),
    Right = new TreeNode(3)
};
Console.WriteLine(solution.MaxPathSum(root1)); // Output: 6

// Приклад 2
var root2 = new TreeNode(-10)
{
    Left = new TreeNode(9),
    Right = new TreeNode(20)
    {
        Left = new TreeNode(15),
        Right = new TreeNode(7)
    }
};
Console.WriteLine(solution.MaxPathSum(root2)); // Output: 42

public class Solution
{
    private int _maxSum = int.MinValue;

    public int MaxPathSum(TreeNode? root)
    {
        MaxGain(root);
        return _maxSum;
    }

    private int MaxGain(TreeNode? node)
    {
        if (node is null)
        {
            return 0;
        }

        // Знаходимо максимальний шлях з лівого та правого піддерев
        var leftGain = Math.Max(MaxGain(node.Left), 0);
        var rightGain = Math.Max(MaxGain(node.Right), 0);

        // Оновлюємо максимальну суму, якщо поточний шлях більший за поточний максимум
        var newPathSum = node.Val + leftGain + rightGain;
        _maxSum = Math.Max(_maxSum, newPathSum);

        // Повертаємо максимальний шлях, що включає поточний вузол
        return node.Val + Math.Max(leftGain, rightGain);
    }
}

public class TreeNode(int val = 0, TreeNode? left = null, TreeNode? right = null)
{
    public readonly int Val = val;
    public TreeNode? Left = left;
    public TreeNode? Right = right;
}
