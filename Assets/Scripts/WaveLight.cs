using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveLight : MonoBehaviour
{
    public GameObject[] BackGround;
    public GameObject BackGroundForChange;
    public float s;
    private float p = 0.25f;
    public bool Scaled = true;
    public bool NewBackGround = false;

    void Start()
    {
        SelectBackGroungForScale();
    }

    void Update()
    {
        //SelectBackGroungForScale();
        ScaleBackGround();
    }

    void ScaleBackGround()
    {
        s = BackGroundForChange.transform.localScale.x;

        if ((s < 20) & (NewBackGround == true))
        {
            BackGroundForChange.transform.localScale = new Vector3(s + p, 10f, 10f);
        }
        else

        if ((s == 20) & (NewBackGround == true))
        {
            BackGroundForChange.transform.localScale = new Vector3(s - p, 10f, 10f);
            NewBackGround = false;
        }
        else

        if ((s < 20) & (NewBackGround == false)&(s > 10))
        {
            BackGroundForChange.transform.localScale = new Vector3(s - p, 10f, 10f);
        }
        else
            if ((s == 10)& (NewBackGround == false))
        {
            SelectBackGroungForScale();
        }
    }

    void SelectBackGroungForScale()
    {
        //if (NewBackGround == false)

        {
            int BackGroundNumber = Random.Range(0, BackGround.Length - 1);
            BackGroundForChange = BackGround[BackGroundNumber];
            NewBackGround = true;
        }
    }
}
