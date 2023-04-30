using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;

public class Reset : MonoBehaviour
{
    public GameObject player;
    public Vector3 currentSpawnPoint;
    public HW1ScriptManager manager;
    [SerializeField] public InputActionReference yvalue;
    [SerializeField] public InputActionReference xvalue;
    // Start is called before the first frame update
    void Start()
    {

    }

    public void Respawn()
    {
        // Set the position to the spawn point.
        

        
                // Zero out any left over velocity.
        player.transform.position = currentSpawnPoint;
        player.GetComponent<Rigidbody>().velocity = Vector3.zero;
        player.GetComponent<Rigidbody>().rotation = Quaternion.identity;
        player.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
        manager.resetscore();
      
    }
    private void Orient()
    {
        player.GetComponent<Rigidbody>().rotation = Quaternion.identity;
        player.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
    }


    // Update is called once per frame
    void Update()
    {
        var resetbutton = yvalue.action.ReadValue<float>();
        var orientbutton = xvalue.action.ReadValue<float>();
       


        if (resetbutton>0)
        {
            Respawn();
           
        }

        if (orientbutton>0)
        {
            Orient();

        }
        if ((player.transform.position.x > 460)|| (player.transform.position.x < -460)|| (player.transform.position.z > 460) || (player.transform.position.z < -460)||(player.transform.position.y < -10))
        {
            Respawn();
        }
    }
    }

    
