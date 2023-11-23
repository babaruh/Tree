using System.Text;

var codec = new Codec();

// Приклад 1
var root1 = new TreeNode(1, new TreeNode(2), new TreeNode(3, new TreeNode(4), new TreeNode(5)));
var str1 = codec.Serialize(root1);
Console.WriteLine(str1); // Output: 1,2,null,null,3,4,null,null,5,null,null
var tree1 = codec.Deserialize(str1);
Console.WriteLine(codec.Serialize(tree1)); // Output: 1,2,null,null,3,4,null,null,5,null,null

// Приклад 2
var root2 = new TreeNode();
var str2 = codec.Serialize(root2);
Console.WriteLine(str2); // Output: null
var tree2 = codec.Deserialize(str2);
Console.WriteLine(codec.Serialize(tree2)); // Output: null

public class Codec
{
    // Encodes a tree to a single string.
    public string Serialize(TreeNode? root)
    {
        return root?.Val is null 
            ? "null" 
            : $"{root.Val},{Serialize(root.Left)},{Serialize(root.Right)}";
    }

    // Decodes your encoded data to tree.
    public TreeNode? Deserialize(string data)
    {
        var dataList = new Queue<string>(data.Split(','));

        return BuildTree(dataList);
    }

    private TreeNode? BuildTree(Queue<string> dataList)
    {
        var val = dataList.Dequeue();
        if (val == "null")
            return null;

        var node = new TreeNode(Convert.ToInt32(val))
        {
            Left = BuildTree(dataList),
            Right = BuildTree(dataList)
        };

        return node;
    }
}

public class TreeNode(int? val = null, TreeNode? left = null, TreeNode? right = null)
{
    public readonly int? Val = val;
    public TreeNode? Left = left;
    public TreeNode? Right = right;
}
