using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New ItemData", menuName = "ScriptableObjects/ItemData")]
public class ItemData : ScriptableObject { 
    public string NAME;
    [TextArea(3, 10)]
    public string DESCRIPTION;
}
