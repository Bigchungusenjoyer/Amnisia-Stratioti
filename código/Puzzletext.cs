using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puzzletext : MonoBehaviour
{

    [SerializeField] Transform player;
    float x = 0f, y = 0f;
    // Start is called before the first frame update
    void Start()
    {
        x = transform.position.x;
        y = transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        if (x == player.transform.position.x && y-1f == player.transform.position.y && Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log("O rei dos animais � o primeiro a chegar,logo em seguida vem o r�ptil,o amante de lama chega em terceiro e por �ltimo chega aquele com asas");
        }
    }
}
