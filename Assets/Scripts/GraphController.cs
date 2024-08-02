using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GraphController : MonoBehaviour
{
    // BarGraph�X�N���v�g�ւ̎Q��
    public BarGraph barGraph;

    void Start()
    {

        // DataHolder����f�[�^���擾���ăO���t�ɔ��f
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
