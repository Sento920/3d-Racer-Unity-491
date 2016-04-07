using UnityEngine;
using System.Collections;

public class AudioController : MonoBehaviour {

     public AudioClip clip; //make sure you assign an actual clip here in the inspector
    [SerializeField]
    GameController Controller;
    
    void OnCollisionEnter(Collision other)
    {
        print(other.transform.tag.ToString());
        if (other.transform.CompareTag("Player"))
        {
            Controller.addOneScore();
            GetComponent<AudioSource>().pitch = Random.Range(-2f,2f);
            AudioSource.PlayClipAtPoint(clip, gameObject.transform.position);
        }

    }

}
