using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionCounter : MonoBehaviour
{

    public float t;
    public int collision;
    public float cps;
    // Start is called before the first frame update
    public float avg;
    public float a;
    AddParticle addParticle;
    void Awake()
    {
        addParticle = GameObject.FindGameObjectsWithTag("GameController")[0].GetComponent<AddParticle>();
    }
    void Start()
    {
        t = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time - t > 1)
        {
           
            cps = collision / ((Time.time - t));
            collision = 0;
            t = Time.time;
        }
    }
}
