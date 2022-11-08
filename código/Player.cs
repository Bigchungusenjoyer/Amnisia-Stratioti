using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    #region variaveís 
    float x = 0f, y = 0f;
    int i = 0, j = 0, buttonspressed = 0, yellow = 0, red = 0, blue = 0, green = 0;
    bool yellowpressed = false, redpressed = false, greenpressed = false, bluepressed = false, puzzlecomplete = false;
    Vector2[] posicaobotoes;
    [SerializeField] Transform[] paredes;
    [SerializeField] Vector2[] posicaoparedes;
    [SerializeField] Transform[] pedras;
    [SerializeField] Vector2[] posicaopedras;
    [SerializeField] Transform[] Minotauro;
    [SerializeField] Vector2 PosicaoMinotauro;
    [SerializeField] Transform[] botoes;
    [SerializeField] Transform[] coloredbotoes;
    [SerializeField] Transform win;
    [SerializeField] Transform activator;
    #endregion
    // Start is called before the first frame update
    void Start()
    {
        #region posição das paredes e botões
        posicaoparedes = new Vector2[paredes.Length];
        for (i = 0; i < paredes.Length; i++)
        {
            posicaoparedes[i] = new Vector2(paredes[i].transform.position.x, paredes[i].transform.position.y);
        }
        posicaobotoes = new Vector2[botoes.Length];
        for (i = 0; i < botoes.Length; i++)
        {
            posicaobotoes[i] = new Vector2(botoes[i].transform.position.x, botoes[i].transform.position.y);
        }
    }
    #endregion
    
    // Update is called once per frame
    void Update()
{    
    
    

       {   
        x = transform.position.x;
        y = transform.position.y;
            buttonspressed = 0;
            #region colisão com pedras e botões
            Vector2 Oldposition = new Vector2(x, y);
            if (Minotauro.Length > 0)
            {
                PosicaoMinotauro = new Vector2(Minotauro[0].transform.position.x, Minotauro[0].transform.position.y);
            }
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
            #endregion
            #region movimentação do player e colisão com paredes
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
            if (x == win.transform.position.x && y == win.transform.position.y && puzzlecomplete==false)
            {
                andar = false;
            }

        for (i = 0; i <paredes.Length; i++)
        {
            if (destino == posicaoparedes[i])
            {
                andar = false;

            }
        }
            if (andar == false)
            {
                
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
                   
                }
                else
                {
                    transform.position = new Vector2(x, y);
                }
                #endregion
                #region puzzle dos botões coloridos
                if (coloredbotoes.Length > 3)
                {
                    if (x == coloredbotoes[0].transform.position.x && y == coloredbotoes[0].transform.position.y && yellowpressed == false)
                    {
                        if (redpressed == false && greenpressed == false && bluepressed == false)
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
                  

                    if (redpressed == true && greenpressed == true && yellowpressed == true && bluepressed == true && x == activator.transform.position.x && y == activator.transform.position.y)
                    {
                        if (blue == 1 && red == 1 && yellow == 1 && green == 1)
                        {
                            Debug.Log("are You Jimmy Neutron my guy?");
                            puzzlecomplete = true;

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
                #endregion
                if (buttonspressed == botoes.Length && buttonspressed > 0)
                {
                    puzzlecomplete = true;
                }
                if (x == win.transform.position.x && y == win.transform.position.y && puzzlecomplete == true)
                {
                    GetComponent<Player>().enabled = false;
                    Debug.Log("you have completed the labyrint,very cool");
                }


            }
              
        }
    }
}
