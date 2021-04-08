using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// <summary>
// composant qui permet de rendre un objet lancable
// <summary>

/*
public class ThrowableItem : PickableItem
{

    Vector3 lastPosition;

    
    //public override void OnItemPickedUp(Transform holder)
    //{
    //    base.OnItemPickedUp(holder);
    //}

    protected void LateUpdate()
    {
        lastPosition = transform.position;
    }


    public override void OnItemReleased()
    {
        base.OnItemReleased();
        GetComponent<Rigidbody>().velocity = (transform.position - lastPosition) / Time.deltaTime;
    }
  */

    public class ThrowableItem : PickableItem
    {
        public override void OnItemPickedUp(Transform holder)
        {
            base.OnItemPickedUp(holder);
        }
    }

    /*
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    */
