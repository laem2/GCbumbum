using System.Collections;
using System.Collections.Generic;
using UnityEngine;

interface Interactable {
    public void Interact();
}
public class Interactor : MonoBehaviour
{

    public Transform InteractorSource;
    public float IntercatRange;
    
        void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E)) {
            Debug.Log("click made");
            Ray r = new Ray(InteractorSource.position, InteractorSource.forward);
            if (Physics.Raycast(r, out RaycastHit hitInfo, IntercatRange)) {
                Debug.Log("rahou 9ASSOU");
                if(hitInfo.collider.gameObject.TryGetComponent(out Interactable interactObj)) {
                    Debug.Log("at this point idk");
                    interactObj.Interact();
                }
            }
        }
        
    }
}
