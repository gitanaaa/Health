using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;//�I�u�W�F�N�g�������ۂ͕K�{
using TMPro;

public class QuizManager : MonoBehaviour
{
    public List<QuizQuestion> quizQuestions; //ScriptableObject�̃��X�g
    public TextMeshProUGUI questionText; //����\���p�e�L�X�g
    public List<Button> answerButtons; //�����̑I�����{�^��
    public TextMeshProUGUI feedbackText; //�t�B�[�h�o�b�N�e�L�X�g
    public TextMeshProUGUI feedbackText2;
    public Button nextQuestionButton; // ���̖��փ{�^��
    public Button retryButton; // ������x�{�^��
    public Image questionImage; // ���摜�\���p
    public Image feedbackImage; // �t�B�[�h�o�b�N�p�摜
    public Sprite correctSprite; // �������̉摜
    public Sprite wrongSprite; // �s�������̉摜

    private int currentQuestionIndex = 0;

    void Start()
    {
        DisplayQuestion();
        nextQuestionButton.gameObject.SetActive(false); // �ŏ��͔�\���ɂ��Ă���
        retryButton.gameObject.SetActive(false); // ������x�{�^�����ŏ��͔�\���ɂ��Ă���
        feedbackImage.gameObject.SetActive(false); // �t�B�[�h�o�b�N�摜����\���ɂ���
    }

    void DisplayQuestion()
    {
        if (currentQuestionIndex < quizQuestions.Count)
        {
            QuizQuestion currentQuestion = quizQuestions[currentQuestionIndex];
            questionText.text = currentQuestion.question;

            // �摜���ݒ肳��Ă���ꍇ�A�\������
            if (currentQuestion.questionImage != null)
            {
                questionImage.sprite = currentQuestion.questionImage;
                questionImage.gameObject.SetActive(true);
            }
            else
            {
                questionImage.gameObject.SetActive(false);
            }

            for (int i = 0; i < answerButtons.Count; i++)
            {
                if (i < currentQuestion.answers.Length)
                {
                    answerButtons[i].GetComponentInChildren<TextMeshProUGUI>().text = currentQuestion.answers[i];
                    answerButtons[i].onClick.RemoveAllListeners();
                    int index = i; // ���[�J���R�s�[���쐬���ăN���[�W���[�̖������
                    answerButtons[i].onClick.AddListener(() => CheckAnswer(index));
                    answerButtons[i].gameObject.SetActive(true); //�{�^����\��
                }
                else
                {
                    answerButtons[i].gameObject.SetActive(false); //�{�^�����\��
                }
            }
            feedbackText.gameObject.SetActive(false); // �t�B�[�h�o�b�N�e�L�X�g���\���ɂ���
            feedbackText2.gameObject.SetActive(false);
            feedbackImage.gameObject.SetActive(false); // �t�B�[�h�o�b�N�摜����\���ɂ���
        }
        else
        {
            feedbackText.text = "����ŁA���񂾂��͂����!�@�����ꂳ�܁I";
            feedbackText.gameObject.SetActive(true);
            questionText.gameObject.SetActive(false);
            questionImage.gameObject.SetActive(false); // �摜���\���ɂ���
        }
    }

    void CheckAnswer(int index)
    {
        if (index == quizQuestions[currentQuestionIndex].correctAnswerIndex)
        {
            feedbackText2.text = "��������!";
            feedbackText2.color = Color.green;
            feedbackImage.sprite = correctSprite;
        }
        else
        {
            feedbackText2.text = "����˂�c";
            feedbackText2.color = Color.blue;
            feedbackImage.sprite = wrongSprite;
        }

        // ��蕶�ƑI�������\���ɂ���
        questionText.gameObject.SetActive(false);
        questionImage.gameObject.SetActive(false); // �摜����\���ɂ���
        foreach (var button in answerButtons)
        {
            button.gameObject.SetActive(false);
        }

        // �t�B�[�h�o�b�N�e�L�X�g�Ǝ��̖��{�^����\������
        feedbackText2.gameObject.SetActive(true);
        feedbackImage.gameObject.SetActive(true);
        nextQuestionButton.gameObject.SetActive(true);
        retryButton.gameObject.SetActive(true);

        // �u���̖��ցv�{�^���Ƀ��X�i�[��ǉ�
        nextQuestionButton.onClick.RemoveAllListeners();
        nextQuestionButton.onClick.AddListener(NextQuestion);

        // �u������x�v�{�^���Ƀ��X�i�[��ǉ�
        retryButton.onClick.RemoveAllListeners();
        retryButton.onClick.AddListener(RetryQuestion);
    }

    void NextQuestion()
    {
        currentQuestionIndex++;
        questionText.gameObject.SetActive(true);
        feedbackText.gameObject.SetActive(false);
        feedbackText2.gameObject.SetActive(false);
        feedbackImage.gameObject.SetActive(false);
        nextQuestionButton.gameObject.SetActive(false);
        retryButton.gameObject.SetActive(false);
        DisplayQuestion();
    }

    void RetryQuestion()
    {
        questionText.gameObject.SetActive(true);
        feedbackText.gameObject.SetActive(false);
        feedbackText2.gameObject.SetActive(false);
        feedbackImage.gameObject.SetActive(false);
        nextQuestionButton.gameObject.SetActive(false);
        retryButton.gameObject.SetActive(false);
        DisplayQuestion();
    }
}
