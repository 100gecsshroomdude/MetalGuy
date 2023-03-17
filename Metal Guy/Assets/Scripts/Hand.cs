using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;

public class Hand : MonoBehaviour
{

    [SerializeField] public InputActionReference controllerActionTrigger;
    private XRDirectInteractor interactor;
    private float prevTrigger = 0f;
    private void Start()
    {
        interactor = GetComponent<XRDirectInteractor>();
    }

    void Update()
    {

    }
}


