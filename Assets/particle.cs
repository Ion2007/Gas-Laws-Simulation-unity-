using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class particle : MonoBehaviour
{
    Rigidbody rb;
    SphereCollider sc;
    public Vector3 v;
    public float speed=2400f;
    CollisionCounter collisionCounter;
    AddParticle addParticle;
    gui temp;
    float t;
   float s = 1f;
    public float ns = 0;


    void Awake()
    {
        collisionCounter = GameObject.FindGameObjectsWithTag("GameController")[0].GetComponent<CollisionCounter>();
        temp = GameObject.FindGameObjectsWithTag("GameController")[0].GetComponent<gui>();
        addParticle = GameObject.FindGameObjectsWithTag("GameController")[0].GetComponent<AddParticle>();
    }


    // Start is called before the first frame update
    void Start()
    {
        t = temp.temp;
        rb = GetComponent<Rigidbody>();
        
        rb.velocity = new Vector3(UnityEngine.Random.Range(-10, 10), UnityEngine.Random.Range(-10, 10), UnityEngine.Random.Range(-10, 10));
       rb.velocity= (rb.velocity).normalized;
rb.velocity *= s;
        
        
        /*
        sc = this.GetComponent<SphereCollider>();
        sc.material = Resources.Load("Assets/bounce.physicMaterial") as PhysicMaterial;
        */
    }

    // Update is called once per frame
    void Update()
    {
        if (temp.temp - t != 0)
        {
             ns = ((Mathf.Pow((temp.temp * 2f * 1.3806f * Mathf.Pow(10, -26)) / (addParticle.num), .5f)) / (Mathf.Pow((t * 2f * 1.3806f * Mathf.Pow(10, -26)) / (addParticle.num), .5f)));
           rb.velocity*=ns;
            speed=rb.velocity.magnitude*800;
            s*=ns;
            t = temp.temp;

            
        }
        


        //make velocity slower when particles added

        collisionCounter.avg += rb.velocity.magnitude;
        
    }
    void OnCollisionEnter(Collision collision)
    {
        //rb.velocity = (rb.velocity).normalized;
        //rb.velocity *= s;
        collisionCounter.collision++;
    }
}
