using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataHolder : MonoBehaviour
{
    public static DataHolder Instance { get; private set; }
    public List<float> CalculatedSums { get; set; }
    public List<float> AdjustedSums { get; set; } // 割った後の数値を保存


    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else if (Instance != this)
        {
            Destroy(gameObject);
        }
    }

    // このメソッドはシーン間で和のデータを保存するために使用します。
    public void SaveSums(List<float> sums)
    {
        CalculatedSums = sums;
    }

    public void SaveAdjustedSums(List<float> sums)
    {
        AdjustedSums = sums;
    }
}
