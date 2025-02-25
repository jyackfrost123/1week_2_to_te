using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using unityroom.Api;

public class UIController : MonoBehaviour
{

    public Text timerText;

    public Text scoreText;

    public CameraMoveController camera;

    public ParametorController para;

    public GameObject startSE;
    public GameObject endSE;

    public GameObject[] lifeObjects;
    //public int lifeNum = 0;

    public bool isEndlessMode = false;

    [SerializeField]
    private float time = 30.9f;
    
    private float startTime = 3.9f;

    private int score = 2000;

    private bool isStart = false;

    private bool isEnd = false;

    private int niOfNum = 0;
    private int teOfNum = 0;
    private int failOfNum = 0;

    private int endlessfailCount = 0;
    private int old_endlessfailCount = 0;

    // Start is called before the first frame update
    void Start()
    {
        para = GameObject.Find("FadeManager").GetComponent<ParametorController>();
        
        for(int j = 0; j < lifeObjects.Length; j++){
            lifeObjects[j].transform.GetChild(0).gameObject.SetActive(false);
        }

        //lifeNum = lifeObjects.Length - 1;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        score = camera.Score;
        scoreText.text = score.ToString("00000");
        niOfNum = camera.numOfNi;
        teOfNum = camera.numOfTe;
        failOfNum = camera.numOfFail;

        endlessfailCount = camera.failCountEndless;

        if(isStart){
            
            time -= Time.deltaTime;
            if(isEndlessMode){
               if(endlessfailCount < 5){
                   time = 100.0f;
               }else{
                   time = -1.0f;
               }

                if(endlessfailCount != old_endlessfailCount){
                       Debug.Log(old_endlessfailCount);
                       lifeObjects[old_endlessfailCount].transform.GetChild(0).gameObject.SetActive(true);
                }
            }

            if(time < 0.0f){
                time = 0.0f;
                
                if(isEnd == false){
                    isEnd = true;
                    camera.IsEnd();
                    Instantiate(endSE, this.transform.position, Quaternion.identity);
                    //
                    DOTween.Sequence().SetDelay(2).OnComplete(() =>
                        {
                            
                            para.niNum = niOfNum;
                            para.teNum = teOfNum;
                            para.failNum = failOfNum;
                            if(!isEndlessMode){
                                FadeManager.Instance.LoadScene("ScoreScene", 1.0f);
                                //TODO:ランキング呼び出し処理。
                                UnityroomApiClient.Instance.SendScore(1, score, ScoreboardWriteMode.HighScoreDesc);
                                para.TotalScore = score;
                            }else{
                                FadeManager.Instance.LoadScene("EndlessScoreScene", 1.0f);
                                //TODO:ランキング呼び出し処理
                                UnityroomApiClient.Instance.SendScore(2, score, ScoreboardWriteMode.HighScoreDesc);
                                para.totalEndlessScore = score;
                            }

                        }
                    );
                }

            }

            if(time > 0.0f){
                if(isEndlessMode)timerText.text = "";
                else timerText.text = time.ToString("0.0")+"秒";
            }else{
                timerText.text = "終了";
            }
            
        }


        if(startTime >= 0.0f) startTime -= Time.deltaTime;
        if(startTime < 1.0f){
            if(isStart == false){
                camera.IsStart();
                Instantiate(startSE, this.transform.position, Quaternion.identity);
                isStart = true;
            }

            if(startTime > 0.0f){
                timerText.text = "スタート";
            }

        }else{
            timerText.text = ( (int)(startTime) ).ToString();
        }

        old_endlessfailCount = endlessfailCount;

        
    }

}
