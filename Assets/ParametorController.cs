using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParametorController : MonoBehaviour
{
    [SerializeField]
    private int totalScore = 0;

    private int highScore = 0;

    public int TotalScore{
        get{ return this.totalScore; }
        set{ 
            this.totalScore = value;
            if(value >= highScore) this.highScore = value; 
        }
    }

    public int HighScore{
        get{ return highScore; }
    }

    public int niNum = 0;

    public int teNum = 0;

    public int failNum = 0;

    public bool isFirst = false;

    public int totalEndlessScore = 0;

    public bool isEndlessTutorial = false;

}
