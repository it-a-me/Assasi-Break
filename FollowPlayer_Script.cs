using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer_Script : MonoBehaviour
{
    [SerializeField] private Transform playerTransform;
    private float localZ;
    private void Start()
    {
        localZ = transform.position.z;
    }
    // Update is called once per frame
    void Update()
    {
        try
        {
        transform.position = new Vector3(playerTransform.position.x, playerTransform.position.y, localZ);
        }
        catch
        {
            Destroy(this);
        }
    }
}
