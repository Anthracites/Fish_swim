using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine.SceneManagement;
using System.Threading;
using UnityEngine.UI;

public class FishSpawner : MonoBehaviour
{
    public Vector3 spawnvaluesMin;
    public Vector3 spawnvaluesMax;
    public GameObject[] FishPref;
    public GameObject TarPref;
    public GameObject SetMenu;
    public GameObject SpawnerFish;
    public GameObject ModeContrObj;
    public Text FishAmountField;
    public float timer;
    private GameObject inst_obj;
    private GameObject inst_objP2;
    private GameObject inst_tar;
    private GameObject inst_tar2;
    private int i = 0;
    private int j;
    public int FishAmount = 10;
    public Slider FishAmountSlider;
    public Slider FishSpeedSlider;
    public float FishSpeedStart;
    public ModeController.ModeShow CurrentMode;

    void Start()

    {
    }


    public void SpawnFish()

    {
        CurrentMode = ModeContrObj.GetComponent<ModeController>().Mode;

        if ((CurrentMode == ModeController.ModeShow.Aquarium) ^ (CurrentMode == ModeController.ModeShow.OneGamer))
        {
            SympleSpawn();
        }
        else
            if (CurrentMode == ModeController.ModeShow.TwoGamers)
        {
            SpawnForTwoGamers();
        }
    }

    void SympleSpawn()
    {
        for (int j = SpawnerFish.transform.childCount; j > 0; --j)
        {
            DestroyImmediate(SpawnerFish.transform.GetChild(0).gameObject);
        }
        FishAmount = Int32.Parse(FishAmountSlider.value.ToString());
        {
            while (i < FishAmount)
            {
                i++;
                timer += Time.deltaTime;
                {
                    Vector3 SpawnPosition = new Vector3(UnityEngine.Random.Range(spawnvaluesMin.x, spawnvaluesMax.x), UnityEngine.Random.Range(spawnvaluesMin.y, spawnvaluesMax.y), UnityEngine.Random.Range(spawnvaluesMin.z, spawnvaluesMax.z));
                    Vector3 SpawnPosition_tar = new Vector3(UnityEngine.Random.Range(spawnvaluesMin.x, spawnvaluesMax.x), UnityEngine.Random.Range(spawnvaluesMin.y, spawnvaluesMax.y), UnityEngine.Random.Range(spawnvaluesMin.z, spawnvaluesMax.z));
                    Quaternion spawnRotation = Quaternion.identity;
                    int SpawnPref = UnityEngine.Random.Range(0, FishPref.Length);
                    inst_obj = Instantiate(FishPref[SpawnPref], SpawnPosition, spawnRotation) as GameObject;
                    inst_obj.transform.parent = SpawnerFish.transform;
                    inst_tar = Instantiate(TarPref, SpawnPosition_tar, spawnRotation) as GameObject;
                    inst_tar.transform.parent = SpawnerFish.transform;
                    inst_tar.name = ("Target_mon" + (i.ToString()));
                    inst_obj.name = ("Monster" + (i.ToString()));
                    inst_obj.GetComponent<FishMove>().speed = (FishSpeedSlider.value / 10);
                    FishSpeedStart = FishSpeedSlider.value;
                    timer = 0;
                }



            }
        }
        SetMenu.SetActive(false);
        i = 0;
    }

    void SpawnForTwoGamers()
    {
        for (int j = SpawnerFish.transform.childCount; j > 0; --j)
        {
            DestroyImmediate(SpawnerFish.transform.GetChild(0).gameObject);
        }
        FishAmount = Int32.Parse(FishAmountSlider.value.ToString());
        {
            while (i < FishAmount)
            {
                i++;
                timer += Time.deltaTime;
                {
                    spawnvaluesMin.x = -4f;
                    spawnvaluesMax.x = 0f;

                    Vector3 SpawnPosition = new Vector3(UnityEngine.Random.Range(spawnvaluesMin.x, spawnvaluesMax.x), UnityEngine.Random.Range(spawnvaluesMin.y, spawnvaluesMax.y), UnityEngine.Random.Range(spawnvaluesMin.z, spawnvaluesMax.z));
                    Quaternion spawnRotation = Quaternion.identity;
                    int SpawnPref = UnityEngine.Random.Range(0, FishPref.Length);
                    inst_obj = Instantiate(FishPref[SpawnPref], SpawnPosition, spawnRotation) as GameObject;
                    inst_obj.transform.parent = SpawnerFish.transform;
                    inst_obj.name = ("Monster" + (i.ToString()));
                    inst_obj.GetComponent<FishMove>().speed = (FishSpeedSlider.value / 10);

                    Quaternion spawnRotationP2 = Quaternion.identity;
                    inst_objP2 = Instantiate(FishPref[SpawnPref], new Vector3(-SpawnPosition.x, SpawnPosition.y, SpawnPosition.z), spawnRotationP2) as GameObject;
                    inst_objP2.transform.parent = SpawnerFish.transform;
                    inst_objP2.name = ("MonsterP2" + (i.ToString()));
                    inst_objP2.GetComponent<FishMove>().speed = (FishSpeedSlider.value / 10);

                    Vector3 SpawnPosition_tar = new Vector3(UnityEngine.Random.Range(spawnvaluesMin.x, spawnvaluesMax.x), UnityEngine.Random.Range(spawnvaluesMin.y, spawnvaluesMax.y), UnityEngine.Random.Range(spawnvaluesMin.z, spawnvaluesMax.z));
                    inst_tar = Instantiate(TarPref, SpawnPosition_tar, spawnRotation) as GameObject;
                    inst_tar.transform.parent = SpawnerFish.transform;
                    inst_tar.name = ("Target_mon" + (i.ToString()));

                    FishSpeedStart = (FishSpeedSlider.value / 10);
                    timer = 0;
                }


            }
        }

        SetMenu.SetActive(false);
        i = 0;
    }
}


