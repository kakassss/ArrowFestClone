using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ArrowSpawner : MonoBehaviour
{
    [SerializeField] List<ArrowMultiplierModel> arrowMultipliers;
    [SerializeField] List<ArrowPlusModel> arrowPlus;
    [SerializeField] public List<ArrowClone> cloneArrows;
    [SerializeField] ArrowClone prefab;
    
    [Header("Spawning")]
    public int currentAngle = 1;
    public float currentRadius = 0.2f;
    public float currentRadiusY = 0.2f;
    
    [Header("Expanding and Reducing")]
    public float radiusIncreaseX = 0.15f;
    public float radiusIncrease = 0.15f;
    public float lastRadius = 0.2f;

    private void Start()
    {
        ArrowPlusText();
        ArrowMultiplierText(); 
    }
    private void ArrowPlusText()
    {
        foreach (ArrowPlusModel apm in arrowPlus)
        {
            apm.number.text = "+" + apm.plusX.ToString();
        }
    }
    private void ArrowMultiplierText()
    {
        foreach (ArrowMultiplierModel amm in arrowMultipliers)
        {
            amm.number.text = "x" + amm.multiplierX.ToString();
        }
    }
    public void SpawnObjectsPlus(int numObjects)
    {
        Vector3 center = transform.position;
        for (int i = 0; i < numObjects; i++)
        {
            Vector3 pos = ExpandCircle(center, currentRadius,currentRadiusY, currentAngle - 360);
            ArrowClone newClones = Instantiate(prefab, pos, Quaternion.identity, transform);
            newClones.tag = "Clone";
            cloneArrows.Add(newClones);
            currentAngle += 15;
            if (currentAngle >= 360)
            {               
                currentAngle = 1;
                currentRadius += radiusIncrease;
                currentRadiusY += radiusIncrease;
            }
        }             
    }
    public void SpawnObjectsMultiplier(int numObjects)
    {
        Vector3 center = transform.position;
        int newIndex = (numObjects * cloneArrows.Count) - cloneArrows.Count;

        for (int i = 0; i < newIndex; i++)
        {                     
            Vector3 pos = ExpandCircle(center, currentRadius,currentRadiusY, currentAngle - 360);
            ArrowClone newClones = Instantiate(prefab, pos, Quaternion.identity, transform);
            newClones.tag = "Clone";
            cloneArrows.Add(newClones);
            currentAngle += 6;
            if (currentAngle >= 360)
            {
                currentAngle = 1;
                currentRadius += radiusIncrease;
                currentRadiusY += radiusIncrease;
            }
        }
    }
    public void ExpandBetweenArrows(float radiusIncreas)
    {
        Vector3 center = transform.position;
       
        for (int i = 1; i < cloneArrows.Count; i++)
        {
            int remainder = 360 & cloneArrows.Count;
            int angle = 360 / cloneArrows.Count + remainder;
            Vector3 pos = ExpandCircle(center, currentRadius, currentRadiusY, (i) * angle);
            cloneArrows[i].transform.position = pos;
            currentRadius = radiusIncreas;
        }
    }
    public void ReduceBetweenArrows(float radiusReduce)
    {
        Vector3 center = transform.position;
        
        for (int i = 1; i < cloneArrows.Count; i++)
        {
            int remainder = 360 & cloneArrows.Count;
            int angle = 360 / cloneArrows.Count + remainder;
            Vector3 pos = ReduceCircle(center, currentRadius, currentRadiusY, (i ) * angle);
            cloneArrows[i].transform.position = pos;
            currentRadius -= radiusReduce;

            if (currentRadius <= lastRadius)
            {
                currentRadius = lastRadius;

            }
        }
    }
    private Vector3 ReduceCircle(Vector3 center, float radiusX, float radiusY, int angle)
    {
        float ang = angle;
        Vector3 pos;
        pos.x = center.x - radiusX * Mathf.Sin(ang * Mathf.Deg2Rad);
        pos.y = center.y - radiusY * Mathf.Cos(ang * Mathf.Deg2Rad);
        pos.z = center.z;
        return pos;
    }
    private Vector3 ExpandCircle(Vector3 center, float radiusX,float radiusY, int angle)
    {
        float ang = angle;
        Vector3 pos;
        pos.x = center.x + radiusX * Mathf.Sin(ang * Mathf.Deg2Rad);
        pos.y = center.y + radiusY * Mathf.Cos(ang * Mathf.Deg2Rad);
        pos.z = center.z;
        return pos;
    }
}
