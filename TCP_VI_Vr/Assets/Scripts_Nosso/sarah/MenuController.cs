using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class MenuController : MonoBehaviour
{
    public TMP_InputField tempoInput;
    public TMP_Text SOBRA;
    public GameObject tempoInputUi;
    public GameObject[] checks;
    public GameObject macaneta;
    public GameObject TextTime1Ui;
    public GameObject vitoriaUI;
    public GameObject derrotaUI;
    public TMP_Text TextTimeHand;
    public float valor;
    
    public static MenuController instance;
    contagemRegressiva Contador1 = new contagemRegressiva();
    public TMP_Text TextTime1;
    public int vitoryCond=0;

    // Start is called before the first frame update
    void Start() {
        instance = this;
    }
    void Awake() {
        DontDestroyOnLoad(transform.gameObject);
    }
    public void panelTrue(GameObject go){
        go.SetActive(true);
    }
     public void panelFalse(GameObject go){
        go.SetActive(false);
    }
    public void nextScene(int nextSceneIndex){
        SceneManager.LoadScene(nextSceneIndex);
    }
    public void movimentacaoConfig(int mov){
        if(mov==0){//tp
            //movimentaciontConfig.instance.teleportEnable=true;
        }
        if(mov==1){//joystick
            //movimentaciontConfig.instance.teleportEnable=false;
        }

    }
    public void quit()
    {
        Application.Quit();
    }
    public void contagemRegressiva(GameObject iniciarBtn)
    {
        macaneta.SetActive(true);
        tempoInputUi.SetActive(false);
        TextTime1Ui.SetActive(true);
        Destroy(iniciarBtn);
        
        
            Contador1.IniciarContador((int)valor);
        
       
            Debug.Log("Not a valid int");
        
        //chamar funcao para abrir porta e come�ar o jogo
    }


    
    private void FixedUpdate()
    {
        // Contador 1
        if (Contador1.IsRunning)
        {
            Contador1.Contagem(); // Contando...
            TextTime1.text = "Tempo:  " + Contador1.FormatarTempo((int)Contador1.tempoTotal);
             TextTimeHand.text = "Tempo:  " + Contador1.FormatarTempo((int)Contador1.tempoTotal);

             if(vitoryCond<2 && Contador1.tempoTotal<0){
                panelTrue(derrotaUI);
                 Time.timeScale = 0;
             }
            
        }
        if(vitoryCond==2){
            float tempoSobra = Contador1.tempoInicial - Contador1.tempoTotal;
             SOBRA.text = Contador1.FormatarTempo((int)tempoSobra);
            panelTrue(vitoriaUI);
            Time.timeScale = 0;
        }
        
    }


    public void valorset(float v){

        valor = v;

    }

}
