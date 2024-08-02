using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroupToggle : MonoBehaviour
{
    public GameObject group1; // ���̃O���[�v�Ɋ܂܂��I�u�W�F�N�g�̐e
    public GameObject group2;

    void Start()
    {
        // �V�[�������[�h���ꂽ�Ƃ��ɃO���[�v���\���ɂ���
        group1.SetActive(false);
        group2.SetActive(false);
    }

    public void ToggleGroup(int groupNumber)
    {
        Debug.Log("Button " + groupNumber + " clicked.");

        if (groupNumber == 1)
        {
            bool isActive = !group1.activeSelf;
            group1.SetActive(isActive);
            if (isActive)
            {
                group2.SetActive(false); // ��������̃O���[�v���\���ɂ���
            }
        }
        else if (groupNumber == 2)
        {
            bool isActive = !group2.activeSelf;
            group2.SetActive(isActive);
            if (isActive)
            {
                group1.SetActive(false); // ��������̃O���[�v���\���ɂ���
            }
        }
    }
}

