using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class ArrowUI : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI arrowCount;

    private ArrowSpawner arrowSpawner;
    // Start is called before the first frame update
    void Start()
    {
        arrowSpawner = FindObjectOfType<ArrowSpawner>();
    }

    // Update is called once per frame
    void Update()
    {
        arrowCount.text = arrowSpawner.cloneArrows.Count.ToString();
    }
}
