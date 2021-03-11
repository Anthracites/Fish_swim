using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine.SceneManagement;
using System.Threading;

public class CreateSmallNewTarget : MonoBehaviour
{
    public Vector3 spawnvalues;
    public GameObject TarPref;
    public GameObject FishForTarget;
    private GameObject inst_tar;
    public GameObject SpawnerFish;
    public float FishSpeed;
    public float FishStartSpeed;
    public int y;

    void Update()
    {
        //FishForTarget = GameObject.Find("Monster_small" + (y.ToString()));
       // if (FishForTarget != null)
        {
            //MoveTargetOnTochedFish();
        }
    }


    void OnDestroy()
     {
        y = Int32.Parse(gameObject.name.Substring(16));
        FishForTarget = GameObject.Find("Monster_small" + (y.ToString()));
        /*FishStartSpeed = FishForTarget.GetComponent<FishMove>().speed;
        if (FishForTarget.GetComponent<FishMove>().speed > FishStartSpeed)
        {
            FishForTarget.GetComponent<FishMove>().speed = (FishSpeed / 5f);
            FishForTarget.GetComponent<FishMove>().IsToched = false;
        }*/
     }

    void OnTriggerEnter(Collider other)
    {
        y = Int32.Parse(gameObject.name.Substring(16));
        FishForTarget = GameObject.Find("Monster_small" + (y.ToString()));
        if (other.gameObject.name == FishForTarget.name)
        {

            Destroy(gameObject);
            Vector3 SpawnPosition = new Vector3(UnityEngine.Random.Range(-spawnvalues.x, spawnvalues.x), UnityEngine.Random.Range(1, spawnvalues.y), UnityEngine.Random.Range(-spawnvalues.z, spawnvalues.z));
            Quaternion spawnRotation = Quaternion.identity;
            inst_tar = Instantiate(TarPref, SpawnPosition, spawnRotation) as GameObject;
            SpawnerFish = GameObject.Find("SpawnwerSmallFishSpawn");
            inst_tar.transform.parent = SpawnerFish.transform;
            inst_tar.name = gameObject.name;
        }
    }

   /* void MoveTargetOnTochedFish()
    {
        
        if (FishForTarget.GetComponent<FishMove>().IsToched == true)
        {
            gameObject.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, 10f);
        }
    }*/
}
