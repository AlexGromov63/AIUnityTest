using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class turnOffInGame : MonoBehaviour
{
    private void Awake()
    {
        gameObject.SetActive(false);
    }
}
