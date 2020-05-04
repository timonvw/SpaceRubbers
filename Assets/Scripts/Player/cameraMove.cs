using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraMove : MonoBehaviour
{
    [SerializeField]private GameObject player;
    [SerializeField]private float moveSpeed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    //Normale Update met gekke shit als je sneller gaat, Fixed update niet. A B TEST
    void FixedUpdate()
    {
        if (Vector3.Distance(transform.position, player.transform.position) < 0.001f)
        {
            
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(player.transform.position.x, transform.position.y, player.transform.position.z), moveSpeed * Time.deltaTime);
        }
    }

    private void Update()
    {
        if(Vector3.Distance(player.transform.position, transform.position) > 23f)
        {
            moveSpeed = 30f;
        }
        else
        {
            moveSpeed = 18f;
        }
    }
}
