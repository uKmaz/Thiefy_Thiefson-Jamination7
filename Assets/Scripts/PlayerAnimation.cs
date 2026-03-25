using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows;

public class PlayerAnimation : MonoBehaviour
{
    private Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {

        if (UnityEngine.Input.GetKey(KeyCode.LeftShift) && UnityEngine.Input.GetKey(KeyCode.D))
        {
            animator.SetBool("rightWalk", true);
            animator.SetBool("leftWalk", false);
            animator.SetBool("upWalk", false);
            animator.SetBool("downWalk", false);
            animator.SetBool("leftRun", false);
            animator.SetBool("rightRun", false);
            animator.SetBool("upRun", false);
            animator.SetBool("downRun", false);
            animator.SetBool("leftIdle", false);
            animator.SetBool("rightIdle", false);
            animator.SetBool("downIdle", false);
            animator.SetBool("upIdle", false);
        }
        else if (UnityEngine.Input.GetKey(KeyCode.LeftShift) && UnityEngine.Input.GetKey(KeyCode.A))
        {
            animator.SetBool("leftWalk", true);
            animator.SetBool("rightWalk", false);
            animator.SetBool("upWalk", false);
            animator.SetBool("downWalk", false);
            animator.SetBool("leftRun", false);
            animator.SetBool("rightRun", false);
            animator.SetBool("upRun", false);
            animator.SetBool("downRun", false);
            animator.SetBool("leftIdle", false);
            animator.SetBool("rightIdle", false);
            animator.SetBool("downIdle", false);
            animator.SetBool("upIdle", false);
        }
        else if (UnityEngine.Input.GetKey(KeyCode.LeftShift) && UnityEngine.Input.GetKey(KeyCode.W))
        {
            animator.SetBool("leftWalk", false);
            animator.SetBool("rightWalk", false);
            animator.SetBool("upWalk", true);
            animator.SetBool("downWalk", false);
            animator.SetBool("leftRun", false);
            animator.SetBool("rightRun", false);
            animator.SetBool("upRun", false);
            animator.SetBool("downRun", false);
            animator.SetBool("leftIdle", false);
            animator.SetBool("rightIdle", false);
            animator.SetBool("downIdle", false);
            animator.SetBool("upIdle", false);
        }
        else if (UnityEngine.Input.GetKey(KeyCode.LeftShift) && UnityEngine.Input.GetKey(KeyCode.S))
        {
            animator.SetBool("leftWalk", false);
            animator.SetBool("rightWalk", false);
            animator.SetBool("upWalk", false);
            animator.SetBool("downWalk", true);
            animator.SetBool("leftRun", false);
            animator.SetBool("rightRun", false);
            animator.SetBool("upRun", false);
            animator.SetBool("downRun", false);
            animator.SetBool("leftIdle", false);
            animator.SetBool("rightIdle", false);
            animator.SetBool("downIdle", false);
            animator.SetBool("upIdle", false);
        }
        else if (UnityEngine.Input.GetKey(KeyCode.D)) 
        {
            animator.SetBool("leftWalk", false);
            animator.SetBool("rightWalk", false);
            animator.SetBool("upWalk", false);
            animator.SetBool("downWalk", false);
            animator.SetBool("leftRun", false);
            animator.SetBool("rightRun", true);
            animator.SetBool("upRun", false);
            animator.SetBool("downRun", false);
            animator.SetBool("leftIdle", false);
            animator.SetBool("rightIdle", false);
            animator.SetBool("downIdle", false);
            animator.SetBool("upIdle", false);
        }
        else if (UnityEngine.Input.GetKey(KeyCode.A))
        {
            animator.SetBool("leftWalk", false);
            animator.SetBool("rightWalk", false);
            animator.SetBool("upWalk", false);
            animator.SetBool("downWalk", false);
            animator.SetBool("leftRun", true);
            animator.SetBool("rightRun", false);
            animator.SetBool("upRun", false);
            animator.SetBool("downRun", false);
            animator.SetBool("leftIdle", false);
            animator.SetBool("rightIdle", false);
            animator.SetBool("downIdle", false);
            animator.SetBool("upIdle", false);
        }
        else if (UnityEngine.Input.GetKey(KeyCode.W))
        {
            animator.SetBool("leftWalk", false);
            animator.SetBool("rightWalk", false);
            animator.SetBool("upWalk", false);
            animator.SetBool("downWalk", false);
            animator.SetBool("leftRun", false);
            animator.SetBool("rightRun", false);
            animator.SetBool("upRun", true);
            animator.SetBool("downRun", false);
            animator.SetBool("leftIdle", false);
            animator.SetBool("rightIdle", false);
            animator.SetBool("downIdle", false);
            animator.SetBool("upIdle", false);
        }
        else if (UnityEngine.Input.GetKey(KeyCode.S))
        {
            animator.SetBool("leftWalk", false);
            animator.SetBool("rightWalk", false);
            animator.SetBool("upWalk", false);
            animator.SetBool("downWalk", false);
            animator.SetBool("leftRun", false);
            animator.SetBool("rightRun", false);
            animator.SetBool("upRun", false);
            animator.SetBool("downRun", true);
            animator.SetBool("leftIdle", false);
            animator.SetBool("rightIdle", false);
            animator.SetBool("downIdle", false);
            animator.SetBool("upIdle", false);
        }

        else
        {
            animator.SetBool("leftWalk", false);
            animator.SetBool("rightWalk", false);
            animator.SetBool("upWalk", false);
            animator.SetBool("downWalk", false);
            animator.SetBool("leftRun", false);
            animator.SetBool("rightRun", false);
            animator.SetBool("upRun", false);
            animator.SetBool("downRun", false);
            animator.SetBool("leftIdle", false);
            animator.SetBool("rightIdle", true);
            animator.SetBool("downIdle", false);
            animator.SetBool("upIdle", false);
        }

    }
}
