using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[CreateAssetMenu(fileName = "Enemy", menuName = "Entity/Enemy")]
public class EnemyData : ScriptableObject
{
    [Header("Enemy Info")]
    public string enemyName;
    public float health;
    public float speed;

    [Header("Bullet")]
    public GameObject bullet;
    public float bulletDamage;
    public float bulletSpeed;

    [Header("Range")]
    public float sightRange;
    public float attackRange;

    [Header("Booleans")]
    public bool playerInAttackRange;
    public bool playerInSightRange;
    public bool walkpointSet;
    public bool alreadyAttacked;

    [Header("Attack Info")]
    public NavMeshAgent agent;
    public Transform player;
    public float timeBetweenAttacks;

    [Header("Positioning Info")]
    public Vector3 walkPoint;
    public bool walkPointSet;
    public float walkPointRange;

    [Header("Layer Masks")]
    public LayerMask whatIsGround;
    public LayerMask whatIsPlayer;
}
