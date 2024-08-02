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
        // ドラッグ開始時のパネルの位置をRectTransformのanchoredPositionから取得する
        panelStartPosition = this.GetComponent<RectTransform>().anchoredPosition;
        dragStartPosition = eventData.position; // スクリーン座標をそのまま使用
    }

    public void OnDrag(PointerEventData eventData)
    {
        // ドラッグ中の現在位置と開始位置の差分を計算
        Vector2 currentDragPosition = eventData.position;
        Vector2 difference = currentDragPosition - dragStartPosition;

        // RectTransformのanchoredPositionを更新してスクロールする
        this.GetComponent<RectTransform>().anchoredPosition = panelStartPosition + difference;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        // ドラッグ終了時の処理
        // 何もしない場合は空のままでも構いませんが、メソッド自体は必ず必要です。
    }
}
