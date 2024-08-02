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
        //�e�{�^���ɏ����o�^
        QuitGameButton.onClick.AddListener(GameManager.QuitGame);//������GameManager�́A�����̊Ǘ��p�X�N���v�g��

        ClosePopUpButton.onClick.AddListener(OnClickClosePopUp);

        //�Q�[�������Ԃ��~
        Time.timeScale = 0;
    }

    /// <summary>
    /// �|�b�v�A�b�v����ăQ�[�����ĊJ
    /// </summary>
    private void OnClickClosePopUp()
    {
        //�Q�[�������Ԃ𓮂���
        Time.timeScale = 1.0f;
        Destroy(gameObject);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
