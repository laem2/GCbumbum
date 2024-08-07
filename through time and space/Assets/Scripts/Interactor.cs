using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactor : MonoBehaviour
{
    public Transform InteractorSource; 
    public float InteractRange = 10f; 

    void Start()
    {
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E)) {
            Debug.Log("Interaction key pressed");
            Ray ray = new Ray(InteractorSource.position, InteractorSource.forward);
            if (Physics.Raycast(ray, out RaycastHit hitInfo, InteractRange)) {
                Debug.Log("Raycast hit something");
                if (hitInfo.collider.gameObject.TryGetComponent(out Interactable interactObj)) {
                    Debug.Log("Interactable object found");
                    interactObj.Interact();
                }
            }
        }
    }
}
