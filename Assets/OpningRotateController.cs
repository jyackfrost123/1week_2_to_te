using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class OpningRotateController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //transform.DoRotate(new Vector3);
        transform.DOLocalRotate(new Vector3(0, 0, 360f), 10f, RotateMode.FastBeyond360)
        .SetEase(Ease.Linear)
        .SetLoops(-1, LoopType.Restart)
        .SetDelay(2);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
