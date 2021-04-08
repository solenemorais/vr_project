using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerPickUp : MonoBehaviour
{
    Rigidbody pickedUpItem;

    public void PickUp()
    {
        Collider[] hitItems = Physics.OverlapSphere(transform.position, 5f);
        pickedUpItem = hitItems[0].attachedRigidbody;
        pickedUpItem.SendMessage("OnItemPickedUp", transform);
    }

    public void Release()
    {
        if (pickedUpItem != null )
        {
            pickedUpItem.SendMessage("OnItemRelease");
            pickedUpItem = null;
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        //lancer le script pickup à l'appuis sur le bouton de pickup de la manette

        if (Input.GetKey(KeyCode.Space))
        {
            PickUp();
        }


        //lancer le script de release à l'appuis du bouton de release

        else
        {
            Release();
        }
    }
}