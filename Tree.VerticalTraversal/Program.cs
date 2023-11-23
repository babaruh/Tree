// Приклад 1

var root1 = new TreeNode(3)
{
    Left = new TreeNode(9),
    Right = new TreeNode(20)
    {
        Left = new TreeNode(15),
        Right = new TreeNode(7)
    }
};

var solution1 = new Solution();
var result1 = solution1.VerticalTraversal(root1);

Console.WriteLine("Приклад 1:");
foreach (var list in result1)
{
    Console.WriteLine(string.Join(", ", list));
} //  [[9],[3,15],[20],[7]]

// Приклад 2
var root2 = new TreeNode(1)
{
    Left = new TreeNode(2)
    {
        Left = new TreeNode(4),
        Right = new TreeNode(5)
    },
    Right = new TreeNode(3)
    {
        Left = new TreeNode(6),
        Right = new TreeNode(7)
    }
};
var solution2 = new Solution();
var result2 = solution2.VerticalTraversal(root2);

Console.WriteLine("Приклад 2:");
foreach (var list in result2)
{
    Console.WriteLine(string.Join(", ", list));
} // [[4],[2],[1,5,6],[3],[7]]

// Приклад 3
var root3 = new TreeNode(1)
{
    Left = new TreeNode(2)
    {
        Left = new TreeNode(4),
        Right = new TreeNode(6)
    },
    Right = new TreeNode(3)
    {
        Left = new TreeNode(5),
        Right = new TreeNode(7)
    }
};
var solution3 = new Solution();
var result3 = solution3.VerticalTraversal(root3);

Console.WriteLine("Приклад 3:");
foreach (var list in result3)
{
    Console.WriteLine(string.Join(", ", list));
} // [[4],[2],[1,5,6],[3],[7]]

public class Solution
{
    private readonly Dictionary<int, List<(int row, int val)>> _columnTable = new();
    private int _minColumn, _maxColumn;

    public IList<IList<int>> VerticalTraversal(TreeNode? root)
    {
        DFS(root, 0, 0);
        IList<IList<int>> output = new List<IList<int>>();
        for (var i = _minColumn; i < _maxColumn + 1; ++i)
        {
            var entries = _columnTable[i];
            
            entries.Sort((a, b) => a.row != b.row 
                ? a.row - b.row 
                : a.val - b.val);
            
            var sortedColumn = new List<int>();
            foreach (var (_, val) in entries)
                sortedColumn.Add(val);
            
            output.Add(sortedColumn);
        }

        return output;
    }

    private void DFS(TreeNode? node, int row, int column)
    {
        while (true)
        {
            if (node is null) return;
            
            if (!_columnTable.ContainsKey(column)) 
                _columnTable[column] = new List<(int row, int val)>();
            
            _columnTable[column].Add((row, node.Val));
            
            _minColumn = Math.Min(_minColumn, column);
            _maxColumn = Math.Max(_maxColumn, column);
            
            DFS(node.Left, row + 1, column - 1);
            
            node = node.Right;
            row += 1;
            column += 1;
        }
    }
}

public class TreeNode(int val = 0, TreeNode? left = null, TreeNode? right = null)
{
    public readonly int Val = val;
    public TreeNode? Left = left;
    public TreeNode? Right = right;
}
