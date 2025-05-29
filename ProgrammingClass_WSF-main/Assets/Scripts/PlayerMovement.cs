using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerMovement : MonoBehaviour
{
    private NavMeshAgent agent;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        // Je�li klikni�cie zosta�o chwilowo zablokowane (np. animacja �ciany), nie wykonuj ruchu
        if (ClickManager.clickBlocked)
            return;

        // Sprawdzenie klikni�cia myszk�
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit, Mathf.Infinity))
            {
                Vector3 clickPoint = hit.point;

                // Utworzenie i sprawdzenie �cie�ki
                NavMeshPath path = new NavMeshPath();
                if (NavMesh.CalculatePath(agent.transform.position, clickPoint, NavMesh.AllAreas, path))
                {
                    if (path.status == NavMeshPathStatus.PathComplete)
                    {
                        agent.SetDestination(clickPoint);
                    }
                    else
                    {
                        Debug.Log("Brak dost�pnej �cie�ki � cel zablokowany.");
                    }
                }
            }
        }
    }
}
