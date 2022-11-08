using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    [SerializeField] TMP_Text timer;
    [SerializeField] Transform player;
    [SerializeField] Transform win;
    int s = 00, m = 00, frames = 00;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        InvokeRepeating(timer.text=m.ToString()+":"+s.ToString(), 0f, 1f);

        frames++;
        if (frames == 60)
        {
            s++;
            frames = 0;
        }
        if (s == 60)
        {
            m++;
            s = 0;
        }
        
        if (player.transform.position.x == win.transform.position.x && player.transform.position.y == win.transform.position.y)
        {
            CancelInvoke();
           GetComponent<Timer>().enabled = false;
        }
    }
}
