using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using TMPro;

public class OutputSums : MonoBehaviour
{
    public TextMeshProUGUI outputText; // �e�L�X�g��\������UI�e�L�X�g�I�u�W�F�N�g�ւ̎Q��
    public List<float> sums; // sums���X�g�Ɋi�[���ꂽ����

    void Start()
    {
        // TriggerEnterScene�N���X��sums���X�g��ǂݍ���
        //sums = TriggerEnterScene.sums;

        // outputText��null�łȂ����Ƃ��m�F���Ă���\������
        if (outputText != null)
        {
            DisplaySums(sums);
        }
        else
        {
            Debug.LogWarning("OutputText is not assigned.");
        }

    }

    /*void Update()
    {

        if(sums != null)
        {
            DisplaySums(sums);
        }
    }*/

    // sums���X�g�Ɋi�[����Ă��鐔�����e�L�X�g�Ƃ��ďo�͂��郁�\�b�h
    public void DisplaySums(List<float> sums)
    {
        // sums���X�g�̗v�f�𕶎���ɕϊ����Č���
        string sumsText = string.Join(", ", sums.Select(x => x.ToString()).ToArray());

        // UI�e�L�X�g�I�u�W�F�N�g�Ƀe�L�X�g��ݒ�
        outputText.text = sumsText;
    }
}
