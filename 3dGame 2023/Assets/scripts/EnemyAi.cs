using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class EnemyAi : MonoBehaviour
{
    //de NavMeshAgent is een route die ai volgen kan dit is handig voor parollen en obstakels
    public NavMeshAgent agent;
    public int hp = 40;
    //player positie
    public Transform player;

    // check for ground layer and player layer
    public LayerMask isGround;
    public LayerMask isPlayer;

    //enemy patrolling 
    public Vector3 walkPoint;
    bool walkPointSet = false;
    public float walkPointRange;

    //enemy attacking
    public float timeBetweenAttacks;
    bool hasAttacked;

    //enemy states
    public float sightRange;
    public float attackRange;
    //check of de enemy de player kan zien
    bool playerInSightRange;
    bool playerInAttackRange;

    private void Awake()
    {
        //player is player positie
        player = GameObject.Find("Player").transform;
        agent = GetComponent<NavMeshAgent>();
    }
    private void Patrolling()
    {
        // als er geen walkpoint bestaat gaat de console naar een nieuwe walkpoint zoeken
        if (walkPointSet == false)
        {

            SearchWalkPoint();
        }
        //als er een walkpoint is gaat de enemy naar die walkpoint door de setDestination
        else  
        {
            agent.SetDestination(walkPoint);
            transform.LookAt(walkPoint);
        }

        Vector3 distanceToWalkpoint = transform.position - walkPoint;
        // kijk hoever de enemy van walkpoint weg is, als de enemy dichtbij is maak een nieuwe walkpoint
        if (distanceToWalkpoint.magnitude < 5f)
        {
            walkPointSet = false;
        }
    }
    //chase player
    private void Chasing()
    {
        agent.SetDestination(player.position);
    }
    //attack player
    private void Attacking()
    {
        agent.SetDestination(transform.position);
        ////zorg dat de enmy naar de player kijkt
        //transform.LookAt(player);
    }
    //search for walkpoint
    private void SearchWalkPoint()
    {
        print("test");
        //pak random x en z positie
        float randomZ = Random.Range(-walkPointRange,walkPointRange);
        float randomX = Random.Range(-walkPointRange,walkPointRange);

        // maak een nieuwe walkpoint aan door middel van de variabelen hierboven
        walkPoint = new Vector3(transform.position.x + randomX, transform.position.y, transform.position.z + randomZ);
        // als de walkpoint op de layer isGround is zet het naar true
      //  if (Physics.Raycast(walkPoint, -transform.up, 2f, isGround))
       // {
         //   print("2");
            walkPointSet = true;
       // }
    }
    private void OnCollisionEnter(Collision _collision)
    {
        if (_collision.gameObject.tag == "bullet")
        {
            print("Mrbeast");
            hp -= 10;
        }
    }
    /// <summary>
    /// Check of de enmy de player kan zien zodat je de state bepalen kan
    /// </summary>
    private void Update()
    {
        // check of de player in range is
        //CheckSphere checkt een bepaalde radius langs de enemy, als de player hierin komt dan retunt het true
        playerInSightRange = Physics.CheckSphere(transform.position, sightRange, isPlayer);
        playerInAttackRange = Physics.CheckSphere(transform.position, attackRange, isPlayer);

        // als de enemy de player niet kan zien en niet kan attacken ga naar de patrolling method
        if (!playerInSightRange && !playerInAttackRange)
        {
            Patrolling();
        }
        // als de enemy de player kan zien maar niet kan attacken ga naar de chasing method
        if (playerInSightRange && !playerInAttackRange) 
        {
            Chasing();
        }
        // als de enmy de player kan zien en kan attacken ga naar de attacking mehod
        if (playerInSightRange && playerInAttackRange)
        {
            Attacking();
        }
        if (hp < 0)
        {
            Destroy(this);
        }
    }
}
