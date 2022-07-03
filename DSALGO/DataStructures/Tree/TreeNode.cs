using System.Text;

namespace DSALGO.DataStructures.Tree {
    public class TreeNode {
        public int key;
        public TreeNode parent;

        public List<TreeNode> children = new List<TreeNode>();
        public TreeNode(int key, TreeNode parent = null) {
            this.key = key;
            this.parent = parent;
        }

        public TreeNode(int key, List<int> children, TreeNode parent = null) {
            this.key = key;

            foreach (var child in children) {
                AddChild(new TreeNode(child));
            }
            this.parent = parent;
        }
        public void AddChild(TreeNode node) {
            node.parent = this;
            children.Add(node);
        }

        public void PrintTree() {
            StringBuilder sb = new StringBuilder();
            Queue<TreeNode> queue = new Queue<TreeNode>();

            queue.Enqueue(this);
            while (queue.Count > 0) {

                TreeNode pop = queue.Dequeue();

                pop.PrintNode();

                foreach (var node in pop.children) {
                    queue.Enqueue(node);
                }

            }
        }
        public void PrintNode() {
            string childStr = "";
            if (parent != null) {
                childStr += "P = " + parent.key + " | ";
            }
            childStr += key + " : ";
            foreach (var node in children) {
                childStr += node.key + ", ";
            }

            Console.WriteLine(childStr);
        }
    }
}
