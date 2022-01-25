using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveToCenter : MonoBehaviour
{
    [SerializeField] GameObject mainArrow;
    [SerializeField] GameObject centerPoint;
    [SerializeField] private ArrowMovement arrowMovement;

    public bool followPlayer = true;
    private bool stopLerping = true;
    
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            arrowMovement.canMoveLeftRight = false;
            arrowMovement.canMoveStraight = false;
            followPlayer = false;
        }
    }
    private void Move()
    {
        if (stopLerping)
        {
            mainArrow.transform.position = Vector3.Lerp(mainArrow.transform.position, centerPoint.transform.position, 30f * Time.deltaTime);
            if(Mathf.Approximately(mainArrow.transform.position.z, centerPoint.transform.position.z))
            {
                stopLerping = false;
            }
        }
        else
        {         
            arrowMovement.canMoveStraight = true;
        }  
    }
    private void Update()
    {
        if(arrowMovement.canMoveLeftRight == false)
        {          
            Move();
        }
    }
}
