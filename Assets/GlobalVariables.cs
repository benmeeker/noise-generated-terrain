using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalVariables : MonoBehaviour
{
    public TCP com;
    
    private void Start()
    {
        com = Manager.Instance.com;
    }

}
