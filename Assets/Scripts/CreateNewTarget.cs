using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine.SceneManagement;
using System.Threading;

public class CreateNewTarget : MonoBehaviour
{
    public Vector3 spawnvalues;
    public GameObject TarPref;
    public GameObject FishForTarget;
    private GameObject inst_tar;
    public GameObject SpawnerFish;
    public float FishSpeed;
    public float FishStartSpeed;
    public int y;

    void Start()
    {
        y = Int32.Parse(gameObject.name.Substring(10));
        SpawnerFish = GameObject.Find("Spawnwer");
        FishForTarget = GameObject.Find("Monster" + (y.ToString()));
        FishStartSpeed = FishForTarget.GetComponent<FishMove>().speed;
    }

    void Update()
    {
        FishForTarget = GameObject.Find("Monster" + (y.ToString()));
        if (FishForTarget != null)
        {
            MoveTargetOnTochedFish();
        }
    }


    void OnDestroy()
     {
        FishForTarget.GetComponent<FishMove>().IsToched = false;
        FishForTarget.GetComponent<FishMove>().speed = FishStartSpeed;
     }

    void OnTriggerEnter(Collider other)
    {
        FishForTarget = GameObject.Find("Monster" + (y.ToString()));
        if (other.gameObject.name == FishForTarget.name)
        {

            Destroy(gameObject);
            Vector3 SpawnPosition = new Vector3(UnityEngine.Random.Range(-spawnvalues.x, spawnvalues.x), UnityEngine.Random.Range(1, spawnvalues.y), UnityEngine.Random.Range(-spawnvalues.z, spawnvalues.z));
            Quaternion spawnRotation = Quaternion.identity;
            inst_tar = Instantiate(TarPref, SpawnPosition, spawnRotation) as GameObject;
            inst_tar.transform.parent = SpawnerFish.transform;
            inst_tar.name = gameObject.name;
        }
    }

    void MoveTargetOnTochedFish()
    {
        
        if (FishForTarget.GetComponent<FishMove>().IsToched == true)
        {
            gameObject.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, 10f);
        }
    }
}
