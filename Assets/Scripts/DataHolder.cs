using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataHolder : MonoBehaviour
{
    public static DataHolder Instance { get; private set; }
    public List<float> CalculatedSums { get; set; }
    public List<float> AdjustedSums { get; set; } // ��������̐��l��ۑ�


    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else if (Instance != this)
        {
            Destroy(gameObject);
        }
    }

    // ���̃��\�b�h�̓V�[���ԂŘa�̃f�[�^��ۑ����邽�߂Ɏg�p���܂��B
    public void SaveSums(List<float> sums)
    {
        CalculatedSums = sums;
    }

    public void SaveAdjustedSums(List<float> sums)
    {
        AdjustedSums = sums;
    }
}
