using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    float x = 0f, y = 0f;
    int i = 0,j=0,buttonspressed=0,yellow=0,red=0,blue=0,green=0;
    bool yellowpressed = false, redpressed = false, greenpressed = false, bluepressed = false;
    Vector2 [] posicaobotoes;
    [SerializeField] Transform[] paredes;
    [SerializeField] Vector2[] posicaoparedes;
    [SerializeField] Transform[] pedras;
    [SerializeField] Vector2[] posicaopedras;
    [SerializeField] Transform Minotauro;
    [SerializeField] Vector2 PosicaoMinotauro;
    [SerializeField] Transform[] botoes;
    [SerializeField] Transform[] coloredbotoes;
    [SerializeField] Transform win;
    // Start is called before the first frame update
    void Start()
    {
        posicaoparedes = new Vector2[paredes.Length];
for(i=0; i<paredes.Length;i++)
        {
             posicaoparedes[i]= new Vector2( paredes[i].transform.position.x,paredes[i].transform.position.y);
        }
        posicaobotoes = new Vector2[botoes.Length];
        for (i = 0; i < botoes.Length; i++)
        {
            posicaobotoes[i] = new Vector2(botoes[i].transform.position.x, botoes[i].transform.position.y);
        }
    }

    // Update is called once per frame
    void Update()
    {

       {   
        x = transform.position.x;
        y = transform.position.y;
            buttonspressed = 0;
            Vector2 Oldposition = new Vector2(x, y);
            PosicaoMinotauro = new Vector2(Minotauro.transform.position.x, Minotauro.transform.position.y);
            posicaopedras = new Vector2[pedras.Length];
            for (i = 0; i < pedras.Length; i++)
            {
                posicaopedras[i] = new Vector2(pedras[i].transform.position.x, pedras[i].transform.position.y);
            }
            for(j=0;j<botoes.Length;j++)
            {
                for(i=0;i<pedras.Length;i++)
                {
                    if (posicaobotoes[j]==posicaopedras[i])
                    {
                        buttonspressed++;
                    }
                }
                if(posicaobotoes[j]==Oldposition)
                {
                    buttonspressed++;
                }
                if (PosicaoMinotauro==posicaobotoes[j])
                {
                    buttonspressed++;
                }
            }

            if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            
                x++;

        }

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {

            x--;
        }
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
           
                y++;           
        }

        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
                y--;


        }
        Vector2 destino = new Vector2(x, y);
        bool andar = true;
        for (i = 0; i <paredes.Length; i++)
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
                if (x == coloredbotoes[0].transform.position.x && y== coloredbotoes[0].transform.position.y && yellowpressed==false)
                {
                    if (redpressed==false && greenpressed==false && bluepressed==false )
                    {
                        yellow = 1;
                        yellowpressed = true;
                        Debug.Log("you have big brian");
                    }
                    else 
                    {
                        yellowpressed = true;
                        Debug.Log("joe mama");
                    }
                }
                if (x == coloredbotoes[1].transform.position.x && y == coloredbotoes[1].transform.position.y && greenpressed == false)
                {
                    if (redpressed == false && yellowpressed == true && bluepressed == false)
                    {
                        green = 1;
                        greenpressed = true;
                        Debug.Log("you have big brian");
                    }
                    else
                    {
                        greenpressed = true;
                    }
                }
                if (x == coloredbotoes[2].transform.position.x && y == coloredbotoes[2].transform.position.y && redpressed == false)
                {
                    if (yellowpressed == true && greenpressed == true && bluepressed == false)
                    {
                        red = 1;
                        redpressed = true;
                        Debug.Log("you have big brian");
                    }
                    else
                    {
                        redpressed = true;
                    }
                }
                if (x == coloredbotoes[3].transform.position.x && y == coloredbotoes[3].transform.position.y && bluepressed == false)
                {
                    if (redpressed == true && greenpressed == true && yellowpressed == true)
                    {
                        blue = 1;
                        bluepressed = true;
                        Debug.Log("you have big brian");
                    }
                    else
                    {
                        bluepressed = true;
                    }
                }
                if (buttonspressed==botoes.Length && buttonspressed>0 && x==win.transform.position.x && y==win.transform.position.y)
                {
                    GetComponent<Player>().enabled = false;
                    Debug.Log("you have completed the labyrint,very cool");
                }
                
                    if(redpressed == true && greenpressed == true && yellowpressed == true && bluepressed==true && x == win.transform.position.x && y == win.transform.position.y)
                    {
                    Debug.Log("no fucking way");
                    if ( blue==1 && red==1 && yellow==1 && green==1)
                        {
                       
                         GetComponent<Player>().enabled = false;
                         
                            Debug.Log("you have completed the labyrint,very cool");
                            
                        }
                        else
                        {
                        Debug.Log("hhahahhaaha you stuped");
                            yellowpressed = false;
                            redpressed = false; 
                               greenpressed = false; 
                                bluepressed = false;
                        }
                    }
                
            }
              
        }
    }
}
