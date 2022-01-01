using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TankHealth : MonoBehaviour {

    public float hp = 200;
    public Slider hpSlider;
    public GameObject tankExplosion;  
    public AudioSource explosionAudio;
    //private Transform audioPosition;//播放位置
    public void OnCollisionEnter( Collision col ) {
        if (col.gameObject.tag == "Walls" || col.gameObject.tag == "Tank") {
            RushDamage();
        }
    }
    
	// Use this for initialization
	void Start () {
	    SetHealth(hp);
        explosionAudio = this.GetComponent<AudioSource>();
       // Jcount = this.gameObject.GetComponent<Tank>().counts;
	}
    private void SetHealth(float HP)
    {
        hpSlider.value = HP/200;
    }
    public void ResetHealth()
    {
        hp = 200;
        hpSlider.value = hp/200;
    }
	// Update is called once per frame
    public void RushDamage()
    {
        hp -= Random.Range(2,5);
        SetHealth(hp);
        if(hp<=0)
        {
            OnDeath();
            hp = 0;
        }
    }
    public void TakeAoeDamage()
    {
        hp -= Random.Range(5, 10);
        SetHealth(hp);
        if(hp <= 0)
        {
            OnDeath();
            hp = 0;
        }
    }
    public void TakeDamage() {
        hp -= Random.Range(10, 20);
        SetHealth(hp);
        if(hp <= 0)
        {
            OnDeath();
            hp = 0;
        }
    }   
    public void OnDeath()
    {    
        explosionAudio.Play();
        GameObject tankExplosionInstance = Instantiate(tankExplosion);
        tankExplosionInstance.transform.position = transform.position;
        Destroy(tankExplosionInstance);
        gameObject.SetActive(false);
    }
    public void TakeRedDamage()
    {
        hp -= Random.Range(30,40);
        SetHealth(hp);
        if(hp <= 0)
        {
            OnDeath();
            hp = 0;
        }
    }
    /*
    public void RedUp()
    {
        hp -= Random.Range(20,30);
        SetHealth(hp);
        if(hp <= 0)
        {
            OnDeath();
            hp = 0;
        }
    }
    */
    public void GreenUp()
    {
        hp += Random.Range(25,30);
        SetHealth(hp);
    }
}
