using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gateway : MonoBehaviour {

    // The script manager object for this scene.
    public HW1ScriptManager manager;

	// Has the player passed through this gateway yet?
	public bool activated = false;



    // The spawn point object for the gateway.
    public GameObject spawnPointObject;

	public void Activate()
    {
		// Update the state.
		activated = true;



        // Tell the manager this gateway has been activated.
        manager.ProcessGatewayActivation(this);
	}

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (!activated)
            {
                Activate();
            }
        }
    }
}
