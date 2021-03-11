using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
public class ScoreCounter : MonoBehaviour
{
    public int Score_player = 0;
    public Text Txt_show;

    public void StartGameCounter()
    {


    }
    void Update()

    {

        Txt_show.text = (Score_player.ToString());

    }
}
