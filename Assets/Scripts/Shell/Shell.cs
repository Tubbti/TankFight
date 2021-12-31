using UnityEngine;
using System.Collections;

public class Shell : MonoBehaviour {

    public float maxLifeTime = 2;
    
    public GameObject shellExplosionPrefab;
    public AudioSource explosionAudio;

    void Start ()
    {   
        AudioSource explosionAudio = GetComponent<AudioSource>();
        Destroy(gameObject,maxLifeTime);
        
    }
    private void OnTriggerEnter( Collider collider) {
        explosionAudio.Play();
        GameObject.Instantiate(shellExplosionPrefab, transform.position, transform.rotation); 
        if (collider.tag == "Tank") {
            collider.SendMessage("TakeDamage");
        }
        Destroy(gameObject);
    }

}
