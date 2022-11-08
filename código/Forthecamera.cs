using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Forthecamera : MonoBehaviour
{
    [SerializeField] Transform Player;
    
    float x = 0f, y = 0f,z=0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        {
            x = transform.position.x;
            if(Player.transform.position.x== x+6f)
            {
                x = x + 6f;
            }
            if(Player.transform.position.x == x - 6f)
            {
                x = x - 6f;
            }
                y = transform.position.y;
                    z = transform.position.z;
                    transform.position = new Vector3(x, y, z);
                
        }
    }
  }

