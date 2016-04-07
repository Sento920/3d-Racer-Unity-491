using UnityEngine;
using System.Collections;

public class spawnController : MonoBehaviour {

    public GameObject[] spawnable;
    private int reload;
    private int curr;
    [SerializeField]
    private int total;

    void Start() {
        curr = 0;
        reload = 0;
    }

	// Update is called once per frame
	void Update () {
        if (reload >= 1 && curr <= total) {
            GameObject temp = (GameObject)Instantiate(spawnable[Random.Range(0, spawnable.Length)], this.transform.position, Quaternion.identity);
            temp.transform.SetParent(this.transform);
            reload = 0;
            curr++;
        }
        reload++;
	}
}
