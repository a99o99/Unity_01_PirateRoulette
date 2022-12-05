using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InGame : MonoBehaviour
{
    public AudioSource bgm;
    void Start()
    {
        Object barrel = Resources.Load("Barrel");
        Object pirate = Resources.Load("Pirate");
        Object sword = Resources.Load("Sword");

        Instantiate(pirate);
        Instantiate(sword);
        Instantiate(barrel);

        RandomCube();
        bgm=GetComponent<AudioSource>();
    }

    private void Update()
    {

    }

    public void RandomCube()
    {
        int randNum = Random.Range(1, 17);

        string boomName = "Cube (" + randNum + ")";
        GameObject boom = GameObject.Find(boomName);

        boom.tag = "Boom";
    }



}
