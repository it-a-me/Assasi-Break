using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class RobotAnimatorController : MonoBehaviour
{
    Animator robot;
    public Rigidbody2D _rigidbody;

    private void Start()
    {
        robot = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.tag == "Player")
        {
            robot.Play("Attack");
        }
        else if (collision != null)
        {
            robot.Play("Walking");
        }
    }
}