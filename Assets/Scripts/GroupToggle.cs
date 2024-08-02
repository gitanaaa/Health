using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroupToggle : MonoBehaviour
{
    public GameObject group1; // このグループに含まれるオブジェクトの親
    public GameObject group2;

    void Start()
    {
        // シーンがロードされたときにグループを非表示にする
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
                group2.SetActive(false); // もう一方のグループを非表示にする
            }
        }
        else if (groupNumber == 2)
        {
            bool isActive = !group2.activeSelf;
            group2.SetActive(isActive);
            if (isActive)
            {
                group1.SetActive(false); // もう一方のグループを非表示にする
            }
        }
    }
}

