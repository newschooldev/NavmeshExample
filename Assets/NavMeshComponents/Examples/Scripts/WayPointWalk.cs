using UnityEngine;
using UnityEngine.AI;

// Walk to a random position and repeat
[RequireComponent(typeof(NavMeshAgent))]
public class WayPointWalk : MonoBehaviour
{
    //public float m_Range = 25.0f;
    public Transform[] waypoints;
    NavMeshAgent m_Agent;
    public bool pingpong = true; //false = repeat
    private int curwaypoint = 0;
    private bool reverse = false;
    void Start()
    {
        m_Agent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        if (m_Agent.pathPending || m_Agent.remainingDistance > 0.1f)
            return;

        m_Agent.destination = waypoints[curwaypoint].position;
        if (pingpong)
        {
            if (!reverse)
            {
                curwaypoint++;
                if (curwaypoint > waypoints.Length-1)
                {
                    curwaypoint -= 2;
                    reverse = true;
                }
            }
            else
            {
                curwaypoint--;
                if (curwaypoint < 0)
                {
                    curwaypoint = 1;
                    reverse = false;
                }
            }

        }
        else
        {
            //repeat
            curwaypoint++;
            if (curwaypoint > waypoints.Length - 1)
            {
                curwaypoint =0;
            }
        }
    }
}
