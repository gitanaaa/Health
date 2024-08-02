using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ScrollHandler : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    private Vector2 panelStartPosition;
    private Vector2 dragStartPosition;

    public void OnBeginDrag(PointerEventData eventData)
    {
        // �h���b�O�J�n���̃p�l���̈ʒu��RectTransform��anchoredPosition����擾����
        panelStartPosition = this.GetComponent<RectTransform>().anchoredPosition;
        dragStartPosition = eventData.position; // �X�N���[�����W�����̂܂܎g�p
    }

    public void OnDrag(PointerEventData eventData)
    {
        // �h���b�O���̌��݈ʒu�ƊJ�n�ʒu�̍������v�Z
        Vector2 currentDragPosition = eventData.position;
        Vector2 difference = currentDragPosition - dragStartPosition;

        // RectTransform��anchoredPosition���X�V���ăX�N���[������
        this.GetComponent<RectTransform>().anchoredPosition = panelStartPosition + difference;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        // �h���b�O�I�����̏���
        // �������Ȃ��ꍇ�͋�̂܂܂ł��\���܂��񂪁A���\�b�h���͕̂K���K�v�ł��B
    }
}
