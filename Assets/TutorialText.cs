using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialText : MonoBehaviour
{

    CameraMoveController camera;
    ParametorController para;

    public GameObject[] startButton;
    // Start is called before the first frame update
    void Start()
    {
        camera = GameObject.Find("Main Camera").GetComponent<CameraMoveController>();
        camera.isStart = true;

        para =  GameObject.Find("FadeManager").GetComponent<ParametorController>(); 
        if(para.isFirst == false) para.isFirst = true;

        if(para.isEndlessTutorial == true){
            para.isEndlessTutorial = false;
            startButton[0].SetActive(false);//1番だけにする
        }else{
             startButton[1].SetActive(false);//0番だけにする
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
