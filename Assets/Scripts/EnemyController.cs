using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour, IDamage 
{
    NavMeshAgent nav;
    Transform targetPlayer; 
    public void DoDamage(int vld)
    {
        Debug.Log("Daño = " + vld);
    }

    void Awake()
    {
     nav = GetComponent<NavMeshAgent>();
        targetPlayer = GameObject.FindGameObjectWithTag("Player").transform;
    }

   

    void Update()
    {
        nav.SetDestination (targetPlayer.position);
    
    }
}
