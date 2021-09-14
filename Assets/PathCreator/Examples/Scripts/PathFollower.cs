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
        public float speed;

        float distanceTravelled;
        Quaternion rotQuat;


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
            Debug.Log(carScript.startMoving);
            if (pathCreator != null && positionCon.constraintActive == false && carScript.startMoving)
            {
                distanceTravelled += speed * Time.deltaTime;
                transform.position = pathCreator.path.GetPointAtDistance(distanceTravelled, endOfPathInstruction);
                transform.rotation = pathCreator.path.GetRotationAtDistance(distanceTravelled, endOfPathInstruction);
                transform.Rotate(new Vector3(90, -90, -180));


            } 
        }

        // If the path changes during the game, update the distance travelled so that the follower's position on the new path
        // is as close as possible to its position on the old path
        void OnPathChanged() {
            distanceTravelled = pathCreator.path.GetClosestDistanceAlongPath(transform.position);
        }
    }
}