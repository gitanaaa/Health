using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class SceneMove : MonoBehaviour
{
    public Button MainScene1;
    public Button MainScene2;
    public Button MainScene3;

    public TextMeshProUGUI feedbackText; // Inspectorから割り当てる

    int count = 0;
    int count2 = 0;
    int count3 = 0;

    // SelectionManagerへの参照を保持するための変数
    public SelectionManager selectionManager;

    void Start()
    {
        // シーン内からSelectionManagerを探して参照を設定
        selectionManager = FindObjectOfType<SelectionManager>();
        /*if (selectionManager == null)
        {
            Debug.LogError("SelectionManager not found in the scene.");
        }*/
    }

    public void MoveScene(int num)
    {
        

        switch(num)//caseごとに処理されるので、カウントはそれぞれで加算になる
        {
            case 1:
                SceneManager.LoadScene("Quiz");
                break;

            case 2:
                SceneManager.LoadScene("Select");
                break;

            case 3:
                SceneManager.LoadScene("Calc");
                break;
        }
    }

    //解説のボタンを押して解説シーンへ、もしくは次の問題へ
    public void MoveEx(int num)
    {
        SceneManager.LoadScene("Exp" + num);
    }

    public void MoveNextQ(int num)
    { 
        SceneManager.LoadScene("Quiz" + num);  
    }

    public void BackTitle()
    {
        SceneManager.LoadScene("TitleScene");//タイトルへ戻る
    }

    public void ExScene(int num)
    {
        SceneManager.LoadScene("Explanation" + num);//身体活動レベルの説明シーンに遷移
    }

    public void BackScene()
    {   
        SceneManager.LoadScene("Calc");//エネルギー必要量計算シーンへ遷移
    }

    public void QuizBack(int num)
    {
        SceneManager.LoadScene("Quiz" + num);
    }

    public void BackCorrect()
    {
        SceneManager.LoadScene("CorrectScene");
    }

    public void BackSelect()
    {
        SceneManager.LoadScene("Select");
    }

    public void EvScene()
    {
        // 2つ以上のアイテムが選択されているか確認
        if (selectionManager != null && selectionManager.SelectedHolders.Count >= 1)
        {
            SceneManager.LoadScene("Evaluation");
        }
        /*else
        {
            Debug.LogWarning("Not enough items selected to transition to the Evaluation scene.");
            // 必要に応じてユーザーにフィードバックを与えるためのコードをここに追加
            if (feedbackText != null)
                feedbackText.text = "２個以上選択してね";
        }*/
    }
}
