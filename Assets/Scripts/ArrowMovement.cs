using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowMovement : MonoBehaviour
{
    public bool canMoveLeftRight = true;
    public bool canMoveStraight = true;

    [SerializeField] private float borderLeftX;
    [SerializeField] private float borderRigtX;
    [SerializeField] private float speedX = 15f;
    [SerializeField] public float speedZ = 1f;
    [SerializeField] private Camera mainCamera;

    private float newX;
    private float newZ;

    private Vector3 firstPos;
    private Vector3 currentPos;
    private Vector3 difference;
    private ArrowSpawner arrowSpawner;
    private void Start()
    {
        arrowSpawner = GetComponent<ArrowSpawner>();   
    }
    // Update is called once per frame
    void Update()
    {
        CheckConditions();
    }
    private void CheckConditions()
    {
        if (canMoveLeftRight)
        {
            GetMousePos();
            SwerweMovement();
        }
        if (canMoveStraight)
        {
            StraightMovement();
        }
        if (!canMoveLeftRight)
        {
            ExpandAndReduce();
        }
    }
    private void ExpandAndReduce()
    {
        GetMousePos();
        GetDifference();
    }
    //not for movement
    private void GetDifference()
    {
        if (Input.GetMouseButton(0))
        {
            currentPos = mainCamera.WorldToViewportPoint(Input.mousePosition);
            difference = firstPos - currentPos;
            if (difference == Vector3.zero)
                return;
            difference.x = Mathf.Clamp(difference.x, 0.65f, 3f);
            arrowSpawner.ExpandBetweenArrows(difference.x *2);
        }
    }
    public void StraightMovement()
    {
        newZ = transform.position.z + speedZ * Time.deltaTime;
        transform.position = new Vector3(transform.position.x, transform.position.y, newZ);
    }
    private void GetMousePos()
    {
        if (Input.GetMouseButtonDown(0))
        {
            firstPos = mainCamera.WorldToViewportPoint(Input.mousePosition);
        }
    }
    
    private void SwerweMovement()
    {
        if (Input.GetMouseButton(0))
        {
            currentPos = mainCamera.WorldToViewportPoint(Input.mousePosition);
            difference = firstPos - currentPos;

            newX = Mathf.Clamp(transform.position.x + difference.x * speedX * Time.deltaTime,borderLeftX,borderRigtX);
            transform.position = Vector3.Lerp(transform.position, new Vector3(newX, transform.position.y, transform.position.z), 0.95f);
        }
    }
}
