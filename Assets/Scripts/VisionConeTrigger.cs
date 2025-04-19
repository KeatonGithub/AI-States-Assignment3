using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VisionConeTrigger : MonoBehaviour
{
    private AIController ai;
    // Start is called before the first frame update
   private void Start()
    {
        ai = GetComponentInParent<AIController>(); 
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (ai.HasLineOfSight(other.transform))
            {
                ai.ChangeState(new StateChase(ai));
                //return player is in cone
                //line of sight detection
            }
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
  
                ai.SetPlayerInVisionCone(true);
                //return player is in cone
                //line of sight detection
        
        }
    }
    private void OnTriggerExit(Collider other)
    {
       if (other.CompareTag ("Player"))
        {
            ai.SetPlayerInVisionCone(false);// player is no longer being seen in vision set detection to false
        }
    }
}
