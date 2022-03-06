using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Dialog
{
    public string name;
    private string _status;

    [TextArea(3, 10)]
    public string[] sentences;

    private int _countPlaySentences;
    public string Status
    {
        get
        {
            return _status;
        }
        set
        {
            if (value != "")
                _status = value;
        }
    }
    public int CountPlaySentence
    {
        get
        {
            return _countPlaySentences;
        }
        set
        {
            if (value != 0)
                _countPlaySentences = value;
        }
    }
}
