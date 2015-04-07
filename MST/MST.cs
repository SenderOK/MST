using System;
using System.Collections.Generic;

namespace MST
{
    public static class MST
    {
        public const double Inf = 1e150;

        // takes on the input symmetric positive weight matrix g
        public static MSTResults FindMST(double[][] g)
        {
            // preparing variables
            int n = g.Length;
            double[] minDist = new double[n];
            int[] minNode = new int[n];
            bool[] addedNodes = new bool[n];

            // preparing result
            List<List<int>> tree = new List<List<int>>();
            for (int i = 0; i < n; ++i)
            {
                tree.Add(new List<int>());
            }
            double weight = 0;

            // at first only 0 node is in the tree
            for (int i = 0; i < n; ++i)
            {
                minDist[i] = g[i][0];
                minNode[i] = 0;
                addedNodes[i] = false;
            }
            //minDist[0] = Inf;
            addedNodes[0] = true;
            
            for (int i = 0; i < n - 1; ++i)
            {
                // finding closest node
                double currMinDist = Inf;
                int currMinNode = 0;
                for (int j = 0; j < n; ++j)
                {
                    //if (minDist[j] < currMinDist)
                    if (!addedNodes[j] && minDist[j] < currMinDist)
                    {
                        currMinDist = minDist[j];
                        currMinNode = j;
                    }
                }                

                // adding the node to MST
                weight += currMinDist;
                //minDist[currMinNode] = Inf;
                addedNodes[currMinNode] = true;
                tree[currMinNode].Add(minNode[currMinNode]);
                tree[minNode[currMinNode]].Add(currMinNode);

                // recalculating minNodes
                for (int j = 0; j < n; ++j)
                {
                    //if (minDist[j] < Inf && minDist[j] > g[j][currMinNode])
                    if (!addedNodes[j] && minDist[j] > g[j][currMinNode])
                    {
                        minDist[j] = g[j][currMinNode];
                        minNode[j] = currMinNode;
                    }
                }
            }

            return new MSTResults(tree, weight);
        }
    }

    public class MSTResults
    {
        public List<List<int>> Tree { get; private set; }
        public double Weight { get; private set; }

        public MSTResults(List<List<int>> tree, double weight)
        {
            Tree = tree;
            Weight = weight;
        }
    }
}
