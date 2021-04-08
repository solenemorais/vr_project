using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerPickUp : MonoBehaviour
{
    Rigidbody pickedUpItem;

    public void PickUp()
    {
        //stocker collider de la sph�re/planete
        Collider[] hitItems = Physics.OverlapSphere(transform.position, 5f);

        //on attache le collider
        pickedUpItem = hitItems[0].attachedRigidbody;
        //on envoie la position au rigidbody et la fonction pour tenir l'objet
        pickedUpItem.SendMessage("OnItemPickedUp", transform);
    }

    //rel�cher l'objet
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
        //lancer le script pickup � l'appuis sur le bouton de pickup de la manette
        if (Input.GetKey(KeyCode.Space))
        {
            PickUp();
        }


        //lancer le script de release � l'appuis du bouton de release
        else
        {
            Release();
        }
    }
}