using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;


[RequireComponent(typeof(CanvasRenderer))]
[ExecuteInEditMode]

public class BarGraph : Graphic
{
    //public float[] data;
    // バーグラフのデータ
    public List<float> data = new List<float>();

    // バーグラフを更新するメソッド
    public void UpdateGraph(List<float> newData)
    {
        data.Clear();
        data.AddRange(newData);
        SetVerticesDirty();
    }

    float graphWidth;
    float graphHeight;
    float barWidth;
    float maxDataValue;

    protected override void OnPopulateMesh(VertexHelper vh)
    {
        vh.Clear();

        if (data == null || data.Count == 0) return;

        graphWidth = rectTransform.rect.width;
        graphHeight = rectTransform.rect.height;

        barWidth = graphWidth / data.Count;
        maxDataValue = Mathf.Max(data.ToArray());

        for(int i = 0; i < data.Count; i++)
        {
            float x = i * barWidth;
            //バーの高さを計算
            float barHeight = (data[i] / maxDataValue) * graphHeight;
            Color barColor = GetColorForValue(data[i]); // 値に基づいて色を取得
            AddBar(x, barHeight, barWidth, vh, barColor);

            // 区切り線を描画
            DrawSeparators(vh);
       
        }
    }

    private void AddBar(float x, float height, float width, VertexHelper vh, Color color)
    {
        //バーの四隅の頂点を作成
        UIVertex[] quad = new UIVertex[4];
        quad[0].position = new Vector3(x, 0);
        quad[1].position = new Vector3(x + barWidth, 0);
        quad[2].position = new Vector3(x + barWidth, height);
        quad[3].position = new Vector3(x, height);

        for (int j = 0; j < 4; j++) quad[j].color = color;
        //バーの四隅の頂点を追加
        vh.AddUIVertexQuad(quad);
    }

    // 区切り線を描画するメソッド
    private void DrawSeparators(VertexHelper vh)
    {
        float separatorWidth = 1f; // 区切り線の幅
        Color separatorColor = Color.black; // 区切り線の色

        for (int i = 0; i < data.Count - 1; i++)
        {
            float separatorXPos = (i + 1) * barWidth;
            float barHeight = (data[i] / maxDataValue) * graphHeight; // 現在のバーの最大高さを取得

            UIVertex[] quad = new UIVertex[4];
            quad[0].position = new Vector3(separatorXPos, 0);
            quad[1].position = new Vector3(separatorXPos + separatorWidth, 0);
            quad[2].position = new Vector3(separatorXPos + separatorWidth, barHeight);
            quad[3].position = new Vector3(separatorXPos, barHeight);

            for (int j = 0; j < 4; j++) quad[j].color = separatorColor;

            // 区切り線の四隅の頂点を追加
            vh.AddUIVertexQuad(quad);
        }
     }
    
    //算出した割合に応じてグラフの色を変更
    Color GetColorForValue(float value)
    {
        if (value >= 2.0f) return new Color(0.85f, 0.1f, 0.0f); // 暗い赤色
        else if (value >= 1.1f) return Color.yellow;
        else return Color.green; // デフォルトの色を緑とする
    }
}

