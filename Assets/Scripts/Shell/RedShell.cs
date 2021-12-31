using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedShell : MonoBehaviour
{
    public float maxLifeTime = 3;
    
    public GameObject shellExplosionPrefab;
    public AudioSource rexplosionAudio;

    void Start ()
    {   
        AudioSource rexplosionAudio = GetComponent<AudioSource>();
        Destroy(gameObject,maxLifeTime);
        
    }
    private void OnTriggerEnter( Collider collider) {
        rexplosionAudio.Play();
        GameObject.Instantiate(shellExplosionPrefab, transform.position, transform.rotation); 
        if (collider.tag == "Tank" ) 
        {
            collider.SendMessage("TakeRedDamage");
        }
        else if(collider.tag == "AOE plane")
        {
            GameObject Fathercollider = collider.transform.parent.gameObject;
            Fathercollider.SendMessage("TakeAoeDamage");
        }
        Destroy(gameObject);
    }
}
