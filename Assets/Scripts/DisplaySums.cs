using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DisplaySums : MonoBehaviour
{
    public List<TextMeshProUGUI> sumTexts; // Inspectorから複数のテキストボックスをアサインする

    public List<string> units = new List<string> { "kcal", "g", "g", "g", "mg", "mg", "mg", "g" }; // 単位をリストで管理

    void Start()
    {
        if (DataHolder.Instance != null && DataHolder.Instance.CalculatedSums != null)
        {
            for (int i = 0; i < sumTexts.Count && i < DataHolder.Instance.CalculatedSums.Count; i++)
            {
                string formattedValue;
                // 特定の要素を整数で表示
                if (i == 0 || i == 4)
                {
                    formattedValue = $"{DataHolder.Instance.CalculatedSums[i]:F0}";
                }
                else // その他の要素を小数点第一位まで表示
                {
                    formattedValue = $"{DataHolder.Instance.CalculatedSums[i]:F1}";
                }

                sumTexts[i].text = $"{formattedValue} {units[i]}";
            }
        }
        else
        {
            foreach (var text in sumTexts)
            {
                text.text = "No data available.";
            }
        }
    }
}
