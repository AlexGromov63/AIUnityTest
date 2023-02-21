using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class skinItem : MonoBehaviour
{
    public ItemData data;

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("player"))
        {
            FindObjectOfType<profile>().AddItem(data);
            Destroy(gameObject);
        }
    }

    private void Awake()
    {
        if (FindObjectOfType<profile>.isItemExists(data))
        {
            Destroy(gameObject);
        }
    }
}
