using System.Collections;
using System.Collections.Generic;
using System.IO.Ports;
using UnityEngine;

public class rotacaodedo : MonoBehaviour
{
    // declaração da porta serial do arduino
    SerialPort stream = new SerialPort("COM3", 9600);
    // Receber dados do arduino e pegar somente os valores dos sensores flex
    float valor = 0;

    // Array de objetos selecionáveis dentro do Unity
    public GameObject[] dedos = new GameObject[15];

    float dedoX1, dedoY1, dedoZ1, dedoX6, dedoY6, dedoZ6;
    float dedoX2, dedoY2, dedoZ2, dedoX7, dedoY7, dedoZ7;
    float dedoX3, dedoY3, dedoZ3, dedoX8, dedoY8, dedoZ8;
    float dedoX4, dedoY4, dedoZ4, dedoX9, dedoY9, dedoZ9;
    float dedoX5, dedoY5, dedoZ5, dedoX10, dedoY10, dedoZ10;
    float dedoX11, dedoY11, dedoZ11, dedoX12, dedoY12, dedoZ12;
    float dedoX13, dedoY13, dedoZ13, dedoX14, dedoY14, dedoZ14;
    float dedoX15, dedoY15, dedoZ15;

    // Variáveis para armazenar os valores de curvatura dos sensores flex
    float rotPol, rotInd, rotMed, rotAne, rotMin;

    void Start()
    {

        stream.Open();
        // Obtenção da rotação original de cada falange de todos os dedos
        dedoX1 = dedos[0].transform.localRotation.eulerAngles.x;
        dedoY1 = dedos[0].transform.localRotation.eulerAngles.y;
        dedoZ1 = dedos[0].transform.localRotation.eulerAngles.z;

        dedoX2 = dedos[1].transform.localRotation.eulerAngles.x;
        dedoY2 = dedos[1].transform.localRotation.eulerAngles.y;
        dedoZ2 = dedos[1].transform.localRotation.eulerAngles.z;

        dedoX3 = dedos[2].transform.localRotation.eulerAngles.x;
        dedoY3 = dedos[2].transform.localRotation.eulerAngles.y;
        dedoZ3 = dedos[2].transform.localRotation.eulerAngles.z;

        dedoX4 = dedos[3].transform.localRotation.eulerAngles.x;
        dedoY4 = dedos[3].transform.localRotation.eulerAngles.y;
        dedoZ4 = dedos[3].transform.localRotation.eulerAngles.z;

        dedoX5 = dedos[4].transform.localRotation.eulerAngles.x;
        dedoY5 = dedos[4].transform.localRotation.eulerAngles.y;
        dedoZ5 = dedos[4].transform.localRotation.eulerAngles.z;

        dedoX6 = dedos[5].transform.localRotation.eulerAngles.x;
        dedoY6 = dedos[5].transform.localRotation.eulerAngles.y;
        dedoZ6 = dedos[5].transform.localRotation.eulerAngles.z;

        dedoX7 = dedos[6].transform.localRotation.eulerAngles.x;
        dedoY7 = dedos[6].transform.localRotation.eulerAngles.y;
        dedoZ7 = dedos[6].transform.localRotation.eulerAngles.z;

        dedoX8 = dedos[7].transform.localRotation.eulerAngles.x;
        dedoY8 = dedos[7].transform.localRotation.eulerAngles.y;
        dedoZ8 = dedos[7].transform.localRotation.eulerAngles.z;

        dedoX9 = dedos[8].transform.localRotation.eulerAngles.x;
        dedoY9 = dedos[8].transform.localRotation.eulerAngles.y;
        dedoZ9 = dedos[8].transform.localRotation.eulerAngles.z;

        dedoX10 = dedos[9].transform.localRotation.eulerAngles.x;
        dedoY10 = dedos[9].transform.localRotation.eulerAngles.y;
        dedoZ10 = dedos[9].transform.localRotation.eulerAngles.z;

        dedoX11 = dedos[10].transform.localRotation.eulerAngles.x;
        dedoY11 = dedos[10].transform.localRotation.eulerAngles.y;
        dedoZ11 = dedos[10].transform.localRotation.eulerAngles.z;

        dedoX12 = dedos[11].transform.localRotation.eulerAngles.x;
        dedoY12 = dedos[11].transform.localRotation.eulerAngles.y;
        dedoZ12 = dedos[11].transform.localRotation.eulerAngles.z;

        dedoX13 = dedos[12].transform.localRotation.eulerAngles.x;
        dedoY13 = dedos[12].transform.localRotation.eulerAngles.y;
        dedoZ13 = dedos[12].transform.localRotation.eulerAngles.z;

        dedoX14 = dedos[13].transform.localRotation.eulerAngles.x;
        dedoY14 = dedos[13].transform.localRotation.eulerAngles.y;
        dedoZ14 = dedos[13].transform.localRotation.eulerAngles.z;

        dedoX15 = dedos[14].transform.localRotation.eulerAngles.x;
        dedoY15 = dedos[14].transform.localRotation.eulerAngles.y;
        dedoZ15 = dedos[14].transform.localRotation.eulerAngles.z;

    }

    void Update()
    {
        // Condição que certifica a abertura do portal serial do arduino
        if(stream.IsOpen == false)
        {
            stream.Open();
        }
        string value = stream.ReadLine(); // Lê os dados enviados pelo arduino e os armazena em uma variável
        valor = float.Parse(value); // Altera o tipo dos valores obtidos do arduino e armazena em uma variável
        valor = valor / 100;    // 

        // 
        rotPol = Mathf.Clamp(valor, 0, 40);
        rotInd = Mathf.Clamp(valor, 0, 70);
        rotMed = Mathf.Clamp(valor, 0, 70);
        rotAne = Mathf.Clamp(valor, 0, 70);
        rotMin = Mathf.Clamp(valor, 0, 70);
        print(valor);
       
    }

    private void LateUpdate()
    {
        // Rotaciona cada falange no eixo X somando a curvatura do sensor flex a curvatura originalaaaaaaaaaaaaaaaaaa
        dedos[0].transform.localRotation = Quaternion.Euler(dedoX1 + rotPol, dedoY1, dedoZ1);
        dedos[1].transform.localRotation = Quaternion.Euler(dedoX2 + rotPol, dedoY2, dedoZ2);
        dedos[2].transform.localRotation = Quaternion.Euler(dedoX3 + rotPol, dedoY3, dedoZ3);
        dedos[3].transform.localRotation = Quaternion.Euler(dedoX4 + rotInd, dedoY4, dedoZ4);
        dedos[4].transform.localRotation = Quaternion.Euler(dedoX5 + rotInd, dedoY5, dedoZ5);
        dedos[5].transform.localRotation = Quaternion.Euler(dedoX6 + rotInd, dedoY6, dedoZ6);
        dedos[6].transform.localRotation = Quaternion.Euler(dedoX7 + rotMed, dedoY7, dedoZ7);
        dedos[7].transform.localRotation = Quaternion.Euler(dedoX8 + rotMed, dedoY8, dedoZ8);
        dedos[8].transform.localRotation = Quaternion.Euler(dedoX9 + rotMed, dedoY9, dedoZ9);
        dedos[9].transform.localRotation = Quaternion.Euler(dedoX10 + rotAne, dedoY10, dedoZ10);
        dedos[10].transform.localRotation = Quaternion.Euler(dedoX11 + rotAne, dedoY11, dedoZ11);
        dedos[11].transform.localRotation = Quaternion.Euler(dedoX12 + rotAne, dedoY12, dedoZ12);
        dedos[12].transform.localRotation = Quaternion.Euler(dedoX13 + rotMin, dedoY13, dedoZ13);
        dedos[13].transform.localRotation = Quaternion.Euler(dedoX14 + rotMin, dedoY14, dedoZ14);
        dedos[14].transform.localRotation = Quaternion.Euler(dedoX15 + rotMin, dedoY15, dedoZ15);

    }
}