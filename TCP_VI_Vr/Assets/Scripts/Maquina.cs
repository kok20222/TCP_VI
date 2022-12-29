using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Maquina : MonoBehaviour
{

    contagemRegressiva Contador1 = new contagemRegressiva();

    public TMP_Text lavarroupa1;
    public int roupas = 2;
    bool aux=false;
    int i=0;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (Contador1.IsRunning)
        {
            Contador1.Contagem(); // Contando...
            lavarroupa1.text = "Tempo:  " + Contador1.FormatarTempo((int)Contador1.tempoTotal);
            if (roupas==3 && Contador1.tempoTotal <= 0)
            {
                //chamar funcao que acabou tempo
               roupas=4;
            }
        }

        

        if(roupas == 3 && Contador1.IsRunning==false){
            //se apertou botao
            contagemRegressiva();
            

        }
        if(roupas < 3){
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
        //lavarroupa1.text =  roupas + "/3";
          
        } 
         if(roupas ==4){
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
    /*
    void OnTriggerEnter(Collider other){

            if(other.tag == "roupa"){ 


                 roupas ++;

            }
            



        }



        void OnTriggerExit(Collider other){

            if(other.tag == "roupa"){


                roupas --;

            }
            



        }
*/
        public void contagemRegressiva()
    {
        
            Contador1.IniciarContador(20f);
        
        //chamar funcao para abrir porta e come�ar o jogo
    }
    
}
