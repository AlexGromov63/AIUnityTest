using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AI : MonoBehaviour
{
    public List<GameObject> pathpoints;
    NavMeshAgent nma;
    int targetPointIndex = 0;
    fieldOfView fov;

    Coroutine cor;

    private void Start()
    {
        nma = GetComponent<NavMeshAgent>();
        fov = GetComponentInChildren<fieldOfView>();
        cor = StartCoroutine(MoveToTarget());

    }

    private void Update()
    {
        if (fov.isPlayerSeen())
        {
            //остановка патрулирования и бежим к плееру
            StopCoroutine(cor);
            cor = null;

            //run

            nma.destination = fov.GetTargetPosition();
        }
        else
        {
            if(cor == null && isMoving() == false)
            {
                cor = StartCoroutine(waitAndPatrol());
            }
        }
    }

    IEnumerator waitAndPatrol()
    {
        yield return new WaitForSeconds(3);
        cor = StartCoroutine(MoveToTarget());
    }

    bool isMoving()
    {
        if (nma.pathPending == false)
        {
            if (nma.remainingDistance <= nma.stoppingDistance) {
                if (nma.hasPath == false || nma.velocity.magnitude == 0f)
                {
                    return false;
                }
            }
        }
        return true;
    }

    /*private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            Destroy(player);
        }
    }*/

    IEnumerator MoveToTarget()
    {
        nma.destination = pathpoints[targetPointIndex].transform.position;

        while (isMoving())
        {
            yield return null; 
        }

        //yield return new WaitForSeconds(1);
        targetPointIndex = (targetPointIndex + 1) % pathpoints.Count;
        cor = StartCoroutine(MoveToTarget());
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        if(pathpoints.Count > 1)
        {
            for (int i = 0; i < pathpoints.Count - 1; i++)
            {
                if (pathpoints[i] != null && pathpoints[i + 1] != null)
                {
                    Gizmos.DrawLine(pathpoints[i].transform.position,
                                    pathpoints[i + 1].transform.position);
                }
            }
        }
    }
}
