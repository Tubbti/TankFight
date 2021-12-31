using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class TankAttack : MonoBehaviour {

    [SerializeField]
	private GameObject shellPrefab;
	[SerializeField]
	private GameObject RedshellPrefab;
	[SerializeField]
    private Transform firePoint;
	[SerializeField]
	private Transform DoublefirePoint1;
	[SerializeField]
	private Transform DoublefirePoint2;
	[SerializeField]
	private float fireForce = 10;
	[SerializeField]
	private int playerNumber = 1;
	[SerializeField]
	private float minForce = 7;
	[SerializeField]
	private float maxForce = 20;
	public float forceLoadingTime = 0.7f;
	[SerializeField]
	private float CDtime = 0;
	private int Shotflag=0;
	public Slider AimSlider;
	public AudioSource FireaudioSource;
	public AudioClip FireClip;
	public AudioClip LoadCLip;

	void Start()
	{
	//	ShellValue = this.gameObject.ShellValue;
	FireaudioSource =  this.GetComponent<AudioSource>();

	}
	void Update () {
		CDtime += Time.deltaTime ;
		if(CDtime >0.3f)
		{
			if (Input.GetButtonDown("Fire"+ playerNumber)) {
	       //fire();
			fireForce = minForce;
	    	}
			else if(Input.GetButton("Fire"+ playerNumber)) {
				if(FireaudioSource.clip == FireClip)
				{
					FireaudioSource.clip = LoadCLip;
					FireaudioSource.Play();
				}
				fireForce += Time.deltaTime * (maxForce - minForce)/forceLoadingTime;
			}
			else if(Input.GetButtonUp("Fire"+playerNumber)) {
				if(fireForce > maxForce)
				{
					fireForce = maxForce;
					RedFire();
				}
				else 
				{
					Fire();
				}
				CDtime = 0;
				fireForce = minForce;
			}
		}
		SetAimSlider();
	}
	private void Fire()
	{
		if(Shotflag == 0)
		{
			GameObject shell = GameObject.Instantiate(shellPrefab,firePoint.position,firePoint.rotation) as GameObject;
			Rigidbody rb = shell.GetComponent<Rigidbody>();			
			rb.velocity = firePoint.forward * fireForce;
		}
		else if (Shotflag == 1)
		{
			GameObject shell1 = GameObject.Instantiate(shellPrefab,DoublefirePoint1.position,firePoint.rotation) as GameObject;
			GameObject shell2 = GameObject.Instantiate(shellPrefab,DoublefirePoint2.position,firePoint.rotation) as GameObject;
			Rigidbody rb1 = shell1.GetComponent<Rigidbody>();	
			Rigidbody rb2 = shell2.GetComponent<Rigidbody>();		
			rb1.velocity = firePoint.forward * fireForce;
			rb2.velocity = firePoint.forward * fireForce;
		}
		FireaudioSource.clip = FireClip;
		FireaudioSource.Play();
	}
	private void RedFire()
	{
		if(Shotflag == 0)
		{
			GameObject redshell = GameObject.Instantiate(RedshellPrefab,firePoint.position,firePoint.rotation) as GameObject;
			Rigidbody rrb = redshell.GetComponent<Rigidbody>();			
			rrb.velocity = firePoint.forward * fireForce;
		}
		else if (Shotflag == 1)
		{
			GameObject redshell1 = GameObject.Instantiate(RedshellPrefab,DoublefirePoint1.position,firePoint.rotation) as GameObject;
			GameObject redshell2 = GameObject.Instantiate(RedshellPrefab,DoublefirePoint2.position,firePoint.rotation) as GameObject;
			Rigidbody rrb1 = redshell1.GetComponent<Rigidbody>();	
			Rigidbody rrb2 = redshell2.GetComponent<Rigidbody>();		
			rrb1.velocity = firePoint.forward * fireForce;
			rrb2.velocity = firePoint.forward * fireForce;
		}
		FireaudioSource.clip = FireClip;
		FireaudioSource.Play();
	}
	public void SetPlayerNumber(int playerNumber)
    {
        this.playerNumber = playerNumber;
    }
	private void SetAimSlider()
	{
		float value = (fireForce - minForce) / (maxForce - minForce);
		AimSlider.value = value;
	}
	public void RedUp()
	{
		Shotflag = 1;
		Invoke("BackUp",10);
	}
	private void BackUp()
	{
		Shotflag = 0;
	}
}

