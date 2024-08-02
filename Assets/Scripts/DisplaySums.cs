using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DisplaySums : MonoBehaviour
{
    public List<TextMeshProUGUI> sumTexts; // Inspector���畡���̃e�L�X�g�{�b�N�X���A�T�C������

    public List<string> units = new List<string> { "kcal", "g", "g", "g", "mg", "mg", "mg", "g" }; // �P�ʂ����X�g�ŊǗ�

    void Start()
    {
        if (DataHolder.Instance != null && DataHolder.Instance.CalculatedSums != null)
        {
            for (int i = 0; i < sumTexts.Count && i < DataHolder.Instance.CalculatedSums.Count; i++)
            {
                string formattedValue;
                // ����̗v�f�𐮐��ŕ\��
                if (i == 0 || i == 4)
                {
                    formattedValue = $"{DataHolder.Instance.CalculatedSums[i]:F0}";
                }
                else // ���̑��̗v�f�������_���ʂ܂ŕ\��
                {
                    formattedValue = $"{DataHolder.Instance.CalculatedSums[i]:F1}";
                }

                sumTexts[i].text = $"{formattedValue} {units[i]}";
            }
        }
        else
        {
            foreach (var text in sumTexts)
            {
                text.text = "No data available.";
            }
        }
    }
}
