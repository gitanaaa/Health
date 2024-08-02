using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;//オブジェクトを扱う際は必須
using TMPro;

public class QuizManager : MonoBehaviour
{
    public List<QuizQuestion> quizQuestions; //ScriptableObjectのリスト
    public TextMeshProUGUI questionText; //質問表示用テキスト
    public List<Button> answerButtons; //答えの選択肢ボタン
    public TextMeshProUGUI feedbackText; //フィードバックテキスト
    public TextMeshProUGUI feedbackText2;
    public Button nextQuestionButton; // 次の問題へボタン
    public Button retryButton; // もう一度ボタン
    public Image questionImage; // 問題画像表示用
    public Image feedbackImage; // フィードバック用画像
    public Sprite correctSprite; // 正解時の画像
    public Sprite wrongSprite; // 不正解時の画像

    private int currentQuestionIndex = 0;

    void Start()
    {
        DisplayQuestion();
        nextQuestionButton.gameObject.SetActive(false); // 最初は非表示にしておく
        retryButton.gameObject.SetActive(false); // もう一度ボタンも最初は非表示にしておく
        feedbackImage.gameObject.SetActive(false); // フィードバック画像も非表示にする
    }

    void DisplayQuestion()
    {
        if (currentQuestionIndex < quizQuestions.Count)
        {
            QuizQuestion currentQuestion = quizQuestions[currentQuestionIndex];
            questionText.text = currentQuestion.question;

            // 画像が設定されている場合、表示する
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
                    int index = i; // ローカルコピーを作成してクロージャーの問題を回避
                    answerButtons[i].onClick.AddListener(() => CheckAnswer(index));
                    answerButtons[i].gameObject.SetActive(true); //ボタンを表示
                }
                else
                {
                    answerButtons[i].gameObject.SetActive(false); //ボタンを非表示
                }
            }
            feedbackText.gameObject.SetActive(false); // フィードバックテキストを非表示にする
            feedbackText2.gameObject.SetActive(false);
            feedbackImage.gameObject.SetActive(false); // フィードバック画像も非表示にする
        }
        else
        {
            feedbackText.text = "これで、もんだいはおわり!　おつかれさま！";
            feedbackText.gameObject.SetActive(true);
            questionText.gameObject.SetActive(false);
            questionImage.gameObject.SetActive(false); // 画像を非表示にする
        }
    }

    void CheckAnswer(int index)
    {
        if (index == quizQuestions[currentQuestionIndex].correctAnswerIndex)
        {
            feedbackText2.text = "せいかい!";
            feedbackText2.color = Color.green;
            feedbackImage.sprite = correctSprite;
        }
        else
        {
            feedbackText2.text = "ざんねん…";
            feedbackText2.color = Color.blue;
            feedbackImage.sprite = wrongSprite;
        }

        // 問題文と選択肢を非表示にする
        questionText.gameObject.SetActive(false);
        questionImage.gameObject.SetActive(false); // 画像も非表示にする
        foreach (var button in answerButtons)
        {
            button.gameObject.SetActive(false);
        }

        // フィードバックテキストと次の問題ボタンを表示する
        feedbackText2.gameObject.SetActive(true);
        feedbackImage.gameObject.SetActive(true);
        nextQuestionButton.gameObject.SetActive(true);
        retryButton.gameObject.SetActive(true);

        // 「次の問題へ」ボタンにリスナーを追加
        nextQuestionButton.onClick.RemoveAllListeners();
        nextQuestionButton.onClick.AddListener(NextQuestion);

        // 「もう一度」ボタンにリスナーを追加
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
