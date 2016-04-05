using UnityEngine;
using System.Collections;

public class katamari : MonoBehaviour {

	void OnTriggerEnter(Collider other)
    {
        if (other.transform.CompareTag("Player"))
        {
            this.transform.SetParent(other.transform);
            this.GetComponent<Collider>().isTrigger = false;
            this.transform.tag = "Player";
        }
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.transform.CompareTag("Player"))
        {
            this.transform.SetParent(other.transform);
            //this.GetComponent<Collider>().isTrigger = false;
            this.transform.tag = "Player";
        }
    }
}
