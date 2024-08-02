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
            //�I���̃|�b�v�A�b�v�𐶐��B�|�b�v�A�b�v�̒��ŏI���m�F
            Instantiate(quitCheckPopUpPrefab, canvasTran, false);
        }
    }

    ///<summary>
    ///�Q�[���̏I������(static���\�b�h�ɂ��邱�ƂŁA�I���m�F�p�|�b�v�A�b�v������Ăяo����)
    ///</summary>
    //#�̌��ɕt�������̂��Ƃ̎��s���ɉ���������
    //UnityEditor�Ƃ���ȊO�̊��ɂ���ďI�������������I�ɕ��򂳂��
    public static void QuitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;//UnityEditor�̎��s���~���鏈��
#else
            Application.Quit();//�I������]
#endif
    }
}
