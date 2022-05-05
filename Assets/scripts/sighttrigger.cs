using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sighttrigger : MonoBehaviour
{
     Material sightcolorchange;
    // Start is called before the first frame update
    void Start()
    {
        sightcolorchange = gameObject.GetComponent<MeshRenderer>().material;
        setcolor(Color.green);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.name=="Player")
        {
            setcolor(Color.red);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.name=="Player")
        {
            setcolor(Color.green);
        }
    }
   void setcolor(Color c)
    {
        sightcolorchange.color = c;
    }
}
