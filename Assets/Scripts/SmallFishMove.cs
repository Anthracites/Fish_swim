using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine.SceneManagement;
using System.Threading;
using UnityEngine.UI;

public class SmallFishMove : MonoBehaviour
{
    public int k;
    private Transform target;
    public float speed = 0.01f;
    private Animator AnimatorFish;


    void Start()
    {
        //AnimatorFish = GetComponent<Animator>();
       // AnimatorFish.speed = speed * 15f;
    }
    void Update()
    {
        FishMoveSmall();

    }

    void FishMoveSmall()

    {
        k = Int32.Parse(gameObject.name.Substring(13));
        target = GameObject.Find("Target_mon_small" + (k.ToString())).transform;
        transform.LookAt(target);
        transform.position = Vector3.MoveTowards(transform.position, target.position, speed);
    }
}
