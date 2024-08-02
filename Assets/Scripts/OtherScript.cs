using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OtherScript : MonoBehaviour
{
    // NumberHolderオブジェクトへの参照
    public NumberHolder numberHolder;

    // 別のスクリプトからnumbersリストにアクセスするメソッド
    public void AccessNumbersList()
    {
        // NumberHolderオブジェクトが指定されているか確認
        if (numberHolder != null)
        {
            // numbersリストにアクセスして要素を表示
            foreach (int number in numberHolder.numbers)
            {
                Debug.Log("Number: " + number);
            }
        }
        else
        {
            Debug.LogError("NumberHolder object not set!");
        }
    }
}

