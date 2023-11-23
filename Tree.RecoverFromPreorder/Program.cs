using System.Text;

var solution1 = new Solution();
var root1 = solution1.RecoverFromPreorder("1-2--3--4-5--6--7");
Console.WriteLine(root1?.ToString()); // Output: [1,2,5,3,4,6,7]

var solution2 = new Solution();
var root2 = solution2.RecoverFromPreorder("1-2--3---4-5--6---7");
Console.WriteLine(root2?.ToString()); // Output: [1,2,5,3,null,6,null,4,null,7]

var solution3 = new Solution();
var root3 = solution3.RecoverFromPreorder("1-401--349---90--88");
Console.WriteLine(root3?.ToString()); // Output: [1,401,null,349,88,90]

public class Solution
{
    private int _index;

    public TreeNode? RecoverFromPreorder(string s)
    {
        return Helper(s, 0);
    }

    private TreeNode? Helper(string s, int depth)
    {
        var numberOfDashes = 0;
        while (_index + numberOfDashes < s.Length && s[_index + numberOfDashes] == '-') 
            numberOfDashes++;

        if (numberOfDashes != depth)
            return null;

        var next = numberOfDashes;
        while (_index + next < s.Length && s[_index + next] != '-') 
            next++;

        var val = int.Parse(s.Substring(_index + numberOfDashes, next - numberOfDashes));
        _index += next;

        var node = new TreeNode(val)
        {
            Left = Helper(s, depth + 1),
            Right = Helper(s, depth + 1)
        };
        return node;
    }
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

