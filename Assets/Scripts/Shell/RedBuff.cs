using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedBuff : MonoBehaviour
{
    // Start is called before the first frame update
    public float livetime;
    void Start()
    {
        Destroy(this.gameObject,livetime);
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.Rotate(new Vector3(15,30,45)*Time.deltaTime);
    }
    private void OnTriggerEnter( Collider collider) {
        if (collider.tag == "Tank") {
            collider.SendMessage("RedUp");
        }
        Destroy(gameObject);
    }
}
