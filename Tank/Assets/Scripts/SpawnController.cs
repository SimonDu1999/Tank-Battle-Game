using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnController : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public int speed ;
    public void ShellSpawn()
    {
        GameObject shell = Instantiate(Resources.Load("Shell"), transform.position, transform.rotation) as GameObject;
        shell.GetComponent<Rigidbody>().velocity = transform.forward * speed;
    }
}
