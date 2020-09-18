using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class oncollide : MonoBehaviour
{
    void OnControllerColliderHit(ControllerColliderHit col)
    {
        if (col.gameObject.name == "Collider")
        {
            Debug.Log("You hit the cube!");
            Manager.Instance.com.oncollide();
        }
    }
}
