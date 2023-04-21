using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;

public class Hand : MonoBehaviour {

    #region Variables
    [SerializeField] public InputActionReference controllerActionTrigger;
    [SerializeField] private Rigidbody playerRb;
    private XRDirectInteractor interactor;
    private float prevTrigger = 0f;
    
    private Rigidbody rb;
    
    private bool isTriggerPressed = false;
    #endregion
    
    #region Methods
    private void Start()
    {
        interactor = GetComponent<XRDirectInteractor>();
        rb = GetComponent<Rigidbody>();
    }



    void Update()
    {
        float trigger = controllerActionTrigger.action.ReadValue<float>();
        print(trigger + ", " + prevTrigger);
        if (trigger > 0.5f && prevTrigger <= 0.5f)
        {
            OnTriggerPressed();
        }
        else if (trigger <= 0.5f && prevTrigger > 0.5f)
        {
            OnTriggerReleased();
        }
        prevTrigger = trigger;

        // Apply force to hand if trigger is pressed
        if (isTriggerPressed)
        {
            playerRb.AddForce(transform.forward * -15f);
        }
    }

    private void OnTriggerPressed()
    {
        // interactor.selectTarget?.SendMessage("OnTriggerPressed", SendMessageOptions.DontRequireReceiver);
        isTriggerPressed = true;
    }
    private void OnTriggerReleased()
    {
        // interactor.selectTarget?.SendMessage("OnTriggerReleased", SendMessageOptions.DontRequireReceiver);
        isTriggerPressed = false;

    }

    #endregion

}
