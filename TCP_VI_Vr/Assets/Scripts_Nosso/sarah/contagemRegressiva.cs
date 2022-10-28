using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class contagemRegressiva : MonoBehaviour
{
    public float tempoTotal;
    private bool isRunning, tempoZerado;

    public void IniciarContador(float time)
    {
        tempoTotal = time;
        IsRunning = true;
        TempoZerado = false;
    }

    public void PararContagem()
    {
        IsRunning = false;
        TempoZerado = true;
    }

    public void Contagem()
    {
        if (IsRunning)
        {
            tempoTotal -= Time.deltaTime;
            if (tempoTotal <= 0)
            {
                IsRunning = false;
                TempoZerado = true;
            }
        }
    }
    public string FormatarTempo(int val)
    {
        int Seg = val % 60;
    val /= 60;
        int Min = val % 60;
    val /= 60;
        int Hour = val % 24;
        return strzero(Hour) + ":" + strzero(Min) + ":" + strzero(Seg);
    }
    private string strzero(int val)
    {
        /* Complemento Da Função "FormatarTempo()".  
         * Adiciona um '0' Na Frente Da Hora, Minuto Ou Segundo, Caso For Menor Que '10'. */
        return (val < 10) ? "0" + val.ToString() : val.ToString(); ;
    }
    public float TempoTotal
    {
        get
        {
            return tempoTotal;
        }

        set
        {
            tempoTotal = value;
        }
    }//END

    public bool IsRunning
    {
        get
        {
            return isRunning;
        }

        set
        {
            isRunning = value;
        }
    }//END

    public bool TempoZerado
    {
        get
        {
            return tempoZerado;
        }

        set
        {
            tempoZerado = value;
        }
    }
}
