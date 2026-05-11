using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Star : MonoBehaviour
{

    


    void Start()
    {
        StarController.Instance.RegisterStar(gameObject);
        
    }

    private void OnDestroy()
    {
        
    }




}
