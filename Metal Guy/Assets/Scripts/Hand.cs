using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;

public class Hand : MonoBehaviour {

    #region Variables
    [SerializeField] public InputActionReference controllerActionTrigger;
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
        if (controllerActionTrigger.action.triggered)
        {
            float trigger = controllerActionTrigger.action.ReadValue<float>();
            if (trigger > 0.5f && prevTrigger <= 0.5f)
            {
                OnTriggerPressed();
            }
            else if (trigger <= 0.5f && prevTrigger > 0.5f)
            {
                OnTriggerReleased();
            }
            prevTrigger = trigger;
        }

        // Apply force to hand if trigger is pressed
        if (isTriggerPressed)
        {
            rb.AddForce(transform.forward * 10f);
        }
    }

    private void OnTriggerPressed()
    {
        if (!isTriggerPressed)
        {
            // interactor.selectTarget?.SendMessage("OnTriggerPressed", SendMessageOptions.DontRequireReceiver);
            isTriggerPressed = true;
        }
    }
    private void OnTriggerReleased()
    {
        if (isTriggerPressed)
        {
            // interactor.selectTarget?.SendMessage("OnTriggerReleased", SendMessageOptions.DontRequireReceiver);
            isTriggerPressed = false;
        }
    }

    #endregion

}
