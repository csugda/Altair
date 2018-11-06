using Assets.Scripts.Map.Pathfinding;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitController : MonoBehaviour {

    //[SerializeField]
    private GameObject nextNodeInPath;

    //[SerializeField]
    private GameObject startLocation;
    [SerializeField]
    private float speed = .5f;
    [SerializeField]
    private PathType endGoal;


    public void setStartLocation(GameObject startLocation)
    {
        // Set the start Node
        this.startLocation = startLocation;
        this.nextNodeInPath = startLocation;
        // Set the Location
        this.transform.position = startLocation.transform.position;

    }

    public void setEndGoal(PathType endGoal)
    {
        this.endGoal = endGoal;
    }

    private void Start()
    {
        
        this.nextNodeInPath = startLocation;
    }

    public PathNode NextPathNode()
    {
        return nextNodeInPath.GetComponent<PathNode>();
    }
    public PathType GetPathType()
    {
        return this.endGoal;
    }


    void FixedUpdate()
    {
        
        if (nextNodeInPath == null)
        {
            GetNextPathNode();
            if (nextNodeInPath == null && this.transform.position != startLocation.transform.position)
            {
                // We've run out of path!
                Destroy(this.gameObject);
                return;
            }
        }

        
        /*if (this.gameObject.transform.position == nextNodeInPath.transform.position)
        {
            //PathNode next = nextNodeInPath.GetComponent(typeof(PathNode)) as PathNode;

            PathNode next = nextNodeInPath.GetComponent<PathNode>().GetNextNode(endGoal);
            if(next != null)
            {
                nextNodeInPath = next.gameObject;
            }
            
            //Debug.Log("Moving to next node\nLooking for (" + next.X + " " + next.Y + ")");
            
            
        }*/
        Vector3 dir = nextNodeInPath.transform.position - this.transform.localPosition;
        float distThisFrame = speed * Time.deltaTime;
        if (dir.magnitude <= distThisFrame)
        {
            // We reached the node
            GetNextPathNode();
        }

        if (nextNodeInPath != null)
        {
            //  transform.position = Vector3.Slerp(this.gameObject.transform.position, nextNodeInPath.transform.position, speed);



            Quaternion targetRotation;

            transform.Translate(dir.normalized * distThisFrame, Space.World);
            if (!dir.Equals(Vector3.zero))
            {
                targetRotation = Quaternion.LookRotation(dir);
            } else
            {
                targetRotation = Quaternion.identity;
            }
            
            this.transform.rotation = Quaternion.Lerp(this.transform.rotation, targetRotation, Time.deltaTime * 5);
        }
        /* 
        Vector3 dir = nextNodeInPath.transform.position - this.transform.localPosition;

        float distThisFrame = speed * Time.deltaTime;

        if (dir.magnitude <= distThisFrame)
        {
            // We reached the node
            nextNodeInPath = null;
        }
        else
        {
            // TODO: Consider ways to smooth this motion.

            // Move towards node
            transform.Translate(dir.normalized * distThisFrame, Space.World);
            Quaternion targetRotation = Quaternion.LookRotation(dir);
            this.transform.rotation = Quaternion.Lerp(this.transform.rotation, targetRotation, Time.deltaTime * 5);
        }*/




    }

    private void GetNextPathNode()
    {
        try
        {



            PathNode next = nextNodeInPath.GetComponent<PathNode>().GetNextNode(endGoal);
            if (next == null && this.transform.position != startLocation.transform.position)
            {
                nextNodeInPath = null;
                
            } 
            if(next != null)
            {
                nextNodeInPath = next.gameObject;
            }
            
        } catch(NullReferenceException){
            //Debug.Log("Could not set next node.");
            return;
        }
        
    }
}
