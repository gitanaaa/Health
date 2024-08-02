using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NumberHolder : MonoBehaviour
{
    //public int number; // ゲームオブジェクトに持たせる数字のフィールド

    public List<float> numbers = new List<float>(); // 数字を保持するリスト

    // このスクリプトに他のコンポーネントからアクセスするためのメソッドやロジックを追加できます

    // リスト内の各数値に15%を掛ける
    public void ApplyPercentage()
    {
        for (int i = 0; i < numbers.Count; i++)
        {
            numbers[i] *= 0.15f; // 15%を掛ける
        }
    }
}
