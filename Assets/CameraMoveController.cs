using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CameraMoveController : MonoBehaviour
{

    public GameObject recentObject;

    public GameObject nextObject;

    public GameObject[] oldObject;

    public GameObject[] generateObjects;

    public GameObject[] buttonSE;

    /*ライフがあるなら*/
    //public GameObject[] lifeObjects;
    //public int lifeNum = 0;

    private int generateNum = 0;

    public int GenerateNum{
        get{ return generateNum;}
    }

    private int score = 0;

    public int Score{
        get{return score;}
    }

    public int numOfNi = 0;
    public int numOfTe = 0;
    public int numOfFail = 0;

    public int failCountEndless = 0;

    public bool isStart = false;

    public bool isGame = true;

    [SerializeField]
    private float cameraMoveSpeed = 0.6f;

    private float objectDiostance = 3.4f;

    private int getCorrectPoint = 100;
    
    public bool processingButton = false;


    // Start is called before the first frame update
    void Start()
    {
        oldObject = new GameObject[3];

        /*ライフがあるなら*/
        /*
        for(int j = 0; j < lifeObjects.Length; j++){
            lifeObjects[j].transform.GetChild(0).gameObject.SetActive(false);
        }

        lifeNum = lifeObjects.Length - 1;
        */
        //IsStart();
    }

    void Update(){
        if(Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.I) ){//二
            PressedButton(0);
        }else if(Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D) ||  Input.GetKeyDown(KeyCode.W)){//テ
            PressedButton(1);
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        if(recentObject == null && isStart ){

            recentObject = nextObject;//参照切り替え

            /*次のオブジェクトの生成*/

            int i = Random.Range(0, generateObjects.Length);
            if(GenerateNum <=  10)i =  Random.Range(0, 2);
            else if(GenerateNum <  40 ||  isGame == false)i = Random.Range(0, 4);
            
            //i = GenerateNum % 2;//for DEBUG AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA

            Vector3 nextPos = recentObject.transform.position;

            nextObject =  Instantiate( generateObjects[i] , new Vector3(nextPos.x + objectDiostance, nextPos.y, nextPos.z), Quaternion.identity);
            generateNum++;
            //Debug.Log("generateNum:" + generateNum);


            /*最終的な演出処理*/
            
            transform.DOMoveX(recentObject.transform.position.x, cameraMoveSpeed);//移動

            //nextObject = ;
        }
        
    }

    /// <summary>
    /// 回答ボタンが押された時の処理を記述
    /// </summary>
    /// <param name="ans">0が”二”、1が”テ”になります</param>
    public void PressedButton(int ans){

        if(!isStart) return;//ゲームスタートしないと動かない

        if(processingButton) return;//二回以上押された場合は動かない
        processingButton = true;

        if(ans == 0){//二
            Instantiate( buttonSE[0], new Vector3 (0,0,0), Quaternion.identity);
        }else{//テ
            Instantiate( buttonSE[1], new Vector3 (0,0,0), Quaternion.identity);
        }

        if(recentObject != null){

            itemController item = recentObject.GetComponent<itemController>();

            if(ans == item.Type){//正解

                score += getCorrectPoint;
                if(item.IsRed == true) score += getCorrectPoint;//赤なら2倍

                if(ans == 0){
                    numOfNi+= getCorrectPoint;//二
                    if(item.IsRed == true) numOfNi+= getCorrectPoint;//赤なら2倍
                }else if(ans == 1){
                    numOfTe+= getCorrectPoint;//テ
                    if(item.IsRed == true) numOfTe+= getCorrectPoint;
                }
            
                item.YesCorrect();
                Instantiate( buttonSE[2], new Vector3 (0,0,0), Quaternion.identity);
            
            }else{//間違い

                item.NoFail();
                Instantiate( buttonSE[3], new Vector3 (0,0,0), Quaternion.identity);

                score -= getCorrectPoint;
                if(item.IsRed == true) score -= getCorrectPoint;//赤なら2倍

                numOfFail += getCorrectPoint;
                if(item.IsRed == true) numOfFail += getCorrectPoint;//赤なら2倍

                failCountEndless++;

                /*ライフがあるなら*/
                /*if(lifeNum >= 0){
                    lifeObjects[lifeNum].transform.GetChild(0).gameObject.SetActive(true);
                    lifeNum--;
                  }
                */

            }

            if(item.Type == 1){//て
                recentObject.transform.DORotate(new Vector3(0,0,180.0f), 0.1f);
            }

        }

        //いくつか前のオブジェクトの削除
        if(oldObject[oldObject.Length-1] != null) Destroy(oldObject[oldObject.Length-1]);

        for(int k = 1; k < oldObject.Length; k++){
            if(oldObject[k-1] != null)oldObject[k] = oldObject[k-1];
        }
        oldObject[0] = recentObject;

        recentObject = null;

        processingButton = false;
    }

    /// <summary>
    /// スタート時の処理を記述
    /// </summary>
    public void IsStart(){
        if(isStart) return;//もうスタートしてるならしない

        isStart = true;

        /*次のオブジェクトの生成*/

        //int i = Random.Range(0, generateObjects.Length);

        //Vector3 nextPos = this.transform.position;

        //nextObject =  Instantiate( generateObjects[i] , new Vector3(nextPos.x + objectDiostance, nextPos.y, nextPos.z+3.8f), Quaternion.identity);
        //generateNum++;
        //Debug.Log("generateNum:" + generateNum);


        /*最終的な演出処理*/
        //transform.DOMoveX(nextObject.transform.position.x, cameraMoveSpeed);//移動
        
    } 


    /// <summary>
    /// ゲーム終了時の処理を記述
    /// </summary>
    public void IsEnd(){
        isStart = false;

        Debug.Log("Finish!!");
    }


}
