using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectionManager : MonoBehaviour
{
    private List<Clickable> selectedItems = new List<Clickable>();

    private List<NumberHolder> selectedHolders = new List<NumberHolder>();

    //�ێ�J�����[�ڈ���(��{�I�ɔ͈͂ŕ\������Ă��邽�߁A���ς��Ƃ��Ē����l���Q��)
    //List<float> divisors = new List<float> { 96.525f, 3.675f, 2.475f, 13.5f, 33.15f, 0.5235f, 4.95f, 0.375f };
    //������A�Ȃ�̐����H
    List<float> divisors = new List<float> { 643.5f, 24.5f, 16.5f, 90.0f, 221.0f, 3.49f, 33.0f, 2.5f };

    //���Z���ʂ��i�[���邽�߂̃��X�g
    List<float> adjustedSums = new List<float>();

    public void SelectObject(GameObject obj)
    {
        // Clickable�R���|�[�l���g���擾
        Clickable clickable = obj.GetComponent<Clickable>();

        NumberHolder numberHolder = obj.GetComponent<NumberHolder>();

        // Clickable�R���|�[�l���g�����݂��邩�m�F
        if (clickable == null)
        {
            Debug.LogError("Clickable component not found on " + obj.name);
            return;
        }

        // �I�u�W�F�N�g�����ɑI������Ă��邩�`�F�b�N
        if (selectedItems.Contains(clickable))
        {
            // ���łɑI������Ă���A�C�e��������
            selectedItems.Remove(clickable);
            clickable.Deselect();           
            selectedHolders.Remove(numberHolder);
            
        }
        else
        {
            // �V�����A�C�e����I��
            selectedItems.Add(clickable);
            clickable.Select();
            selectedHolders.Add(numberHolder);
           
        }

        CalculateSums(); // �v�Z���\�b�h���Ăяo��
    }

    public bool AreAllItemsSelected()
    {
        // �K�v�ȃA�C�e���̐�
        int requiredSelectionCount = 2; // �����ɕK�v�ȑI���A�C�e���̐���ݒ�
        return selectedItems.Count >= requiredSelectionCount;
    }

    private void CalculateSums()
    {
        if (selectedHolders.Count > 1)
        {
            // �ŏ��̃��X�g�����v�Z����
            int minLength = int.MaxValue;
            foreach (var holder in selectedHolders)
            {
                if (holder.numbers.Count < minLength)
                {
                    minLength = holder.numbers.Count;
                }
            }

            // �e�v�f�̘a���v�Z����
            List<float> sums = new List<float>(new float[minLength]);
            foreach (var holder in selectedHolders)
            {
                for (int i = 0; i < minLength; i++)
                {
                    //�ߑO�E�ߌ�ň����10�`20���̃G�l���M�[�Ƃ������ƂŁA�����l�Ōv�Z���Ă������ǁA
                    //���ʂɃJ�����[�̐����������Q�Ƃ������������񂶂�Ȃ���
                    //sums[i] += holder.numbers[i] * 0.15f;
                    sums[i] += holder.numbers[i];
                }
            }

            adjustedSums.Clear();
            //�a������̐ێ�J�����[�ڈ��Ŋ����āA�����Ƃ��ĎZ�o
            for (int i = 0; i < sums.Count; i++)
            {
                if (i < divisors.Count && divisors[i] != 0) // 0�Ŋ���Ȃ��悤�ɂ���
                {
                    adjustedSums.Add(sums[i] / divisors[i]);
                }
                else
                {
                    adjustedSums.Add(sums[i]); // ����l��0�܂��͑��݂��Ȃ��ꍇ�A���̒l���g�p
                }
            }

            // ���ʂ̕\��
            Debug.Log("Sum of elements: " + string.Join(", ", sums));

            // DataStorage�ɘa��ۑ�����
            if (DataHolder.Instance != null)
            {
                DataHolder.Instance.SaveSums(sums);// ���̘a��ۑ�
                DataHolder.Instance.SaveAdjustedSums(adjustedSums); // ������̘a��ۑ�
            }
            else
            {
                Debug.LogError("DataStorage instance not found.");
            }
        }
    }

    public List<NumberHolder> SelectedHolders
    {
        get { return selectedHolders; }
    }
}
