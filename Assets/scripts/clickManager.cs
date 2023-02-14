using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class clickManager : MonoBehaviour
{
    public GameObject player;

    public void Update()
    {
        if (Input.GetMouseButton(0) && player != null)
        {
            RaycastHit hit;
            Ray ray = GetComponent<Camera>().ScreenPointToRay(Input.mousePosition);
            if(Physics.Raycast(ray, out hit))
            {
                Debug.DrawLine(ray.origin, hit.point, Color.red, 2f);
                if (hit.collider.tag == "ground")
                {
                    player.GetComponent<NavMeshAgent>().destination = hit.point;
                }
            }
        }
    }
}
