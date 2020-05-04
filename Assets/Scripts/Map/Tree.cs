using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tree : MonoBehaviour
{
    public GameObject TreeSprite;

    // Start is called before the first frame update
    void Start()
    {
        var randomRotate = Random.Range(0,360);
        var randomSize = Random.Range(1f, 1.3f);

        transform.rotation = Quaternion.Euler(-90, randomRotate, 0);
        transform.localScale = new Vector3(randomSize, randomSize, randomSize);

        GameObject tree = Instantiate(TreeSprite, new Vector3(transform.position.x, transform.position.y, transform.position.z), transform.rotation) as GameObject;
        tree.transform.parent = transform;
    }
}
