using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveWall : MonoBehaviour
{
    public GameObject sceneManager;
    private gui script;
    public Vector3 hi;
    float h;
 
    //[Range(0.0f,10.0f)]

    //private gui guiObject = GetComponent<gui>();

    void Awake()
    {
        
    }

    // Start is called before the first frame update
    void Start()
    {
        
        
    }

    // Update is called once per frame
    void Update()
    {   //demensions: 23.5*23.5*19
        float ceilingHeight = sceneManager.GetComponent<gui>().volume;
        //transform.position = new Vector3(0.0f, 22f-ceilingHeight, 0f);
        transform.position = new Vector3(0.3800001f, 22.44f-ceilingHeight, -1.58f);
        h = transform.position.y;
    }
}
