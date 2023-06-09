using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using Unity.VisualScripting.Dependencies.NCalc;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour, IDamageable
{
    [Header("Transforms and references")]
    public NavMeshAgent agent;
    public Transform player;
    public GameObject bullet;
    public Transform muzzle;


    [Header("Layer Masks")]
    public LayerMask whatIsGround, whatIsPlayer;

    [Header("Walkpoint")]
    public Vector3 walkPoint;
    bool walkPointSet;
    public float walkPointRange;

    [Header("Health")]
    public float health = 100f;

    private Spawner spawner;

    [Header("Attack")]
    public float timeBetweenAttacks;
    bool alreadyAttacked;

    [Header("Misc")]
    public float sightRange, attackRange;
    public bool playerInSightRange, playerInAttackRange;

    public static Enemy Instance;

    private void Awake()
    {
        player = GameObject.Find("Player").transform;
        agent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        playerInSightRange = Physics.CheckSphere(transform.position, sightRange, whatIsPlayer);
        playerInAttackRange = Physics.CheckSphere(transform.position, attackRange, whatIsPlayer);

        if (!playerInSightRange && !playerInAttackRange) Patrolling();
        if (playerInSightRange && !playerInAttackRange) ChasePlayer();
        if (playerInAttackRange && playerInSightRange) AttackPlayer();
    }

    public void InitializeEnemy(float health, Spawner spawner)
    {
        this.health = health;
        this.spawner = spawner;
    }

    private void Patrolling()
    {
        if (!walkPointSet) SearchWalkpoint();

        if(walkPointSet)
            agent.SetDestination(walkPoint);
        Vector3 distanceToWalkPoint = transform.position - walkPoint;
        if(distanceToWalkPoint.magnitude < 1f)
            walkPointSet = false;
    }

    private void SearchWalkpoint()
    {
        float randomZ = UnityEngine.Random.Range(-walkPointRange, walkPointRange);
        float randomX = UnityEngine.Random.Range(-walkPointRange, walkPointRange);

        walkPoint = new Vector3(transform.position.x + randomX, transform.position.y, transform.position.z + randomZ);

        if (Physics.Raycast(walkPoint, -transform.up, 2f, whatIsGround))
            walkPointSet = true;
    }

    private void ChasePlayer()
    {
        agent.SetDestination(player.position);
    }

    private void AttackPlayer()
    {
        //agent.SetDestination(transform.position);
        transform.LookAt(player);
        if (!alreadyAttacked)
        {
            EnemyBullet();
            alreadyAttacked = true;
            Invoke(nameof(ResetAttack), timeBetweenAttacks);
        }
    }

    private void ResetAttack() => alreadyAttacked = false;

    private void EnemyBullet()
    {
        /*
         GameObject currentBullet = Instantiate(bullet, transform.position, Quaternion.identity);
        currentBullet.transform.forward = transform.forward;
        
        currentBullet.GetComponent<Rigidbody>().AddForce(transform.forward * 32f, ForceMode.Impulse);
         
         */

        Rigidbody rb = Instantiate(bullet,muzzle.transform.position,Quaternion.identity).GetComponent<Rigidbody>();
        rb.AddForce(transform.forward * 32f, ForceMode.Impulse);

        Destroy(rb, 2f);
    }

    private void KillAllEnemies()
    {
        foreach (Enemy e in FindObjectsOfType<Enemy>())
        {
            Destroy(e);
        }
    }

    public void Damage(float damage)
    {
        health -= damage;
        if(health <= 0)
        {
            //Invoke(nameof(DestroyEnemy), 0.5f);
            Destroy(transform.parent.gameObject);
            spawner.NotifyDeath();
        }
    }
}
