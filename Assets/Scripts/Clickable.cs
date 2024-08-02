using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;
using UnityEngine.UI;

public class Clickable : MonoBehaviour, IPointerClickHandler
{
    private bool isSelected = false; // �A�C�e�����I������Ă��邩�ǂ����̏��

    public TextMeshProUGUI outputText;

    public SelectionManager selectionManager; // SelectionManager�ւ̎Q��

    // �����Ŗ|��̎������`
    private Dictionary<string, string> nameTranslations = new Dictionary<string, string>
    {

        { "potetii", "�|�e�g�`�b�v�X ���" },
        { "ringo", "��� ��؂�" },
        { "onigiri", "�����ɂ��� ���" },
        { "dorayaki", "�ǂ�Ă� ���" },
        { "orange", "�݂��� ���" },
        { "ice", "�A�C�X ���" },
        { "cake", "�V���[�g�P�[�L ���" },
        { "chocolate_cornet", "�`���R�R���l ���" },
        { "chocolate", "�`���R �ꖇ" },
        { "banana", "�o�i�i ��{" },
        { "senbei", "���傤�䂹��ׂ� �O��" },
        { "cookie", "�N�b�L�[ �O��" },    
        { "jelly", "�[���[ ���" },
        { "pudding", "�J�X�^�[�h�v���� ���" },
        { "nyusankin", "���_�ۈ��� ��{" },
        { "CO2", "�Â��Y�_���� �R�b�v��t" },
        { "tea", "�ق����� �R�b�v��t" },
        { "sports_drink", "�X�|�[�c�h�����N �R�b�v��t" },
        { "orange_juce", "100%�I�����W�W���[�X �R�b�v��t" },
        { "milk", "���� �R�b�v��t" },
        
        // ���̑��̖��O�ɂ��Ă����l�ɒǉ�
    };

    void Awake()
    {
        // �V�[��������SelectionManager��T���ĎQ�Ƃ�ݒ�
        selectionManager = FindObjectOfType<SelectionManager>();
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        // �I����Ԃ��g�O������
        isSelected = !isSelected;

        // �����Ŗ|����s���A���{��̖��O�����O�ɕ\��
        if (nameTranslations.TryGetValue(gameObject.name, out string japaneseName))
        {
            outputText.text = japaneseName;
            Debug.Log(japaneseName);
        }
        else
        {
            Debug.LogError("Translation not found for: " + gameObject.name);
        }

        if (selectionManager != null)
        {
            // SelectionManager��ʂ��đI���������s��
            selectionManager.SelectObject(gameObject);
        }
        else
        {
            Debug.LogError("SelectionManager not found in the scene.");
        }

        Debug.Log("�������H");
    }

    // ���̃R���|�[�l���g��I�u�W�F�N�g����Ăяo�����I�����\�b�h
    public void Select()
    {
        isSelected = true;
        // �I�����̃r�W���A���X�V�₻�̑��̏���
        transform.localScale *= 1.3f;
    }

    // �I���������\�b�h
    public void Deselect()
    {
        isSelected = false;
        // �I���������̃r�W���A���X�V�₻�̑��̏���
        transform.localScale /= 1.3f;
    }
}
