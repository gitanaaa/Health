using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Judge : MonoBehaviour
{
    int count = 0;

    //�����̃V�[����s�����̃V�[����z��ŊǗ�����Ȃǂ��āA�����̃V�[���ɑΉ��ł���悤�ɂȂ�Ȃ����낤���H
    //���󂾂Ƃ��ꂼ���̃V�[���ɂ����ړ��ł��Ȃ�
    //�z��̏ꍇ�A�Ⴆ�΃C���f�b�N�X��1�������āA"Scene" + i�@�݂�����
    //�y�[�W�J�ڌ��i++�Ƃ�
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
