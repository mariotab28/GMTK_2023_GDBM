using System.Numerics;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Canon : MonoBehaviour
{
    public GameObject prefab;
    public UnityEngine.Vector3 initialDirectionVector;
    public int initialVelocity;
    public UnityEngine.Vector3 spawnPosition;
    public float spawnTimer;

    [ContextMenu("Spawn Object")]
    public void SpawnObj(){
        GameObject obj =Instantiate(prefab, spawnPosition, new UnityEngine.Quaternion(0,0,0,0));
        obj.GetComponent<Rigidbody2D>().velocity = initialDirectionVector  * initialVelocity;
    }

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnObj", spawnTimer, spawnTimer);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
