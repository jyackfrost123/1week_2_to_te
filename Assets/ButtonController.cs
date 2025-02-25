using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonController : MonoBehaviour
{

   ParametorController para;
   //public GameObject[] Omakes;

   bool isTweet = false;
    
    
    void Start()
    {
     
     if(GameObject.Find("FadeManager") != null){
         para = GameObject.Find("FadeManager").GetComponent<ParametorController>(); 
     }
     
      
    }

    public void goTweet(){

        if(isTweet == true) return;
        isTweet = true;
        
        string s = "";
        if(para.TotalScore <= 2000 ) s = "ゲシュタルト崩壊";
        else if(para.TotalScore <= 3000) s = "軽崩壊";
        else if(para.TotalScore <= 5000) s = "普通";
        else if(para.TotalScore <= 6500) s = "冷静な判断力";
        else if(para.TotalScore <= 8000) s = "研ぎ澄まされ";
        else s = "超覚醒";

       //naichilab.UnityRoomTweet.Tweet("ni_to_te", "「2」か？「て」か？判別テスト、"+para.TotalScore+"点で、"+s+"級です", "unity1week", "2かてか");
       StartCoroutine(TweetWithScreenShot.TweetManager.TweetWithScreenShot("「2」か？「て」か？"+para.TotalScore+"点で、『"+s+"』級です　 https://unityroom.com/games/ni_to_te"));//画像あり

       isTweet = false;
    }

    public void go2ndTweet(){

        if(isTweet == true) return;
        isTweet = true;
        
        string s = "";
        if(para.totalEndlessScore <= 2000 ) s = "ゲシュタルト崩壊";
        else if(para.totalEndlessScore <= 3000) s = "軽崩壊";
        else if(para.totalEndlessScore <= 5000) s = "普通";
        else if(para.totalEndlessScore <= 6500) s = "冷静な判断力";
        else if(para.totalEndlessScore <= 8000) s = "研ぎ澄まされ";
        else  s = "超覚醒";

       //naichilab.UnityRoomTweet.Tweet("ni_to_te", "「2」か？「て」か？判別テスト、"+para.TotalScore+"点で、"+s+"級です", "unity1week", "2かてか");
       StartCoroutine(TweetWithScreenShot.TweetManager.TweetWithScreenShot("【エンドレスモード】"+para.totalEndlessScore+"点で、『"+s+"』級です　 https://unityroom.com/games/ni_to_te"));//画像あり

       isTweet = false;
    }

    public void goRanking(){
        if(para != null) naichilab.RankingLoader.Instance.SendScoreAndShowRanking (para.HighScore, 0);
        else naichilab.RankingLoader.Instance.SendScoreAndShowRanking (0, 0);
        //if(para != null) naichilab.RankingLoader.Instance.SendScoreAndShowRanking (0, 0);
        //else naichilab.RankingLoader.Instance.SendScoreAndShowRanking (0, 0);
    }

    public void go2ndRanking(){
        naichilab.RankingLoader.Instance.SendScoreAndShowRanking (0, 1);
        //if(para != null) naichilab.RankingLoader.Instance.SendScoreAndShowRanking (0, 0);
        //else naichilab.RankingLoader.Instance.SendScoreAndShowRanking (0, 0);
    }

    public void goResult(){
        naichilab.RankingLoader.Instance.SendScoreAndShowRanking (para.TotalScore, 0);
        //naichilab.RankingLoader.Instance.SendScoreAndShowRanking (score, 0);
    }

    public void go2ndResult(){
        naichilab.RankingLoader.Instance.SendScoreAndShowRanking (para.totalEndlessScore, 1);
        //naichilab.RankingLoader.Instance.SendScoreAndShowRanking (score, 0);
    }
    
    

    public void ReStart(){
        if(para != null){
            para.TotalScore = 0;
            para.niNum = 0;
            para.teNum = 0;
            para.failNum = 0;
            para.totalEndlessScore = 0;
        }

        //FadeManager.Instance.LoadScene ("SampleScene", 0.5f);

        
        if(para != null && para.isFirst == false){
            FadeManager.Instance.LoadScene ("Tutorial", 0.5f);
            para.isFirst = true;
        }else{
          FadeManager.Instance.LoadScene ("SampleScene", 0.5f);
        }
        
        
        
    }

    public void Re2ndStart(){
        if(para != null){
            para.TotalScore = 0;
            para.niNum = 0;
            para.teNum = 0;
            para.failNum = 0;
            para.totalEndlessScore = 0;
        }

        //FadeManager.Instance.LoadScene ("SampleScene", 0.5f);

        
        if(para != null && para.isFirst == false){
            para.isFirst = true;
            para.isEndlessTutorial = true;
            FadeManager.Instance.LoadScene ("Tutorial", 0.5f);
        }else{
          FadeManager.Instance.LoadScene ("EndlessMode", 0.5f);
        }
        
    }

    public void FastReStart(){
        if(para != null){
            para.TotalScore = 0;
            para.niNum = 0;
            para.teNum = 0;
            para.failNum = 0;
            para.totalEndlessScore = 0;
        }

         SceneManager.LoadScene("SampleScene");
    }

    public void Fast2ndReStart(){
        if(para != null){
            para.TotalScore = 0;
            para.niNum = 0;
            para.teNum = 0;
            para.failNum = 0;
            para.totalEndlessScore = 0;
        }

         SceneManager.LoadScene("EndlessMode");
    }

    /*public void Re2ndStart(){

        //FadeManager.Instance.LoadScene ("EndressGameScene", 1.0f);

        
        if(para != null && para.notFirst == false){
            FadeManager.Instance.LoadScene ("Tutorial", 0.5f);
            para.notFirst = true;
        }else{
          FadeManager.Instance.LoadScene ("EndressGameScene", 1.0f);
        }
        
        
        
    }*/

    /*public void Fast2ndReStart(){
         //SceneManager.LoadScene("EndressGameScene");
    }*/

    public void goTutorial(){
        FadeManager.Instance.LoadScene("Tutorial", 0.5f);
    }

    public void goTitle(){
        FadeManager.Instance.LoadScene("Title", 0.5f);
    }

 
}
