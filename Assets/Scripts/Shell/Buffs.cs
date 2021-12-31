using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buffs : MonoBehaviour
{
    public GameObject RedBuffPrefab;
    public GameObject GreenBuffPrefab;
    public GameObject SpeedBuffPrefab;
    private GameObject RedBuffs;
    private GameObject GreenBuffs;
    private GameObject SpeedBuffs;

    public float BornCd=10;
    private float Cdcount = 0f;
    public Transform borntransform;
    void Start()
    {
        borntransform.position = new Vector3(Random.Range(-35f,35),0.7f,Random.Range(-35f,35));
        GameObject GreenBuff = GameObject.Instantiate(GreenBuffPrefab,borntransform.position,borntransform.rotation);
        borntransform.position = new Vector3(Random.Range(-35f,35),0.7f,Random.Range(-35f,35));
        GameObject SpeedBuff = GameObject.Instantiate(SpeedBuffPrefab,borntransform.position,borntransform.rotation);
    }
    void Update()
    {
        Cdcount += Time.deltaTime;
        if(Cdcount % BornCd == 0)
        {
            
            borntransform.position = new Vector3(Random.Range(-35f,35),0.7f,Random.Range(-35f,35));
            GreenBuffs = GameObject.Instantiate(GreenBuffPrefab,borntransform.position,borntransform.rotation);
            borntransform.position = new Vector3(Random.Range(-35f,35),0.7f,Random.Range(-35f,35));
            SpeedBuffs = GameObject.Instantiate(SpeedBuffPrefab,borntransform.position,borntransform.rotation);
            Invoke("ClearUp",20);
        }
        if(Cdcount%30==0)
        {
            borntransform.position = new Vector3(Random.Range(-35f,35),0.7f,Random.Range(-35f,35));
            RedBuffs = GameObject.Instantiate(RedBuffPrefab,borntransform.position,borntransform.rotation);
        }
    }
    private void ClearUp()
    {
        Destroy(GreenBuffs);
        Destroy(SpeedBuffs);
    }
}

