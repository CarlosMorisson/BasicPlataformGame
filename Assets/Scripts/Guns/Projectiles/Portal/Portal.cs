using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{
	private float theta;    //angle of the portal 
	public bool top;
	private float vx, vy, vxf, vyf;
	public GameObject OtherPortal;
	[SerializeField]
	[Range(0, 10)]
	private float teleportRange=1;
    [SerializeField]
    private LayerMask groundLayer;
    // Use this for initialization
    void Start()
	{
	}

	// Update is called once per frame
	void Update()
	{
		if (gameObject.tag == "BluePortal")
		{
			OtherPortal = PortalController.instance.RedPortal;

		}
		else if (gameObject.tag == "RedPortal")
		{
			OtherPortal = PortalController.instance.BluePortal;

		}
	}

    void OnCollisionEnter2D(Collision2D collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            PortalController.instance.entered = true;
            // Teleport the player
            Vector2 teleportPosition = FindTeleportPosition();
            collider.gameObject.transform.position = teleportPosition;

            // "Eject" the player
            Vector2 ejectDirection = (teleportPosition - (Vector2)OtherPortal.transform.position).normalized;
            collider.gameObject.GetComponent<Rigidbody2D>().velocity = ejectDirection * 10f;
        }
    }

    Vector2 FindTeleportPosition()
    {
        Vector2 teleportPosition = Vector2.zero;
        bool foundPosition = false;

        while (!foundPosition)
        {
            float angle = Random.Range(0, 360);
            Vector2 randomDirection = new Vector2(Mathf.Cos(angle), Mathf.Sin(angle));
            teleportPosition = (Vector2)OtherPortal.transform.position + randomDirection * teleportRange;

            RaycastHit2D hit = Physics2D.Raycast(teleportPosition, -randomDirection, teleportRange, groundLayer);

            if (!hit.collider)
            {
                foundPosition = true;
            }

        }

        return teleportPosition;
    }

}
