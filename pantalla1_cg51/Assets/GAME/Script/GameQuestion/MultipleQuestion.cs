using UnityEngine;

[System.Serializable]
public class MultipleQuestion
{
    private string question;
    private string[] options = new string[4];
    private string correctAnswer;
    private string versiculo;
    private string difficultly;

    public string Question { get => question; set => question = value; }
    public string[] Options { get => options; set => options = value; }
    public string CorrectAnswer { get => correctAnswer; set => correctAnswer = value; }
    public string Versiculo { get => versiculo; set => versiculo = value; }
    public string Difficultly { get => difficultly; set => difficultly = value; }

    public MultipleQuestion()
    {
    }

    public MultipleQuestion(string question, string[] options, string correctAnswer, string versiculo, string difficultly)
    {
        this.question = question;
        this.options = options;
        this.correctAnswer = correctAnswer;
        this.versiculo = versiculo;
        this.difficultly = difficultly;
    }
}


