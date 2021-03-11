using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.Threading;
using UnityEngine.SceneManagement;

public class SmallFishSpawn : MonoBehaviour
{
    public Vector3 spawnvaluesMin;
    public Vector3 spawnvaluesMax;
    public GameObject FishPref;
    public GameObject TarPref;
    public GameObject SpawnerFish;
    private GameObject inst_obj;
    private GameObject inst_tar;
    private int i = 0;
    private int j;
    public int FishAmount = 10;
    public Slider FishAmountSlider;
    public Slider FishSpeedSlider;
    public float FishSpeedStart;
    public float timer;

    public void SpawnSmallFish()
    {
        for (int j = SpawnerFish.transform.childCount; j > 0; --j)
        {
            DestroyImmediate(SpawnerFish.transform.GetChild(0).gameObject);
        }
        //FishAmount = Int32.Parse(FishAmountSlider.value.ToString());
        FishAmount = 1;
        {
            while (i < FishAmount)
            {
                i++;
                timer += Time.deltaTime;
                {
                    Vector3 SpawnPosition = new Vector3(UnityEngine.Random.Range(spawnvaluesMin.x, spawnvaluesMax.x), UnityEngine.Random.Range(spawnvaluesMin.y, spawnvaluesMax.y), UnityEngine.Random.Range(spawnvaluesMin.z, spawnvaluesMax.z));
                    Vector3 SpawnPosition_tar = new Vector3(UnityEngine.Random.Range(spawnvaluesMin.x, spawnvaluesMax.x), UnityEngine.Random.Range(spawnvaluesMin.y, spawnvaluesMax.y), UnityEngine.Random.Range(spawnvaluesMin.z, spawnvaluesMax.z));
                    Quaternion spawnRotation = Quaternion.identity;
                    inst_obj = Instantiate(FishPref, SpawnPosition, spawnRotation) as GameObject;
                    inst_obj.transform.parent = SpawnerFish.transform;
                    inst_tar = Instantiate(TarPref, SpawnPosition_tar, spawnRotation) as GameObject;
                    inst_tar.transform.parent = SpawnerFish.transform;
                    inst_tar.name = ("Target_mon_small" + (i.ToString()));
                    inst_obj.name = ("Monster_small" + (i.ToString()));
                    //inst_obj.GetComponent<FishMove>().speed = 10;
                    //FishSpeedStart = FishSpeedSlider.value;
                    timer = 0;
                }



            }
        }
    }
}
