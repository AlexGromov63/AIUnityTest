using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fieldOfView : MonoBehaviour
{
    GameObject player;

    public bool isPlayerSeen()
    {
        return player != null;
    }
    public Vector3 GetTargetPosition()
    {
        return player.transform.position;
    }

    private void OnTriggerStay(Collider collision)
    {
        if (collision.gameObject.CompareTag("player"))
        {
            RaycastHit hit;
            
            if (Physics.Raycast(transform.parent.position, collision.transform.position - transform.parent.position, out hit))
            {
                
                Debug.DrawLine(transform.parent.position, hit.point, Color.red);
                if (hit.collider.gameObject.CompareTag("player"))
                {
                    player = collision.gameObject;
                }
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("player"))
        {
            player = null;
        }
    }

    
}
