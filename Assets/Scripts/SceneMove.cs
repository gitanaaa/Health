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

    public TextMeshProUGUI feedbackText; // Inspector���犄�蓖�Ă�

    int count = 0;
    int count2 = 0;
    int count3 = 0;

    // SelectionManager�ւ̎Q�Ƃ�ێ����邽�߂̕ϐ�
    public SelectionManager selectionManager;

    void Start()
    {
        // �V�[��������SelectionManager��T���ĎQ�Ƃ�ݒ�
        selectionManager = FindObjectOfType<SelectionManager>();
        /*if (selectionManager == null)
        {
            Debug.LogError("SelectionManager not found in the scene.");
        }*/
    }

    public void MoveScene(int num)
    {
        

        switch(num)//case���Ƃɏ��������̂ŁA�J�E���g�͂��ꂼ��ŉ��Z�ɂȂ�
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

    //����̃{�^���������ĉ���V�[���ցA�������͎��̖���
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
        SceneManager.LoadScene("TitleScene");//�^�C�g���֖߂�
    }

    public void ExScene(int num)
    {
        SceneManager.LoadScene("Explanation" + num);//�g�̊������x���̐����V�[���ɑJ��
    }

    public void BackScene()
    {   
        SceneManager.LoadScene("Calc");//�G�l���M�[�K�v�ʌv�Z�V�[���֑J��
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
        // 2�ȏ�̃A�C�e�����I������Ă��邩�m�F
        if (selectionManager != null && selectionManager.SelectedHolders.Count >= 1)
        {
            SceneManager.LoadScene("Evaluation");
        }
        /*else
        {
            Debug.LogWarning("Not enough items selected to transition to the Evaluation scene.");
            // �K�v�ɉ����ă��[�U�[�Ƀt�B�[�h�o�b�N��^���邽�߂̃R�[�h�������ɒǉ�
            if (feedbackText != null)
                feedbackText.text = "�Q�ȏ�I�����Ă�";
        }*/
    }
}
