using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GraphController : MonoBehaviour
{
    // BarGraphスクリプトへの参照
    public BarGraph barGraph;

    void Start()
    {

        // DataHolderからデータを取得してグラフに反映
        if (DataHolder.Instance != null && DataHolder.Instance.AdjustedSums != null)
        {
            Debug.Log("Loaded: " + string.Join(", ", DataHolder.Instance.AdjustedSums));
            barGraph.UpdateGraph(DataHolder.Instance.AdjustedSums);
        }
        else
        {
            Debug.LogError("DataHolder not found or no sums calculated.");
        }
    }
}
