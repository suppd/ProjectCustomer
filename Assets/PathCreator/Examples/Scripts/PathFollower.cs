using UnityEngine;
using UnityEngine.Animations;
using PathCreation;

namespace PathCreation.Examples
{
    // Moves along a path at constant speed.
    // Depending on the end of path instruction, will either loop, reverse, or stop at the end of the path.
    public class PathFollower : MonoBehaviour
    {
        public PathCreator pathCreator;
        public CarTransition carScript;
        public PositionConstraint positionCon;
        public EndOfPathInstruction endOfPathInstruction;
        public float speed = 5;
        public float turnSpeed = 1f;
        public float slerpSpeed = 1f;
        float distanceTravelled;
        Quaternion rotater;


        void Start() 
        {

            if (pathCreator != null)
            {
                // Subscribed to the pathUpdated event so that we're notified if the path changes during the game
                pathCreator.pathUpdated += OnPathChanged;
            }

            
        }

        void Update()
        {
            Debug.Log(pathCreator.path.GetRotationAtDistance(distanceTravelled));
            if (pathCreator != null && positionCon.constraintActive == false)
            {
                distanceTravelled += speed * Time.deltaTime;
                transform.position = pathCreator.path.GetPointAtDistance(distanceTravelled, endOfPathInstruction);
               // rotater = pathCreator.path.GetRotationAtDistance(distanceTravelled);
               // rotater.z += 180;
               // rotater.x -= 90;

                //transform.rotation = rotater;

                //transform.rotation = Quaternion.LookRotation(Vector3.forward, transform.position * Time.fixedDeltaTime * turnSpeed);
  
                Vector3 dir = pathCreator.path.GetClosestPointOnPath(transform.position) - transform.position;

                float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;

                transform.rotation = Quaternion.Euler(0, 0, angle + 90.0f);


            } 
        }

        // If the path changes during the game, update the distance travelled so that the follower's position on the new path
        // is as close as possible to its position on the old path
        void OnPathChanged() {
            distanceTravelled = pathCreator.path.GetClosestDistanceAlongPath(transform.position);
        }
    }
}