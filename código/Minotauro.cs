using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Minotauro : MonoBehaviour
{
    float x = 0f, y = 0f;
    int i = 0;
    [SerializeField] Transform [] paredes;
    [SerializeField] Vector2[] posicaoparedes;
    [SerializeField] Transform[] pedras;
    [SerializeField] Vector2[] posicaopedras;
    [SerializeField] Transform Player;
    [SerializeField] Transform Win;
    // Start is called before the first frame update
    void Start()
    {
        posicaoparedes = new Vector2[paredes.Length];
        for (i = 0; i < paredes.Length; i++)
        {
            posicaoparedes[i] = new Vector2(paredes[i].transform.position.x, paredes[i].transform.position.y);
        }
       
    }

    // Update is called once per frame
    void Update()
    {

        {
            x = transform.position.x;
            y = transform.position.y;
            posicaopedras = new Vector2[pedras.Length];
            for (i = 0; i < pedras.Length; i++)
            {
                posicaopedras[i] = new Vector2(pedras[i].transform.position.x, pedras[i].transform.position.y);
            }
           

            if (Input.GetKeyDown(KeyCode.RightArrow))
            {

                x--;

            }

            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {

                x++;
            }
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {

                y--;
            }

            if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                y++;


            }
            Vector2 destino = new Vector2(x, y);
            bool andar = true;
            for (i = 0; i < paredes.Length; i++)
            {
                if (destino == posicaoparedes[i])
                {
                    andar = false;

                }
            }
            if (andar == false)
            {
                Debug.Log("no way fag");
            }
            else
            {
                for (i = 0; i < pedras.Length; i++)
                {
                    if (destino == posicaopedras[i])
                    {
                        andar = false;

                    }
                }
                if (andar == false)
                {
                    Debug.Log("no way fag");
                }
                else
                {
                    transform.position = new Vector2(x, y);
                }
            }
            if(Player.transform.position.x==Win.transform.position.x && Player.transform.position.y == Win.transform.position.y)
            {
                GetComponent<Minotauro>().enabled = false;
            }
        }
    }
}
