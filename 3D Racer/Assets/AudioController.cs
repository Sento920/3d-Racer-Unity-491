using UnityEngine;
using System.Collections;

public class AudioController : MonoBehaviour {

     public AudioClip clip; //make sure you assign an actual clip here in the inspector
    
    void OnCollisionEnter(Collision other)
    {
        print(other.transform.tag.ToString());
        if (other.transform.CompareTag("Player"))
        {
            GetComponent<AudioSource>().pitch = Random.Range(-2f,2f);
            print("FUCKING WHATEVER DUDE");
            AudioSource.PlayClipAtPoint(clip, gameObject.transform.position);
        }

    }

}
