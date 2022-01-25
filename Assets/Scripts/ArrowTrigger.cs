using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowTrigger : MonoBehaviour
{
    private ArrowSpawner arrowSpawner;
    private ArrowDestroyer arrowDestroyer;
    private void Start()
    {
        arrowSpawner = GetComponent<ArrowSpawner>();
        arrowDestroyer = GetComponent<ArrowDestroyer>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Multiplier")
        {            
            arrowSpawner.
                SpawnObjectsMultiplier(other.GetComponent<ArrowMultiplierModel>().multiplierX);
            other.enabled = false;
        }
        if (other.tag == "Plus")
        {
            arrowSpawner.
                SpawnObjectsPlus(other.GetComponent<ArrowPlusModel>().plusX);
            other.enabled = false;
        }
        if (other.tag == "MultiplierDestroy")
        {
            arrowDestroyer.ArrowMultiplierDestroy(other.GetComponent<ArrowMultiplierDestroyModel>().multiplierDestroyX);
            other.enabled = false;
        }
        if (other.tag == "PlusDestroy")
        {
            arrowDestroyer.ArrowPlusDestroy(other.GetComponent<ArrowPlusDestroyModel>().plusDestroyX);
            other.enabled = false;
        }
    }
}
