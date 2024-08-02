using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public QuitCheckPouUp quitCheckPopUpPrefab;
    public Transform canvasTran;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            //終了のポップアップを生成。ポップアップの中で終了確認
            Instantiate(quitCheckPopUpPrefab, canvasTran, false);
        }
    }

    ///<summary>
    ///ゲームの終了処理(staticメソッドにすることで、終了確認用ポップアップからも呼び出せる)
    ///</summary>
    //#の後ろに付けたものごとの実行環境に応じた処理
    //UnityEditorとそれ以外の環境によって終了処理が自動的に分岐される
    public static void QuitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;//UnityEditorの実行を停止する処理
#else
            Application.Quit();//終了処理]
#endif
    }
}
