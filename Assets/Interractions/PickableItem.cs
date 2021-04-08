using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickableItem : MonoBehaviour
{
    //variable pour savoir si l'objet est tenu ou non
    bool isPickedUp;
    private Vector3 startVelocity = new Vector3(5F, 5F, 0F);

    //quand on tient l'objet
    public virtual void OnItemPickedUp(Transform holder)
    {
        //variable passe à vrai
        isPickedUp = true;
        //desactiver la gravité
        GetComponent<Gravity>().enabled = false;
        //mettre les vitesses à zéro
        GetComponent<Rigidbody>().velocity = Vector3.zero; 
        GetComponent<Rigidbody>().angularVelocity = Vector3.zero; 

        transform.SetParent(holder, true);
    }

    //quand on relache l'objet
    public virtual void OnItemRelease()
    {
        //variable passe à faux
        isPickedUp = false;
        transform.SetParent(null, true);
        //redonner la vitesse à la planete
        GetComponent<Rigidbody>().velocity = startVelocity;
        //réactiver le script gravité
        GetComponent<Gravity>().enabled = true;
    }



    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
