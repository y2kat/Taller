using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class NPCFollower : MonoBehaviour
{
    NavMeshAgent agent;
    public Transform player;
    [SerializeField] Vector3 sizeOfView;
    [SerializeField] LayerMask whatIsCharacter;

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        FindCharacterToFollow();
        if (player == null) { return; }

        agent.SetDestination(player.position);
    }

    void FindCharacterToFollow()
    {
        if (player != null) { return; }

        var characters = Physics.OverlapBox(transform.position, sizeOfView, 
                                             Quaternion.identity, whatIsCharacter);
        if(characters.Length > 0)
        {
            player = characters[0].transform;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireCube(transform.position, sizeOfView);
    }
}
