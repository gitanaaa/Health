using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuitCheckPouUp : MonoBehaviour
{
    public Button QuitGameButton;
    public Button ClosePopUpButton;

    // Start is called before the first frame update
    void Start()
    {
        //各ボタンに処理登録
        QuitGameButton.onClick.AddListener(GameManager.QuitGame);//引数のGameManagerは、自分の管理用スクリプト名

        ClosePopUpButton.onClick.AddListener(OnClickClosePopUp);

        //ゲーム内時間を停止
        Time.timeScale = 0;
    }

    /// <summary>
    /// ポップアップを閉じてゲームを再開
    /// </summary>
    private void OnClickClosePopUp()
    {
        //ゲーム内時間を動かす
        Time.timeScale = 1.0f;
        Destroy(gameObject);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
