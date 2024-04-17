using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Observer : MonoBehaviour
{
    public Transform player;
    public Transform obsticle;
    public GameEnding gameEnding;
    public Vector3 dirToTarget;
    public UnityEngine.AI.NavMeshAgent path;
    public AudioSource f_AudioSource;
    public double dot;
    bool m_IsPlayerInRange;
    bool sf_trig;

    void OnTriggerEnter (Collider other)
    {
        if (other.transform == player)
        {
            m_IsPlayerInRange = true;
        }
    }

    void OnTriggerExit (Collider other)
    {
        if (other.transform == player)
        {
            m_IsPlayerInRange = false;
        }
    }

    void Update ()
    {   
        path.isStopped = false;
        Vector3 direction = player.position - transform.position + Vector3.up;
        Ray ray = new Ray(transform.position, direction);
        RaycastHit raycastHit;
        if (Physics.Raycast (ray, out raycastHit))
        {
            if (raycastHit.collider.transform == player)
            {
                dirToTarget = Vector3.Normalize(player.position-obsticle.position);
                dot = Vector3.Dot(obsticle.forward, dirToTarget);
                if (dot > 0)
                {
                    path.isStopped = true;
                    if (sf_trig == true)
                    {
                        f_AudioSource.Play();    
                        sf_trig = false; 
                    }

                }
                else
                {
                    sf_trig = true;
                }

                if (m_IsPlayerInRange)
                {
                    gameEnding.CaughtPlayer ();
                }
            }
        }
    }
}
