//using System.Collections;
//using UnityEngine;
//using Pathfinding;

//[RequireComponent (typeof (Rigidbody2D))]
//[RequireComponent (typeof (Seeker))]
//public class SeekerMistleAI: MonoBehaviour {

//    public Transform target;

//    // How many times each second we update the path
//    public float updateRate = 2f;

//    // Caching
//    private Seeker seeker;
//    private Rigidbody2D rb;

//    public Path path; // The calculated path

//    public float speed = 1000f; // The Ai speed per second
//    public ForceMode2D fMode;

//    [HideInInspector]
//    public bool pathHasEnded = false;

//    // The max distance from the AI to a waypoint for it to continue to the next
//    public float nextWaypointDistance = 3;

//    private int currentWaypoint = 0;

//    void Start()
//    {
//        seeker = GetComponent<Seeker>();
//        rb = GetComponent<Rigidbody2D>();

//        if (target == null)
//        {
//            Debug.LogError("No Player found!");
//            return;
//        }
//            // start a new path to the target position, return result to the OnPathComplete method
//            seeker.StartPath(transform.position, target.position, OnPathComplete);

//            StartCoroutine(UpdatePath());
//    }

//    IEnumerator UpdatePath()
//    {
//        if (target == null)
//        {
//            StartCoroutine(WaitForPlayerRespawn());
//            yield break;
//        }
//        seeker.StartPath(transform.position, target.position, OnPathComplete);
//        yield return new WaitForSeconds(1f / updateRate);
//        StartCoroutine(UpdatePath());

//    }
//    IEnumerator WaitForPlayerRespawn()
//    {
//        yield return new WaitForSeconds(GameManager.gm.spawnDelay);
//        target = GameObject.FindGameObjectWithTag("Player").transform;
//        yield return new WaitForSeconds(1f / updateRate);
//        StartCoroutine(UpdatePath());
//    }

//    public void OnPathComplete(Path p)
//    {
//        if (!p.error)
//        {
//            path = p;
//            currentWaypoint = 0;
//        }
//    }

//    void FixedUpdate()
//    {
//        if (target == null)
//        {
//            return;
//        }
//        //TODO: Always look at player
//        if (path == null)
//        {
//            return;
//        }
//        if (currentWaypoint >= path.vectorPath.Count) //check if it's the last waypoint
//        {
//            if (pathHasEnded)
//                return;
//            pathHasEnded = true;
//            return;
//        }
//        pathHasEnded = false;

//        //Direction to the new waypoint
//        Vector3 direction = (path.vectorPath[currentWaypoint] - transform.position).normalized; // position we're chasing - current enemy position = direction
//        direction *= speed * Time.fixedDeltaTime;

//        // Move the AI
//        rb.AddForce(direction, fMode);
//        float distance = Vector3.Distance(transform.position, path.vectorPath[currentWaypoint]);

//        if (distance < nextWaypointDistance)
//        {
//            currentWaypoint++;
//            return;
//        }
//    }
//}
