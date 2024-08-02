using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewQuizQuestion", menuName = "Quiz/Question")]
public class QuizQuestion : ScriptableObject
{
    public string question;
    public string[] answers;
    public int correctAnswerIndex;
    public Sprite questionImage; // 画像フィールドを追加
}