using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteractnpc: MonoBehaviour
{
    private List<Transform> npcList;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            float interactRange = 2f;
          Collider[] colliderArray=   Physics.OverlapSphere(transform.position, interactRange);
            foreach (Collider collider in colliderArray)
            {
                if (collider.TryGetComponent(out NpcInteractable npcInteractable))
                    {
                    npcInteractable.Interact();
                }
            }
        }
       
    }
  
}
