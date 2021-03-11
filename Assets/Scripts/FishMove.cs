using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine.SceneManagement;
using System.Threading;
using UnityEngine.UI;

public class FishMove : MonoBehaviour
{
    private Transform target;
    public GameObject TargerObj;
    public float speed = 0.01f; 
    public int k;
    private Vector3 mousePos;
    public bool IsToched = false;
    public Text ScoreShow;
    public  ModeController.ModeShow CurrentMode;
    private Animator AnimatorFish;

    void Start()
    {
       CurrentMode = GameObject.Find("GameModeController").GetComponent<ModeController>().Mode;
        AnimatorFish = GetComponent<Animator>();
        AnimatorFish.speed = speed * 15f;
       // ChangeSpeed();
    }

    void Update()
    {
        if (IsToched == false)
        {
            SympleMove();
        }
        else if ((IsToched == true) & (CurrentMode == ModeController.ModeShow.Aquarium))
        {
            SympleMove();
        }
        else if ((IsToched == true) & (CurrentMode == ModeController.ModeShow.OneGamer))
        {
            TochedMove();
        }

        else if ((IsToched == true) & (CurrentMode == ModeController.ModeShow.TwoGamers))
        {
            TochedMove();
        }
    }

    void OnMouseEnter()
    {

        IsToched = true;
            speed = speed * 5f;
        if (CurrentMode == ModeController.ModeShow.OneGamer)
        {
            (GameObject.Find("1 Gamer Mode").GetComponent<ScoreCounter>().Score_player)++;
            //transform.rotation = new Quaternion(transform.rotation.w, transform.rotation.z, transform.rotation.y, 180);
        }

    }

    void SympleMove()
    {
        k = Int32.Parse(gameObject.name.Substring(7));
        target = GameObject.Find("Target_mon" + (k.ToString())).transform;
        transform.LookAt(target);
        transform.position = Vector3.MoveTowards(transform.position, target.position, speed);
    }

   

    void TochedMove()
    {
        transform.Translate(Vector2.up * speed);
    }
}
