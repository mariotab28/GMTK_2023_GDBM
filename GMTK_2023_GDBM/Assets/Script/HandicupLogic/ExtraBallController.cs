using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExtraBallController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.tag == "Goal"){
            Destroy(gameObject);
        }
    }

    public void DestroyAllExtrtaBalls(Object player){
        ExtraBallController[] extraBalls = (FindObjectsOfType<ExtraBallController>() as ExtraBallController[]);
        for (int i = 0; i < extraBalls.Length; i++)
	    {
		    Destroy(extraBalls[i].gameObject);
        }
    }
}
