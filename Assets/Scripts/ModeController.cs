using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using System.Threading;
using UnityEngine.UI;

public class ModeController : MonoBehaviour
{
    public GameObject MenuSettinges;
    public GameObject Canvas1Play;
    public GameObject Canvas2Play;
    public Slider FishAmountSlider;
    public InputField FishAmountField;
    public int U;
    public int FishAmount;
    public Dropdown SelectMode;
    public enum ModeShow {Settiing, Aquarium, OneGamer, TwoGamers};
    public ModeShow Mode;

    void Update()
    {
        ShowHideMenu();
    }

  public void ChangeGameMode()
    {
         if (SelectMode.value == 0)
         {
             Mode = ModeShow.Aquarium;
         }
         if(SelectMode.value == 1)
         {
             Mode = ModeShow.OneGamer;
            Canvas1Play.SetActive(true);
        }
         if (SelectMode.value == 2)
         {
             Mode = ModeShow.TwoGamers;
            Canvas2Play.SetActive(true);
        }
    }


    void ShowHideMenu()
    {
        if ((Input.GetKeyDown(KeyCode.M)) & (MenuSettinges.active == false))
        {
            MenuSettinges.SetActive(true);
            Mode = ModeShow.Settiing;
            Canvas1Play.SetActive(false);
            Canvas2Play.SetActive(false);
        }
        else
                   if ((Input.GetKeyDown(KeyCode.M)) & (MenuSettinges.active == true))
        {
            MenuSettinges.SetActive(false);
        }
    }

   public void ShowFishAmountField()
    {
        FishAmountField.text = FishAmountSlider.value.ToString();
        FishAmount = Convert.ToInt32(FishAmountSlider.value);

    }

    public void ShowFishAmountSlider()

    {
        /*U = Convert.ToInt32(FishAmountSlider.value);
        FishAmountSlider.value = Int32.Parse(FishAmountField.GetComponent<Text>().text.ToString());*/

        if (Input.GetKeyDown(KeyCode.Backspace) != true)
        {
            FishAmountSlider.value = Int32.Parse(FishAmountField.text.ToString());
            FishAmount = Int32.Parse(FishAmountField.text.ToString());
        }
    }
}
