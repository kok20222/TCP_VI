using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Maquina : MonoBehaviour
{
    public static Maquina instance;
    contagemRegressiva Contador1 = new contagemRegressiva();

    public TMP_Text lavarroupa1;
    public int roupas = 0;
    bool aux=false;
    int i=0;
    public GameObject[] SETAS;
    
    // Start is called before the first frame update
    void Start()
    {
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {

        
        if(roupas ==0){
            //se ainda nao apertoubotao
            if(i==0){
                 lavarroupa1.text = "Precisa-se lavar as 3 peças de roupa.";
            }
            if(i==1){
                 lavarroupa1.text = "Coloque as roupas que achar certo, sabão em pó e clique o botão.";
            }
            if(i==2){
                 lavarroupa1.text = "Dicas: Preste atenção nas cores, juntar cores com branco mancha!";
            }
      
          
        } 
         if(roupas==2){
            //se acabou o tempo
            lavarroupa1.text =   "Lavagem finalizada!";
        }

        //Debug.Log(i);
        
        
    }
    public void passarTexto(int indicador){
        
        if(indicador==0){
            if(i==1||i==0){
                i++;
            }
            
        }
        if(indicador==1){
            if(i==1||i==2){
                i--;
            }
            
        }
        
    }
   
      
    
}
