using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCenter : MonoBehaviour
{  
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Clone")
        {
            transform.position = Vector3.Lerp(transform.position, transform.position - new Vector3(0, transform.position.y + 15, 0), 3f * Time.time);
            Destroy(gameObject, 3f);
        }

    }
}
