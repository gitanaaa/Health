using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NumberHolder : MonoBehaviour
{
    //public int number; // �Q�[���I�u�W�F�N�g�Ɏ������鐔���̃t�B�[���h

    public List<float> numbers = new List<float>(); // ������ێ����郊�X�g

    // ���̃X�N���v�g�ɑ��̃R���|�[�l���g����A�N�Z�X���邽�߂̃��\�b�h�⃍�W�b�N��ǉ��ł��܂�

    // ���X�g���̊e���l��15%���|����
    public void ApplyPercentage()
    {
        for (int i = 0; i < numbers.Count; i++)
        {
            numbers[i] *= 0.15f; // 15%���|����
        }
    }
}
