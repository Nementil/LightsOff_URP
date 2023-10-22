using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NavMesh : MonoBehaviour
{
    private Vector3 target;
    [SerializeField] NavMeshAgent agent;
    //[SerializeField] GameObject player;
    // Start is called before the first frame update
    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;
        //player = GameObject.FindGameObjectWithTag("Player");
    }
    private void Update()
    {
        SetTargetPosition();
        SetAgentPosition();
    }
    void Start()
    {
        agent.enabled = true;
    }
    void SetTargetPosition()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform.position;
    }
    void SetAgentPosition()
    {
        agent.SetDestination(new Vector3(target.x, target.y, transform.position.z));
    }
}