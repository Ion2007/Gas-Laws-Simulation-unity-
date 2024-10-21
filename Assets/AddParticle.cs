using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddParticle : MonoBehaviour
{

    public GameObject particlePrefab;

    SphereCollider sc;
    public GameObject sceneManager;
   public GameObject[] array = new GameObject[100];
    public float avgV=0;
    public int num = 50;
    int o;
    float t = 0;


    // Start is called before the first frame update
    void Awake()
    {
       
    }
    void Start()
    {
        
        o = num;
        for (int i = 0; i < 100; i++)
        {
            array[i] = Instantiate(particlePrefab);
            if (i > num - 1)
            {
                array[i].GetComponent<Collider>().enabled = false;
                array[i].GetComponent<MeshRenderer>().enabled = false;
                array[i].GetComponent<Rigidbody>().velocity*=0;
            }
            /* Manually create particle
             * 
            GameObject particle = GameObject.CreatePrimitive(PrimitiveType.Sphere);
            particle.transform.position = new Vector3(0f, 5f, 0f);
            particle.AddComponent<Rigidbody>();
            particle.GetComponent<Rigidbody>().useGravity = false;
            particle.AddComponent<particle>();
            particle.AddComponent<SphereCollider>();
            sc = particle.GetComponent<SphereCollider>();
            sc.material = Resources.Load("bounce.physicMaterial") as PhysicMaterial;
            */
        }


    }

    // Update is called once per frame
    void Update()
    {
        

        if (num == 0)
        {
            for (int i = 0; i < 100; i++)
            {
                array[i].GetComponent<Collider>().enabled = false;
                array[i].GetComponent<MeshRenderer>().enabled = false;
                array[i].GetComponent<Rigidbody>().velocity *= 0;
            }
        }
        else if (num - o !=0)
        {
            for (int i = 0; i < 100; i++)
            {
                if (i > num - 1)
                {
                    array[i].GetComponent<Collider>().enabled = false;
                    array[i].GetComponent<MeshRenderer>().enabled = false;
                    array[i].GetComponent<Rigidbody>().velocity *= 0;
                }
                else
                {
                    /*
                    if (array[i].transform.position.y > 22.4F-sceneManager.GetComponent<gui>().volume)
                    {
                        array[i].transform.position = new Vector3(0, 22.4F - (float)(sceneManager.GetComponent<gui>().volume - .5f), 0);
                    }
                    */
                    array[i].GetComponent<Collider>().enabled = true;
                    array[i].GetComponent<MeshRenderer>().enabled = true;
                    array[i].GetComponent<Rigidbody>().velocity = new Vector3(UnityEngine.Random.Range(-5, 5), UnityEngine.Random.Range(-5, 5), UnityEngine.Random.Range(-5, 5));
                    array[i].GetComponent<Rigidbody>().velocity.Normalize();
                    array[i].GetComponent<Rigidbody>().velocity *= 3;
                }
            }
            o = num;
        }
        
        if (Time.time - t > 1)
        {
            avgV = 0;
            for (int i = 0; i < num; i++)
            {
                avgV += array[i].GetComponent<particle>().speed;


            }
            t = Time.time;
            avgV = avgV / num;
        }
        
    }
}