using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Server : MonoBehaviour
{
    float t = 0;

    public void Update()
    {
        t += Time.deltaTime;
        
        if(t >= 0.100f)
		{
            t -= 0.100f;
            Debug.Log("Hello...");
		}
    }
}
