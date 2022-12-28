using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Interactions;

public class ScriptForPlayer : MonoBehaviour
{

    public GameObject rain;

    public GameObject pellet;
    public float projectileForce = 1000f;

    public GameObject snow;
    public float grav = 0.75f;
    private Rigidbody rb;

    void Update()
    {
        Vector3 rainPos = new Vector3(Random.Range(-250f, 250f), Random.Range(25f, 50f), Random.Range(-250f, 250f));
        Instantiate(rain, rainPos, Quaternion.identity);
    }

    public void whenFire(InputAction.CallbackContext context)
    {
        GameObject ammo = Instantiate(pellet);
        ammo.GetComponent<Rigidbody>().AddForce(transform.forward);
    }

    public void Restart(InputAction.CallbackContext context)
    {
        Application.LoadLevel(0);
    }
}