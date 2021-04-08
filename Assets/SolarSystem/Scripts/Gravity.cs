
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Gravity : MonoBehaviour
{
    // objet qui tourne autours du soleil
    public GameObject planet;

    public float mass;
    public float vitesseInitiale;
    public float pow;
    Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.velocity = new Vector3(0, 0, vitesseInitiale);
    }

    Vector3 calculerForce()
    {
        /*
        float distanceCarre = (Sun.Instance.position - GetComponent<Rigidbody>.position).sqrMagnitude; //racine carré d'un vecteur
        Vector3 forceDirection = (Sun.Instance.position - GetComponent<Rigidbody>.position).normalized; //normaliser pour avoir l'orientation
        Vector3 accelerationGravitationnelle = -10 * forceDirection * Sun.Instance.mass / distanceCarre;
        vitesse += accelerationGravitationnelle * timeStep;
        */
        float G = 6.674f * Mathf.Pow(10, pow);
        float sunMass = Sun.Instance.rb.mass; //masse soleil
        Vector3 direction = Sun.Instance.rb.position - rb.position; //vecteur vers le soleil
        float distance = direction.magnitude;
        float gravity = (G * sunMass * rb.mass) / Mathf.Pow(distance, 2); //calcul gravité
        Vector3 force = direction.normalized * gravity;
        return (force); //retourner la force

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //Sun = sun.Instance;
        //Debug.Log(sun);
        Vector3 force = calculerForce();
        rb.AddForce(force); //on ajoute au rigidbody la force calculée
    }

}
