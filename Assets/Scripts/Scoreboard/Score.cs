using System;
using System.Collections;
using System.Collections.Generic;

[Serializable]
public class Score
{
    public string name;
    public float score;
    public float time;

    public Score(string name, float score, float time)
    {
        this.name = name;
        this.score = score;
        this.time = time;
    }
}