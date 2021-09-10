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
        float distanceTravelled;
        Quaternion Rotationpls;

        float rotationY;

        void Start() 
        {
            positionCon = GetComponentInParent<PositionConstraint>();
            if (pathCreator != null)
            {
                // Subscribed to the pathUpdated event so that we're notified if the path changes during the game
                pathCreator.pathUpdated += OnPathChanged;
            }

            rotationY = transform.rotation.y;
        }

        void Update()
        {
            if (pathCreator != null && positionCon.constraintActive == false)
            {
                distanceTravelled += speed * Time.deltaTime;
                transform.position = pathCreator.path.GetPointAtDistance(distanceTravelled, endOfPathInstruction);
                //rotationY = pathCreator.path.GetRotationAtDistance(distanceTravelled, endOfPathInstruction);
                
               
                //transform.rotation = pathCreator.path.GetRotationAtDistance(distanceTravelled);
                Rotationpls = pathCreator.path.GetRotationAtDistance(distanceTravelled);
                Rotationpls.y -= 90;
                
                transform.rotation = Rotationpls;
                //if (pathCreator.path.GetClosestPointOnPath != pathCreator.path.GetPointAtDistance(distanceTravelled))
                //{

                //}
                //Rotationpls.y -= 90;
            }

            
        }

        // If the path changes during the game, update the distance travelled so that the follower's position on the new path
        // is as close as possible to its position on the old path
        void OnPathChanged() {
            distanceTravelled = pathCreator.path.GetClosestDistanceAlongPath(transform.position);
        }
    }
}