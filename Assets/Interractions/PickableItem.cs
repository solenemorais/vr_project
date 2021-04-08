using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickableItem : MonoBehaviour
{

    bool isPickedUp;
    private Vector3 startVelocity = new Vector3(5F, 5F, 0F);


    public virtual void OnItemPickedUp(Transform holder)
    {
        isPickedUp = true;
        GetComponent<Gravity>().enabled = false;
        GetComponent<Rigidbody>().velocity = Vector3.zero;
        GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
        transform.SetParent(holder, true);
    }


    public virtual void OnItemRelease()
    {
        isPickedUp = false;
        transform.SetParent(null, true);
        GetComponent<Rigidbody>().velocity = startVelocity;
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
