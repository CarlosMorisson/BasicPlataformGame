using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalController : MonoBehaviour
{
    public static PortalController instance;
    public GameObject BluePortal;
    public GameObject RedPortal;
    public bool entered;
    public float portalCooldown;
    public float count;
    void Start()
    {
        instance = this;
    }

    public void GetNewPortal(GameObject newPortal, string tagPortal)
    {
        if (tagPortal == "BluePortal")
        {
            Destroy(BluePortal);
            BluePortal = newPortal;
        }
        else
        {
            Destroy(RedPortal);
            RedPortal = newPortal;
        }
    }
    void Update()
    {
        
        if (entered)
        {

            count += Time.deltaTime;
            if (count >= portalCooldown)
            {
                entered = false;
                count = 0;
                BluePortal.GetComponent<BoxCollider2D>().isTrigger = false;
                RedPortal.GetComponent<BoxCollider2D>().isTrigger = false;
            }
            else
            {
                BluePortal.GetComponent<BoxCollider2D>().isTrigger = true;
                RedPortal.GetComponent<BoxCollider2D>().isTrigger = true;
            }
        }
    }
}
