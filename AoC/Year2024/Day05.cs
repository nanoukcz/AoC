namespace AoC.Year2024;

public class Day05 : BaseDay
{
    private readonly Dictionary<int, List<int>> _edges = [];
    private readonly List<List<int>> _manuals = [];

    protected override void ParseInput()
    {
        foreach (var line in File.ReadLines(InputFilePath).Where(line => !string.IsNullOrEmpty(line)))
        {
            if (line.Contains('|'))
            {
                var nodes = line.Split('|').Select(int.Parse).ToArray();
                if (!_edges.TryGetValue(nodes[0], out var value))
                {
                    value = [];
                    _edges[nodes[0]] = value;
                }

                value.Add(nodes[1]);
            }
            else
            {
                _manuals.Add(line.Split(',').Select(int.Parse).ToList());
            }
        }
    }

    protected override void SolveBothParts()
    {
        foreach (var manual in _manuals)
        {
            var sortedManual = SortManual(manual);
            var middleValue = sortedManual[manual.Count / 2];

            if (manual.SequenceEqual(sortedManual))
            {
                Solution1 += middleValue;
            }
            else
            {
                Solution2 += middleValue;
            }
        }
    }

    private List<int> SortManual(List<int> manual)
    {
        var relevantNodes = new HashSet<int>(manual);
        var visited = new Dictionary<int, bool>();
        
        foreach (var node in relevantNodes) visited[node] = false;

        var topologicalOrder = new LinkedList<int>();

        foreach (var node in relevantNodes.Where(node => !visited[node]))
        {
            Visit(node, relevantNodes, visited, topologicalOrder);
        }

        var indexMap = topologicalOrder
            .Select((value, index) => (value, index))
            .ToDictionary(x => x.value, x => x.index);

        return manual.OrderBy(value => indexMap[value]).ToList();
    }

    private void Visit(int node, HashSet<int> relevantNodes, Dictionary<int, bool> visited, LinkedList<int> result)
    {
        if (visited[node] || !relevantNodes.Contains(node)) return;

        visited[node] = true;

        if (_edges.TryGetValue(node, out var neighbors))
        {
            foreach (var neighbor in neighbors.Where(relevantNodes.Contains))
            {
                Visit(neighbor, relevantNodes, visited, result);
            }
        }
        result.AddFirst(node);
    }
}