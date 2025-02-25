using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class ShowEndlessScoreController : MonoBehaviour
{
    
    ParametorController para;

    public Text niText;
    public Text teText;
    public Text failText;
    public Text totalText;

    public Text measureText;


    void Start(){
     
     if(GameObject.Find("FadeManager") != null){
         para = GameObject.Find("FadeManager").GetComponent<ParametorController>(); 
     }

     string s = "";
     if(para.totalEndlessScore <= 2000 ) s = "ゲシュタルト崩壊";
     else if(para.totalEndlessScore <= 3000) s = "軽崩壊";
     else if(para.totalEndlessScore <= 5000) s = "普通";
     else if(para.totalEndlessScore <= 6500) s = "冷静な判断力";
     else if(para.totalEndlessScore <= 8000) s = "研ぎ澄まされ";
     else s = "超覚醒";

     var sequence = DOTween.Sequence(); //Sequence生成
    //Tweenをつなげる
     sequence.Append(niText.DOText(para.niNum + "点", 0.5f).SetEase(Ease.Linear))
     .Append(teText.DOText(para.teNum + "点", 0.5f).SetEase(Ease.Linear))
     .Append(failText.DOText("-"+para.failNum + "点", 0.5f).SetEase(Ease.Linear))
     .Append(totalText.DOText(para.totalEndlessScore + "点", 0.5f).SetEase(Ease.Linear))
     .Append(
         measureText.DOText("ランク: " + s + "級", 0.5f).SetEase(Ease.Linear)
      );

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
