using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSALGO.DataStructure.Graph {
    public class NetworkList {
        // store vertice & edges with adjacency list
        public static NetworkList Parse(string filePath) {

            List<Edge> edges = new List<Edge>();

            string[] lines = File.ReadAllLines(filePath);

            // source & sink
            string[] vStr = lines[0].Split(" ");
            int source = int.Parse(vStr[0]);
            int sink = int.Parse(vStr[1]);
            // edges
            for (int i = 1; i < lines.Length; i++) {
                string[] eStr = lines[i].Split(" ");
                int from = int.Parse(eStr[0]);
                int to = int.Parse(eStr[1]);
                double weight = double.Parse(eStr[2]);
                Edge e = new(from, to, weight);
                edges.Add(e);
            }
            return new NetworkList(edges, source, sink);
        }

        private Dictionary<int, List<Pipe>> Network;  // adjacency list 
        public int NodeCount => Network.Count;
        public int Source;
        public int Sink;
        
        public List<int> GetAllNodes() => Network.Keys.ToList();
        public List<int> GetAdjNodes(int node) => Network[node].Select(x => x.dest).ToList();
        public List<Pipe> GetAdjPipes(int node) => Network[node];
        public NetworkList(List<Edge> edgeList, int Source, int Sink) {
            
            Network = new Dictionary<int, List<Pipe>>();
            this.Source = Source;
            this.Sink = Sink;
            foreach (var e in edgeList) {
                AddPipe(e.from, e.to, e.weight);
            }
        }
        public NetworkList(NetworkList previous) {
            Source = previous.Source;
            Sink = previous.Sink;
            Network = new Dictionary<int, List<Pipe>>();
            List<int> oldNodes = previous.GetAllNodes();
            foreach (var node in oldNodes) {
                List<Pipe> newPipe = new();
                foreach (var pipe in previous.GetAdjPipes(node)) {
                    newPipe.Add(new Pipe(pipe));
                }
                Network.Add(node, newPipe);
            }
        }
        public bool ContainsNode(int node) => Network.ContainsKey(node);
        public bool ContainsPipe(int from, int to) {
            if (!ContainsNode(from)) return false;
            List<int> nodes = GetAdjNodes(from);
            return nodes.Contains(to);
        }
        public void Print() {
            Console.WriteLine($"Source [{Source}], Sink [{Sink}]");
            List<int> nodes = GetAllNodes();
            foreach (var node in nodes) {
                Console.Write(node + " : ");
                List<Pipe> pipes = GetAdjPipes(node);
                Console.WriteLine(string.Join(", ", pipes));
            }
        }
        public void EditPipeFlow(int from, int to, double newflow) {
            if (!ContainsPipe(from, to)) throw new Exception($"Pipe ({from}, {to}) is not in graphs");
            Pipe pipe = Network[from].Find(x => x.dest == to);
            pipe.flow = newflow;
        }
        public void EditPipeCapacity(int from, int to, double capacity) {
            if (!ContainsPipe(from, to)) throw new Exception($"Pipe ({from}, {to}) is not in graphs");
            Pipe pipe = Network[from].Find(x => x.dest == to);
            pipe.capacity = capacity;
        }
        public void AddPipe(int from, int to, double capacity) {
            if (ContainsPipe(from, to))
                throw new Exception($"Pipe ({from},{to},) already exist");

            if (!ContainsNode(from)) AddNode(from);
            if (!ContainsNode(to)) AddNode(to);
            Network[from].Add(new Pipe(to, 0, capacity));
        }
        public void AddNode(int node) {
            if (Network.ContainsKey(node)) throw new Exception($"Node {node} already exist");
            Network.Add(node, new List<Pipe>());
        }
        public void DeleteNode(int node) {
            if (!Network.ContainsKey(node)) throw new Exception($"Node {node} is not in the graph");

            Network[node].Clear();
            Network.Remove(node);

            foreach (var n in GetAllNodes()) {
                List<int> adjNodes = GetAdjNodes(n);
                Network[n].RemoveAll(x => x.dest == node);
            }
        }
        public void DeleteEdge(int from, int to) {
            if (!ContainsNode(from)) throw new Exception($"Node {from} is not in the graph");
            if (!ContainsNode(to)) throw new Exception($"Node {to} is not in the graph");

            List<int> linkedNode = GetAdjNodes(from);

            if (!Network.ContainsKey(from) && !linkedNode.Contains(to)) {
                throw new Exception($"Edge ({from}, {to}) is not in graphs");
            }
            Network[from].RemoveAll(x => x.dest == to);
        }
        public void Clear() {
            foreach (var key in Network.Keys) Network[key].Clear();
            Network.Clear();
        }
        public GraphList ToResidualGraph() {
            GraphList residual = new(isUndirected:false);
            foreach (var node in GetAllNodes()) {
                foreach (var pipe in GetAdjPipes(node)) {
                    residual.AddEdge(node, pipe.dest, pipe.capacity - pipe.flow);
                }
            }
            return residual;
        }
    }
}
