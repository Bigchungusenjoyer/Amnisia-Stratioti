using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rock : MonoBehaviour
{
    float x = 0f, y = 0f;
    int i = 0,right=0,left=0,up=0,down=0;
  [SerializeField]  Transform  Jogador;
   [SerializeField] Vector2 Jogadorposicao;
    [SerializeField] Transform[] paredes;
    [SerializeField] Vector2[] posicaoparedes;
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
        x = transform.position.x;
        y = transform.position.y;
        Jogadorposicao = new Vector2(Jogador.transform.position.x, Jogador.transform.position.y);
        
      
        bool andar = true;
      
        
        
            if (x+1f == Jogador.transform.position.x && y == Jogador.transform.position.y && Input.GetKeyDown(KeyCode.LeftArrow))
            {
            left++;
            right = 0;
            up = 0;
            down = 0;
            if (left == 2 && x + 1f == Jogador.transform.position.x && y == Jogador.transform.position.y && Input.GetKeyDown(KeyCode.LeftArrow))
            {
                 x--;
                left = 0;
                Debug.Log("why isn't this working?,is there something missing,must more blood be shed?");
            }
            }


        if (y + 1f == Jogador.transform.position.y && x == Jogador.transform.position.x && Input.GetKeyDown(KeyCode.DownArrow))
        {
            left=0;
            right = 0;
            up = 0;
            down ++;
           if (down==2  && y + 1f == Jogador.transform.position.y && x == Jogador.transform.position.x && Input.GetKeyDown(KeyCode.DownArrow))

                {
                y--;
                down = 0;
                 }
        }


            
                
                
                    if (x-1f == Jogador.transform.position.x && y == Jogador.transform.position.y&& Input.GetKeyDown(KeyCode.RightArrow))
                    {
             left = 0;
            right ++;
            up = 0;
            down=0;
            if ( right==2 && x - 1f == Jogador.transform.position.x && y == Jogador.transform.position.y && Input.GetKeyDown(KeyCode.RightArrow))

            {
                x++;
                right = 0;
            }

        }
                   
                    
                        if (y-1f == Jogador.transform.position.y && x == Jogador.transform.position.x && Input.GetKeyDown(KeyCode.UpArrow))
                        {
            left = 0;
            right = 0;
             up++;
            down=0;
            if(up==2 && y - 1f == Jogador.transform.position.y && x == Jogador.transform.position.x && Input.GetKeyDown(KeyCode.UpArrow))
            {
                y++;
                up = 0;
            }
                        }
                        if(x!=Jogador.transform.position.x && y!=Jogador.transform.position.y)
        {
            left = 0;
                right = 0;
                up = 0;
                down = 0;

        }

                    
                
            
        
        
        Vector2 posicao = new Vector2(x, y);
        for (i = 0; i < paredes.Length; i++)
        {
            if (posicao == posicaoparedes[i])
            {
                andar = false;

            }
        }
        if (andar == false)
        {
            Debug.Log("no way fag");
        }

        if (andar == true)
        {
            transform.position = new Vector2(x, y);
        }
    }
}
