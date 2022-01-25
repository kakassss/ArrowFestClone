using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowDestroyer : MonoBehaviour
{
    [SerializeField] List<ArrowMultiplierDestroyModel> arrowDestroyMultipliers;
    [SerializeField] List<ArrowPlusDestroyModel> arrowDestroyPlus;

    [SerializeField] List<ArrowClone> garbages;
    private ArrowSpawner arrowSpawner;

    private void Start()
    {
        arrowSpawner = GetComponent<ArrowSpawner>();
        ArrowPlusDestroyText();
        ArrowMultiplierDestroyText();
    }
    public void ArrowPlusDestroy(int number)
    {
        int arrowCount = arrowSpawner.cloneArrows.Count;
        int totalDestroy = arrowCount - number;
        for (int i = arrowCount - 1; i > totalDestroy-1; i--)
        {
            Destroy(arrowSpawner.cloneArrows[i].gameObject);
            arrowSpawner.cloneArrows.RemoveAt(i);

            arrowSpawner.currentAngle -= 20;
            if (arrowSpawner.currentAngle <= -360)
            {
                arrowSpawner.currentAngle = -1;
                arrowSpawner.currentRadius -= arrowSpawner.radiusIncrease;
                arrowSpawner.currentRadiusY -= arrowSpawner.radiusIncrease;
            }
        }
    }
    public void ArrowMultiplierDestroy(int number)
    {
        int arrowCount = arrowSpawner.cloneArrows.Count;
        int multiplierCount = (arrowCount / number);
        int remainder = arrowCount % number;
        int totalDestroy = (remainder + multiplierCount);
        for (int i = arrowCount-1; i > totalDestroy-1; i--)
        {
            Destroy(arrowSpawner.cloneArrows[i].gameObject);
            arrowSpawner.cloneArrows.RemoveAt(i);

            arrowSpawner.currentAngle -= 8;
            if (arrowSpawner.currentAngle <= -360)
            {
                arrowSpawner.currentAngle = -1;
                arrowSpawner.currentRadius -= arrowSpawner.radiusIncrease;
                arrowSpawner.currentRadiusY -= arrowSpawner.radiusIncrease;
            }
        }
    }
    private void ArrowPlusDestroyText()
    {
        foreach (ArrowPlusDestroyModel apm in arrowDestroyPlus)
        {
            apm.number.text = "-" + apm.plusDestroyX.ToString();
        }
    }
    private void ArrowMultiplierDestroyText()
    {
        foreach (ArrowMultiplierDestroyModel amm in arrowDestroyMultipliers)
        {
            amm.number.text = "x" + amm.multiplierDestroyX.ToString();
        }
    }
}
