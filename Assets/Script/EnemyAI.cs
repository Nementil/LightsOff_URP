using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] SO_Enemy1 enemy;
    [SerializeField] AI_State currentState;
    [SerializeField] NavMeshAgent agent;
    private Vector3 target;
    [SerializeField] private float cooldown_val;
    private float cooldown;

    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;
        agent.enabled = true;
        currentState = AI_State.Search;
        cooldown = cooldown_val;
    }
    private void Update()
    {
        if (currentState == AI_State.Search)
        {
            SearchPlayer();
        }
        if (currentState == AI_State.MoveToPlayer)
        {
            MoveToPlayer();
        }
        if(currentState==AI_State.PlayerCollision)
        {
            if (cooldown >= 0)
            {
                Debug.Log("on cd");
                cooldown -= Time.deltaTime;
                agent.speed = 0;
            }
            else
            {
                Debug.Log("NOT on cd");
                cooldown = cooldown_val;
                agent.speed = 3.5f;

                currentState = AI_State.MoveToPlayer;
            }
        }
    }
    private void SearchPlayer()
    {

        Vector2 direction = (new Vector2(player.transform.position.x, player.transform.position.y) - new Vector2(this.transform.position.x, this.transform.position.y));
        RaycastHit2D[] hit = Physics2D.CircleCastAll(transform.position, enemy.rangeLook, Vector2.zero);
        foreach (RaycastHit2D gm in hit)
        {
            if (gm.collider.tag == player.tag)
            {
                currentState = AI_State.MoveToPlayer;
            }
        }
    }
    private void MoveToPlayer()
    {
        //float speed = enemy.speed * Time.deltaTime;
        //transform.position = Vector2.MoveTowards(this.transform.position, player.transform.position, speed);
        SetTargetPosition();
        SetAgentPosition();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //Damage and stuff
        if(collision.collider.tag=="Player")
        {
            Debug.Log("Collision!");
            currentState = AI_State.PlayerCollision;
        }
    }

    void SetTargetPosition()
    {
        target = player.transform.position;
    }
    void SetAgentPosition()
    {
        agent.SetDestination(new Vector3(target.x, target.y, transform.position.z));
    }
    enum AI_State
    {
        Search,
        MoveToPlayer,
        PlayerCollision
    }
}
