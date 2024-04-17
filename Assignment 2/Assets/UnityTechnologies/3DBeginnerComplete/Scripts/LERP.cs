using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LERP : MonoBehaviour
{   
    bool x;
    float t=0.0f;
    Color lerpedColor = Color.green;
    Renderer c_renderer;
    public Transform player;
    float dist;
    void Start()
    {
        c_renderer = GetComponent<Renderer>();
    }

    void OnTriggerStay (Collider other)
    {
        if (other.gameObject.CompareTag("Ghost"))
        {
            dist = Vector3.Distance(player.transform.position, other.transform.position);
            if (dist <= 10)
            {
                t = 1 - (dist / 8);
                x = true;    
            }
            else
            {
                x = false;
            }
            
        }
    }

    void Update()
    {   
        if (x == true)
        {
            lerpedColor = Color.Lerp(Color.green, Color.red, t);           
        }
        else
        {
            lerpedColor = Color.Lerp(Color.green, Color.red, 0);
        }
        c_renderer.material.color = lerpedColor;
    }
}
