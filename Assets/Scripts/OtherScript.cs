using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OtherScript : MonoBehaviour
{
    // NumberHolder�I�u�W�F�N�g�ւ̎Q��
    public NumberHolder numberHolder;

    // �ʂ̃X�N���v�g����numbers���X�g�ɃA�N�Z�X���郁�\�b�h
    public void AccessNumbersList()
    {
        // NumberHolder�I�u�W�F�N�g���w�肳��Ă��邩�m�F
        if (numberHolder != null)
        {
            // numbers���X�g�ɃA�N�Z�X���ėv�f��\��
            foreach (int number in numberHolder.numbers)
            {
                Debug.Log("Number: " + number);
            }
        }
        else
        {
            Debug.LogError("NumberHolder object not set!");
        }
    }
}

