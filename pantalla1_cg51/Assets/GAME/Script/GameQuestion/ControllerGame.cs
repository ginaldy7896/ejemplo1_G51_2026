using System.Collections.Generic;
using UnityEngine;
using System.IO;
using TMPro;


public class ControllerGame : MonoBehaviour
{
    [Header ("Configuración de UI" ) ]
    [SerializeField] private TextMeshProUGUI componenteTextoPregunta;
    [SerializeField] private TextMeshProUGUI[] componentesTextosBotones; 
    [SerializeField] private TextMeshProUGUI componenteTextoVersiculo;

    [Header ("Datos del juego") ]
    [SerializeField] private List<MultipleQuestion> listaPreguntas = new List<MultipleQuestion>();
    private MultipleQuestion CurrentAnswer;


    void Start()
    {
        LoadMultipleQuestion();//lee las preguntas y crea la lista 

        NextQuestion();
    }

    private void LoadMultipleQuestion()
    {
        string FileName = "Archivo_preguntas";
        string ruta = Path.Combine(Application.streamingAssetsPath, FileName);

        if (File.Exists(ruta))
        {
            string[] lineas = File.ReadAllLines(ruta);
            foreach (string line in lineas)
            {
                string[] partes = line.Split('-');

                if (partes.Length > 8)
                {
                    MultipleQuestion NewA = new MultipleQuestion();

                    NewA.Question = partes[0].Trim();

                    NewA.Options[0] = partes[1].Trim();
                    NewA.Options[1] = partes[2].Trim();
                    NewA.Options[2] = partes[3].Trim();
                    NewA.Options[3] = partes[4].Trim();

                    NewA.CorrectAnswer = partes[5].Trim();

                    NewA.Versiculo = partes[6].Trim();
                    NewA.Difficultly = partes[7].Trim();

                    listaPreguntas.Add(NewA);

                }
            }
            Debug.Log("Preguntas cargadas:" + listaPreguntas.Count);
        }
        else
        {
            Debug.LogError("No se encontró el archivo en:" + ruta);
        }
    }

    public void NextQuestion()
    {
        if (listaPreguntas.Count > 0)
        {
            componenteTextoVersiculo.gameObject.SetActive(false);

            componenteTextoPregunta.text = CurrentAnswer.Question;
            for (int i = 0; i < componentesTextosBotones.Length; i++)
            {
                componentesTextosBotones[i].text = CurrentAnswer.Options[i];

            }
        }

    }

    public void ValidateResponse(int indiceBoton)
    {
        string textoDelBotonPresionado = componentesTextosBotones[indiceBoton].text;

        if (textoDelBotonPresionado == CurrentAnswer.CorrectAnswer)
        {
            Debug.Log("¡Correcto! ");
            componenteTextoVersiculo.text = " ¡Correcto! " + CurrentAnswer.Versiculo;
        }
        else
        {
            Debug.Log("¡Incorrecto!");
            componenteTextoVersiculo.text = "Incorrecto la respuesta correcta es : " + CurrentAnswer.CorrectAnswer + "." + CurrentAnswer.Versiculo;

        }

        componenteTextoVersiculo.gameObject.SetActive(true);



    }

}

    