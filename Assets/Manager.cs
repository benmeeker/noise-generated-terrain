using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Manager : MonoBehaviour
{
    public static Manager Instance { get; private set; }

    public TCP com;
    public string uuid;
    public string name;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            com = GameObject.Find("Communication").GetComponent(typeof(TCP)) as TCP;
            this.com.ListenForData();
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
