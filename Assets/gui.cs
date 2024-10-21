using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gui : MonoBehaviour
{
    // Start is called before the first frame update
    public float volume = 0.0F;
    public float temp = 273.15F;
    public string p = "99";
    public float avg=0;
    
    CollisionCounter collisionCounter;
    AddParticle addParticle;
    GameObject[] array;
 
    void Awake()
    {
        collisionCounter = GameObject.FindGameObjectsWithTag("GameController")[0].GetComponent<CollisionCounter>();
        addParticle = GameObject.FindGameObjectsWithTag("GameController")[0].GetComponent<AddParticle>();
   
    }
    void Start()
    {
        temp = 273.15F;

    }
    void Update()
    {

    }
    void OnGUI()
    {
        volume =GUI.HorizontalSlider(new Rect(75, 29, 100, 30), volume, 0.0F, 16.5F);
        GUI.Label(new Rect(25, 25, 50, 20), "Volume: ");
        GUI.Label(new Rect(25, 54, 50, 20), "Temp: ");
        GUI.Label(new Rect(25, 80, 100, 20), "cps: " + collisionCounter.cps.ToString());
        
        temp = GUI.HorizontalSlider(new Rect(75, 60, 100, 30), temp, 150F, 640F);
        p = GUI.TextField(new Rect(200, 25, 100, 20), p, 2);
        GUI.Label(new Rect(200, 50, 200, 30), "(Number of Particles)");
        addParticle.num = int.Parse(p); 
        GUI.Label(new Rect(25, 100, 1000, 20), "Temperature: " +temp.ToString() );
        
            GUI.Label(new Rect(25, 120, 100, 20), "m/s: " + (addParticle.avgV).ToString());
            Debug.Log(avg);
        

        

    }
}
