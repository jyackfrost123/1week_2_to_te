using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RankingTest : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space)){
            // Type == Number の場合
            naichilab.RankingLoader.Instance.SendScoreAndShowRanking (100);

            // Type == Time の場合
            /*
            var millsec = 123456;
            var timeScore = new System.TimeSpan (0, 0, 0, 0, millsec);
            naichilab.RankingLoader.Instance.SendScoreAndShowRanking (timeScore);
            */
            
        }
        
    }
}
