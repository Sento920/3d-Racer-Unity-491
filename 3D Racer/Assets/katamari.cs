using UnityEngine;
using System.Collections;

public class katamari : MonoBehaviour {

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.AddForce(Random.Range(-20f,20f), Random.Range(-20f, 20f), Random.Range(-20f, 20f),ForceMode.VelocityChange);
        GetComponent<Renderer>().material.color = new Color(Random.Range(0f,1f), Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(.5f, 1f));
        
    }

	void OnTriggerEnter(Collider other)
    {
        if (other.transform.CompareTag("Player"))
        {
            Destroy(rb);
            this.transform.SetParent(other.transform);
            this.GetComponent<Collider>().isTrigger = false;
            this.transform.tag = "Player";
        }
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.transform.CompareTag("Player"))
        {
            Destroy(rb);
            this.transform.SetParent(other.transform);
            //this.GetComponent<Collider>().isTrigger = false;
            this.transform.tag = "Player";
        }
    }
}
