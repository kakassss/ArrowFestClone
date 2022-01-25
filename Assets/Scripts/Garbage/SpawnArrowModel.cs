using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class SpawnArrowModel
{
    [System.Serializable]
    public class ArrowPlus
    {
        public int plusX;
        public string plusTag;

    }
    [System.Serializable]
    public class ArrowMultiplier
    {
        public string multiplierTag;
        public int multiplierX;
    }
    public class SpawnerUI
    {
        public TextMeshProUGUI number;
    }
}
