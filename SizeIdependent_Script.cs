using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SizeIdependent_Script : MonoBehaviour
{
    // Start is called before the first frame update
    void Update()
    {
        transform.localScale = new Vector3(
            //x
            1 / transform.parent.lossyScale.x,
            //y
            1 / transform.parent.lossyScale.y,
            //z
            1 / transform.parent.lossyScale.z
            );
    }
}
