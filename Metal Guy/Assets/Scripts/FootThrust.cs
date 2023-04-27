using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;

public class FootThrust : MonoBehaviour {

    #region Variables
    [SerializeField] public InputActionReference controllerActiongrip1;
    [SerializeField] public InputActionReference controllerActiongrip2;
    [SerializeField] public float force;
    [SerializeField] private Rigidbody playerRb;
    private XRDirectInteractor interactor;
    private float prevTrigger1 = 0f;
    private float prevTrigger2 = 0f;

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
        float trigger1 = controllerActiongrip1.action.ReadValue<float>();
        float trigger2 = controllerActiongrip1.action.ReadValue<float>();
        if (trigger1 > 0.5f && prevTrigger1 <= 0.5f)
        {
            OnTriggerPressed();
        }
        else if (trigger1 <= 0.5f && prevTrigger1 > 0.5f)
        {
            OnTriggerReleased();
        }
        prevTrigger1 = trigger1;

        if (trigger2 > 0.5f && prevTrigger2 <= 0.5f)
        {
            OnTriggerPressed();
        }
        else if (trigger2 <= 0.5f && prevTrigger2 > 0.5f)
        {
            OnTriggerReleased();
        }
        prevTrigger2 = trigger2;

        // Apply force to hand if trigger is pressed
        if (isTriggerPressed)
        {
           playerRb.AddForce(transform.up * force);
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
