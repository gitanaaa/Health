using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectionManager : MonoBehaviour
{
    private List<Clickable> selectedItems = new List<Clickable>();

    private List<NumberHolder> selectedHolders = new List<NumberHolder>();

    //摂取カロリー目安量(基本的に範囲で表示されているため、平均をとって中央値を参照)
    //List<float> divisors = new List<float> { 96.525f, 3.675f, 2.475f, 13.5f, 33.15f, 0.5235f, 4.95f, 0.375f };
    //↑これ、なんの数字？
    List<float> divisors = new List<float> { 643.5f, 24.5f, 16.5f, 90.0f, 221.0f, 3.49f, 33.0f, 2.5f };

    //除算結果を格納するためのリスト
    List<float> adjustedSums = new List<float>();

    public void SelectObject(GameObject obj)
    {
        // Clickableコンポーネントを取得
        Clickable clickable = obj.GetComponent<Clickable>();

        NumberHolder numberHolder = obj.GetComponent<NumberHolder>();

        // Clickableコンポーネントが存在するか確認
        if (clickable == null)
        {
            Debug.LogError("Clickable component not found on " + obj.name);
            return;
        }

        // オブジェクトが既に選択されているかチェック
        if (selectedItems.Contains(clickable))
        {
            // すでに選択されているアイテムを解除
            selectedItems.Remove(clickable);
            clickable.Deselect();           
            selectedHolders.Remove(numberHolder);
            
        }
        else
        {
            // 新しくアイテムを選択
            selectedItems.Add(clickable);
            clickable.Select();
            selectedHolders.Add(numberHolder);
           
        }

        CalculateSums(); // 計算メソッドを呼び出す
    }

    public bool AreAllItemsSelected()
    {
        // 必要なアイテムの数
        int requiredSelectionCount = 2; // ここに必要な選択アイテムの数を設定
        return selectedItems.Count >= requiredSelectionCount;
    }

    private void CalculateSums()
    {
        if (selectedHolders.Count > 1)
        {
            // 最小のリスト長を計算する
            int minLength = int.MaxValue;
            foreach (var holder in selectedHolders)
            {
                if (holder.numbers.Count < minLength)
                {
                    minLength = holder.numbers.Count;
                }
            }

            // 各要素の和を計算する
            List<float> sums = new List<float>(new float[minLength]);
            foreach (var holder in selectedHolders)
            {
                for (int i = 0; i < minLength; i++)
                {
                    //午前・午後で一日の10～20％のエネルギーということで、中央値で計算していたけど、
                    //普通にカロリーの数字数字を参照した方がいいんじゃないか
                    //sums[i] += holder.numbers[i] * 0.15f;
                    sums[i] += holder.numbers[i];
                }
            }

            adjustedSums.Clear();
            //和を一日の摂取カロリー目安で割って、割合として算出
            for (int i = 0; i < sums.Count; i++)
            {
                if (i < divisors.Count && divisors[i] != 0) // 0で割らないようにする
                {
                    adjustedSums.Add(sums[i] / divisors[i]);
                }
                else
                {
                    adjustedSums.Add(sums[i]); // 割る値が0または存在しない場合、元の値を使用
                }
            }

            // 結果の表示
            Debug.Log("Sum of elements: " + string.Join(", ", sums));

            // DataStorageに和を保存する
            if (DataHolder.Instance != null)
            {
                DataHolder.Instance.SaveSums(sums);// 元の和を保存
                DataHolder.Instance.SaveAdjustedSums(adjustedSums); // 調整後の和を保存
            }
            else
            {
                Debug.LogError("DataStorage instance not found.");
            }
        }
    }

    public List<NumberHolder> SelectedHolders
    {
        get { return selectedHolders; }
    }
}
