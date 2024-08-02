using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using TMPro;

public class OutputSums : MonoBehaviour
{
    public TextMeshProUGUI outputText; // テキストを表示するUIテキストオブジェクトへの参照
    public List<float> sums; // sumsリストに格納された数字

    void Start()
    {
        // TriggerEnterSceneクラスのsumsリストを読み込む
        //sums = TriggerEnterScene.sums;

        // outputTextがnullでないことを確認してから表示する
        if (outputText != null)
        {
            DisplaySums(sums);
        }
        else
        {
            Debug.LogWarning("OutputText is not assigned.");
        }

    }

    /*void Update()
    {

        if(sums != null)
        {
            DisplaySums(sums);
        }
    }*/

    // sumsリストに格納されている数字をテキストとして出力するメソッド
    public void DisplaySums(List<float> sums)
    {
        // sumsリストの要素を文字列に変換して結合
        string sumsText = string.Join(", ", sums.Select(x => x.ToString()).ToArray());

        // UIテキストオブジェクトにテキストを設定
        outputText.text = sumsText;
    }
}
