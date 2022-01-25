using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class SpawnArrow : MonoBehaviour
{
    [SerializeField] List<ArrowMultiplierModel> arrowMultipliers;
    [SerializeField] List<ArrowPlusModel> arrowPlus;
    [SerializeField] GameObject prefab;
    //[SerializeField] int numObjects = 10;

    private float radiusIncrease = 0.1f;
    private float currentRadius = 0.2f;
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
    public void SpawnObjects(int numObjects)
    {
        Vector3 center = transform.position;
        
        for (int i = 0; i < 360; i+=360/Random.Range(10,30))
        {
            Vector3 pos = RandomCircle(center, currentRadius,i);
            Instantiate(prefab, pos, Quaternion.identity, transform);
        }
        currentRadius += radiusIncrease;
    }
    Vector3 RandomCircle(Vector3 center, float radius,int random)
    {

        float ang = random;
        Vector3 pos;
        pos.x = center.x + radius * Mathf.Sin(ang * Mathf.Deg2Rad);
        pos.y = center.y + radius * Mathf.Cos(ang * Mathf.Deg2Rad);
        pos.z = center.z;
        return pos;
    }
}
    

