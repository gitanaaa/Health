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
    // �o�[�O���t�̃f�[�^
    public List<float> data = new List<float>();

    // �o�[�O���t���X�V���郁�\�b�h
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
            //�o�[�̍������v�Z
            float barHeight = (data[i] / maxDataValue) * graphHeight;
            Color barColor = GetColorForValue(data[i]); // �l�Ɋ�Â��ĐF���擾
            AddBar(x, barHeight, barWidth, vh, barColor);

            // ��؂����`��
            DrawSeparators(vh);
       
        }
    }

    private void AddBar(float x, float height, float width, VertexHelper vh, Color color)
    {
        //�o�[�̎l���̒��_���쐬
        UIVertex[] quad = new UIVertex[4];
        quad[0].position = new Vector3(x, 0);
        quad[1].position = new Vector3(x + barWidth, 0);
        quad[2].position = new Vector3(x + barWidth, height);
        quad[3].position = new Vector3(x, height);

        for (int j = 0; j < 4; j++) quad[j].color = color;
        //�o�[�̎l���̒��_��ǉ�
        vh.AddUIVertexQuad(quad);
    }

    // ��؂����`�悷�郁�\�b�h
    private void DrawSeparators(VertexHelper vh)
    {
        float separatorWidth = 1f; // ��؂���̕�
        Color separatorColor = Color.black; // ��؂���̐F

        for (int i = 0; i < data.Count - 1; i++)
        {
            float separatorXPos = (i + 1) * barWidth;
            float barHeight = (data[i] / maxDataValue) * graphHeight; // ���݂̃o�[�̍ő卂�����擾

            UIVertex[] quad = new UIVertex[4];
            quad[0].position = new Vector3(separatorXPos, 0);
            quad[1].position = new Vector3(separatorXPos + separatorWidth, 0);
            quad[2].position = new Vector3(separatorXPos + separatorWidth, barHeight);
            quad[3].position = new Vector3(separatorXPos, barHeight);

            for (int j = 0; j < 4; j++) quad[j].color = separatorColor;

            // ��؂���̎l���̒��_��ǉ�
            vh.AddUIVertexQuad(quad);
        }
     }
    
    //�Z�o���������ɉ����ăO���t�̐F��ύX
    Color GetColorForValue(float value)
    {
        if (value >= 2.0f) return new Color(0.85f, 0.1f, 0.0f); // �Â��ԐF
        else if (value >= 1.1f) return Color.yellow;
        else return Color.green; // �f�t�H���g�̐F��΂Ƃ���
    }
}

