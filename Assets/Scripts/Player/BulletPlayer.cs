using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletPlayer : MonoBehaviour
{
    private float speed;
    public GameObject particleSystemExplode;

    // Start is called before the first frame update
    void Start()
    {
        speed = GameMaster.Instance.BulletSpeed;
        StartCoroutine(destroyTimer());
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += transform.forward * -speed * Time.deltaTime;
    }
    
    private IEnumerator destroyTimer()
    {
        yield return new WaitForSeconds(4f);
        Destroy(this.gameObject);
    }

    private void OnDestroy()
    {
        var b = Instantiate(particleSystemExplode, new Vector3(transform.position.x, transform.position.y, transform.position.z), particleSystemExplode.transform.rotation);
    }
}
