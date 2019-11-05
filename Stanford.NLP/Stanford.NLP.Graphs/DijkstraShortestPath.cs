using System;
using System.Collections.Generic;
using System.Text;
using System.Collections.Specialized;

namespace Stanford.NLP.Graphs
{
    public static class DijkstraShortestPath
    {
        public static IEnumerable<TVertex> GetShortestPath<TVertex,TEdge>(IGraph<TVertex,TEdge> graph, TVertex node1, TVertex node2, bool directionSensitive)
        {
            if (node1.Equals(node2))
                return new[] { node2 };

            var visited = new HashSet<TVertex>();

            var previous = new Dictionary<TVertex, TVertex>();

            return null; // TODO
        }

    }
}
