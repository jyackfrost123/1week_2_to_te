using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class itemController : MonoBehaviour
{

    public GameObject[] SEprefubs;

    public GameObject correctObject;
    public GameObject failObject;
    
    public int type;
    public int Type{//0:二 1:テ
        get{
            return type;
        }
    }

    public bool isRed;
    public bool IsRed{
        get{
            return isRed;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        correctObject.SetActive(false);
        failObject.SetActive(false);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
    }

    /// <summary>
    /// correct the Answer
    /// </summary>
    public void YesCorrect(){
        correctObject.SetActive(true);
        //Debug.Log("Yes");
        
    }

    /// <summary>
    /// fail the Answer
    /// </summary>
    public void NoFail(){
        failObject.SetActive(true);
    }

}
