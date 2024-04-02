using UnityEngine;
using UnityEngine.AI;

public class AI_Behaviour_Ghost : MonoBehaviour
{
    // aiSpeed has the same value as the player character's speed. 
    public float aiSpeed = 4.0f;

    // We create a variable so we can get the NavMeshAgent.
    public NavMeshAgent agent;

    public float range;

    public Transform centrePoint;

    // Start is called before the first frame update
    void Start()
    {
        // We get a reference to the NavMeshAgent.
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        if (agent.remainingDistance <= agent.stoppingDistance) //done with path
        {
            Vector3 point;
            if (RandomPoint(centrePoint.position, range, out point)) //pass in our centre point and radius of area
            {
                Debug.DrawRay(point, Vector3.up, Color.blue, 1.0f); //so you can see with gizmos
                agent.SetDestination(point);
            }
        }
    }

    bool RandomPoint(Vector3 center, float range, out Vector3 result)
    {

        Vector3 randomPoint = center + Random.insideUnitSphere * range; //random point in a sphere 
        NavMeshHit hit;
        if (NavMesh.SamplePosition(randomPoint, out hit, 1.0f, NavMesh.AllAreas))
        {
            //the 1.0f is the max distance from the random point to a point on the navmesh, might want to increase if range is big
            //or add a for loop like in the documentation
            result = hit.position;
            return true;
        }

        result = Vector3.zero;
        return false;
    }

}
