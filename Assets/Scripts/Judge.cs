using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Judge : MonoBehaviour
{
    int count = 0;

    //正解のシーンや不正解のシーンを配列で管理するなどして、複数のシーンに対応できるようにならないだろうか？
    //現状だとそれぞれ一個のシーンにしか移動できない
    //配列の場合、例えばインデックスに1ずつ足して、"Scene" + i　みたいに
    //ページ遷移後にi++とか
    public void JudgeAnswer(int num)
    {
        if(count != num)
        {
            count = num;
            if(num == 3)
            {
                SceneManager.LoadScene("CorrectScene");
            }
            else
            {
                SceneManager.LoadScene("FailedScene");
            }
        }
    }
}
