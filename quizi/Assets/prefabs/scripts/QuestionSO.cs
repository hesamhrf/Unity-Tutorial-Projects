using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName ="Quiz Question" , fileName ="New Question")]
public class QuestionSO : ScriptableObject
{

    [TextArea()][SerializeField] string question  = "Enter Question";
    public string Question { get { return question; } private set { } }

    [SerializeField] string[] awnsers = new string[4];
    public string getAwnser(int index)
    {
        return awnsers[index];
    }

    [SerializeField] uint correctAwnserIndex;
    public uint CorrectAwnserIndex { get { return correctAwnserIndex; } private set { } }

}
