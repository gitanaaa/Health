using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;
using UnityEngine.UI;

public class Clickable : MonoBehaviour, IPointerClickHandler
{
    private bool isSelected = false; // アイテムが選択されているかどうかの状態

    public TextMeshProUGUI outputText;

    public SelectionManager selectionManager; // SelectionManagerへの参照

    // ここで翻訳の辞書を定義
    private Dictionary<string, string> nameTranslations = new Dictionary<string, string>
    {

        { "potetii", "ポテトチップス 一袋" },
        { "ringo", "りんご 一切れ" },
        { "onigiri", "鮭おにぎり 一個" },
        { "dorayaki", "どら焼き 一個" },
        { "orange", "みかん 一個" },
        { "ice", "アイス 一個" },
        { "cake", "ショートケーキ 一個" },
        { "chocolate_cornet", "チョココロネ 一個" },
        { "chocolate", "板チョコ 一枚" },
        { "banana", "バナナ 一本" },
        { "senbei", "しょうゆせんべい 三枚" },
        { "cookie", "クッキー 三枚" },    
        { "jelly", "ゼリー 一個" },
        { "pudding", "カスタードプリン 一個" },
        { "nyusankin", "乳酸菌飲料 一本" },
        { "CO2", "甘い炭酸飲料 コップ一杯" },
        { "tea", "ほうじ茶 コップ一杯" },
        { "sports_drink", "スポーツドリンク コップ一杯" },
        { "orange_juce", "100%オレンジジュース コップ一杯" },
        { "milk", "牛乳 コップ一杯" },
        
        // その他の名前についても同様に追加
    };

    void Awake()
    {
        // シーン内からSelectionManagerを探して参照を設定
        selectionManager = FindObjectOfType<SelectionManager>();
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        // 選択状態をトグルする
        isSelected = !isSelected;

        // ここで翻訳を行い、日本語の名前をログに表示
        if (nameTranslations.TryGetValue(gameObject.name, out string japaneseName))
        {
            outputText.text = japaneseName;
            Debug.Log(japaneseName);
        }
        else
        {
            Debug.LogError("Translation not found for: " + gameObject.name);
        }

        if (selectionManager != null)
        {
            // SelectionManagerを通じて選択処理を行う
            selectionManager.SelectObject(gameObject);
        }
        else
        {
            Debug.LogError("SelectionManager not found in the scene.");
        }

        Debug.Log("押した？");
    }

    // 他のコンポーネントやオブジェクトから呼び出される選択メソッド
    public void Select()
    {
        isSelected = true;
        // 選択時のビジュアル更新やその他の処理
        transform.localScale *= 1.3f;
    }

    // 選択解除メソッド
    public void Deselect()
    {
        isSelected = false;
        // 選択解除時のビジュアル更新やその他の処理
        transform.localScale /= 1.3f;
    }
}
