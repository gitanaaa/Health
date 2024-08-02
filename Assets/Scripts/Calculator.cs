using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Calculator : MonoBehaviour
{
    public TMP_InputField inputField;
    public TMP_InputField inputField2;
    public TMP_InputField inputField3;
    public TMP_InputField inputField4;
    public TextMeshProUGUI outputText;

    public void CalculateResult()
    {
        /*float number;
        float number2;
        float number3;
        float number4;*/

        //���͂��ꂽ�l�������񂩐��l������
        /*bool inputValue = float.TryParse(inputField.text, out number);
        bool inputValue2 = float.TryParse(inputField2.text, out number);
        bool inputValue3 = float.TryParse(inputField3.text, out number);
        bool inputValue4 = float.TryParse(inputField4.text, out number);*/

        // �e�C���v�b�g�t�B�[���h����e�L�X�g���擾���A���ꂼ��̒l�ɕϊ����Čv�Z
        float inputValue = float.Parse(inputField.text);
        float inputValue2 = float.Parse(inputField2.text);
        //float inputValue3 = float.Parse(inputField3.text);
        float inputValue4 = float.Parse(inputField4.text);

        //���ʂ��j�̂Ƃ��̏���   �}�C�i�X�̒l����͂��ꂽ�獢��̂ŁA�G���[���b�Z�[�W���o���悤�ɂ�����
        if(inputValue == 1)
        {
            if (inputValue2 == 1 || inputValue2 == 2)
            {
                inputValue2 = 700;

                //���͂��ꂽ�g�̊������x�����Ƃ̐��l
                if (1 <= inputValue4 && inputValue4 <= 3)
                {
                    inputValue4 = 1.35f;
                }
            }
            else if(3 <= inputValue2 && inputValue2 <= 5)
            {
                inputValue2 = 900;

                if (1 <= inputValue4 && inputValue4 <= 3)
                {
                    inputValue4 = 1.45f;
                }
            }
            else if(6 <= inputValue2 && inputValue2 <= 7)
            {
                inputValue2 = 980;

                if (inputValue4 == 1)
                {
                    inputValue4 = 1.35f;
                }
                else if (inputValue4 == 2)
                {
                    inputValue4 = 1.55f;
                }
                else
                {
                    inputValue4 = 1.75f;
                }
            }
            else if(8 <= inputValue2 && inputValue2 <= 9)
            {
                inputValue2 = 1140;

                if (inputValue4 == 1)
                {
                    inputValue4 = 1.4f;
                }
                else if (inputValue4 == 2)
                {
                    inputValue4 = 1.6f;
                }
                else
                {
                    inputValue4 = 1.8f;
                }
            }
            else if (10 <= inputValue2 && inputValue2 <= 11)
            {
                inputValue2 = 1330;

                if (inputValue4 == 1)
                {
                    inputValue4 = 1.45f;
                }
                else if (inputValue4 == 2)
                {
                    inputValue4 = 1.65f;
                }
                else
                {
                    inputValue4 = 1.85f;
                }
            }
            else if (12 <= inputValue2 && inputValue2 <= 14)
            {
                inputValue2 = 1520;

                if (inputValue4 == 1)
                {
                    inputValue4 = 1.5f;
                }
                else if (inputValue4 == 2)
                {
                    inputValue4 = 1.7f;
                }
                else
                {
                    inputValue4 = 1.9f;
                }
            }
            else if (15 <= inputValue2 && inputValue2 <= 17)
            {
                inputValue2 = 1610;

                if (inputValue4 == 1)
                {
                    inputValue4 = 1.55f;
                }
                else if (inputValue4 == 2)
                {
                    inputValue4 = 1.75f;
                }
                else
                {
                    inputValue4 = 1.95f;
                }
            }
            else if (18 <= inputValue2 && inputValue2 <= 29)
            {
                inputValue2 = 1530;

                if (inputValue4 == 1)
                {
                    inputValue4 = 1.5f;
                }
                else if (inputValue4 == 2)
                {
                    inputValue4 = 1.75f;
                }
                else
                {
                    inputValue4 = 2.0f;
                }
            }
            else if (30 <= inputValue2 && inputValue2 <= 49)
            {
                inputValue2 = 1530;

                if (inputValue4 == 1)
                {
                    inputValue4 = 1.5f;
                }
                else if (inputValue4 == 2)
                {
                    inputValue4 = 1.75f;
                }
                else
                {
                    inputValue4 = 2.0f;
                }
            }
            else if (50 <= inputValue2 && inputValue2 <= 64)
            {
                inputValue2 = 1480;

                if (inputValue4 == 1)
                {
                    inputValue4 = 1.5f;
                }
                else if (inputValue4 == 2)
                {
                    inputValue4 = 1.75f;
                }
                else
                {
                    inputValue4 = 2.0f;
                }
            }
            else if (65 <= inputValue2 && inputValue2 <= 74)
            {
                inputValue2 = 1400;

                if (inputValue4 == 1)
                {
                    inputValue4 = 1.45f;
                }
                else if (inputValue4 == 2)
                {
                    inputValue4 = 1.7f;
                }
                else
                {
                    inputValue4 = 1.95f;
                }
            }
            else
            {
                inputValue2 = 1280;

                if (inputValue4 == 1)
                {
                    inputValue4 = 1.4f;
                }
                else
                {
                    inputValue4 = 1.65f;
                }
            }
        }

        //���ʂ����̂Ƃ�
        if (inputValue == 2)
        {
            if (inputValue2 == 1 || inputValue2 == 2)
            {
                inputValue2 = 660;

                //���͂��ꂽ�g�̊������x�����Ƃ̐��l
                if(1 <= inputValue4 && inputValue4 <= 3)
                {
                    inputValue4 = 1.35f;
                }
            }
            else if (3 <= inputValue2 && inputValue2 <= 5)
            {
                inputValue2 = 840;

                if (1 <= inputValue4 && inputValue4 <= 3)
                {
                    inputValue4 = 1.45f;
                }

            }
            else if (6 <= inputValue2 && inputValue2 <= 7)
            {
                inputValue2 = 920;

                if (inputValue4 == 1)
                {
                    inputValue4 = 1.35f;
                }
                else if(inputValue4 == 2)
                {
                    inputValue4 = 1.55f;
                }
                else
                {
                    inputValue4 = 1.75f;
                }
            }
            else if (8 <= inputValue2 && inputValue2 <= 9)
            {
                inputValue2 = 1050;

                if (inputValue4 == 1)
                {
                    inputValue4 = 1.4f;
                }
                else if (inputValue4 == 2)
                {
                    inputValue4 = 1.6f;
                }
                else
                {
                    inputValue4 = 1.8f;
                }
            }
            else if (10 <= inputValue2 && inputValue2 <= 11)
            {
                inputValue2 = 1260;

                if (inputValue4 == 1)
                {
                    inputValue4 = 1.45f;
                }
                else if (inputValue4 == 2)
                {
                    inputValue4 = 1.65f;
                }
                else
                {
                    inputValue4 = 1.85f;
                }
            }
            else if (12 <= inputValue2 && inputValue2 <= 14)
            {
                inputValue2 = 1410;

                if (inputValue4 == 1)
                {
                    inputValue4 = 1.5f;
                }
                else if (inputValue4 == 2)
                {
                    inputValue4 = 1.7f;
                }
                else
                {
                    inputValue4 = 1.9f;
                }
            }
            else if (15 <= inputValue2 && inputValue2 <= 17)
            {
                inputValue2 = 1310;

                if (inputValue4 == 1)
                {
                    inputValue4 = 1.55f;
                }
                else if (inputValue4 == 2)
                {
                    inputValue4 = 1.75f;
                }
                else
                {
                    inputValue4 = 1.95f;
                }
            }
            else if (18 <= inputValue2 && inputValue2 <= 29)
            {
                inputValue2 = 1110;

                if (inputValue4 == 1)
                {
                    inputValue4 = 1.5f;
                }
                else if (inputValue4 == 2)
                {
                    inputValue4 = 1.75f;
                }
                else
                {
                    inputValue4 = 2.0f;
                }
            }
            else if (30 <= inputValue2 && inputValue2 <= 49)
            {
                inputValue2 = 1160;

                if (inputValue4 == 1)
                {
                    inputValue4 = 1.5f;
                }
                else if (inputValue4 == 2)
                {
                    inputValue4 = 1.75f;
                }
                else
                {
                    inputValue4 = 2.0f;
                }
            }
            else if (50 <= inputValue2 && inputValue2 <= 64)
            {
                inputValue2 = 1110;

                if (inputValue4 == 1)
                {
                    inputValue4 = 1.5f;
                }
                else if (inputValue4 == 2)
                {
                    inputValue4 = 1.75f;
                }
                else
                {
                    inputValue4 = 2.0f;
                }
            }
            else if (65 <= inputValue2 && inputValue2 <= 74)
            {
                inputValue2 = 1080;

                if (inputValue4 == 1)
                {
                    inputValue4 = 1.45f;
                }
                else if (inputValue4 == 2)
                {
                    inputValue4 = 1.7f;
                }
                else
                {
                    inputValue4 = 1.95f;
                }
            }
            else
            {
                inputValue2 = 1010;

                if (inputValue4 == 1)
                {
                    inputValue4 = 1.4f;
                }
                else
                {
                    inputValue4 = 1.65f;
                }
            }
        }

        float result = inputValue2 * inputValue4;

        // �v�Z���ʂ��e�L�X�g�Ƃ��ďo��
        outputText.text = "�v�Z����: " + result.ToString() + "Kcal/��";
    }
}
