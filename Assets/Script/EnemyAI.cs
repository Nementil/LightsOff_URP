using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class EnemyAI : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] SO_Enemy1 enemy;
    [SerializeField] AI_State currentState;
    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        currentState = AI_State.Search;
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
        float speed = enemy.speed * Time.deltaTime;
        transform.position = Vector2.MoveTowards(this.transform.position, player.transform.position, speed);
    }
    enum AI_State
    {
        Search,
        MoveToPlayer,
        PlayerCollision
    }
}
