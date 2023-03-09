using UnityEngine;

public class ExampleScript : MonoBehaviour
{
    public float velocidade;
    public GameObject c;
    //float velocidade = 5.0f;
    float incliAngulo = 75.0f;

    void Update()
    { 
        // Inclina o objeto levemente em direção a rotação alvo   
        float InclinaX = Input.GetAxis("Vertical") * incliAngulo;
        print(InclinaX);

        // Rotaciona o objeto convertendo o angulo em um quaternio.
        Quaternion inicio = Quaternion.Euler(c.transform.localRotation.x, c.transform.localRotation.y, c.transform.localRotation.z);
        Quaternion alvo = Quaternion.Euler(InclinaX, 33f, 26f);

        // Dampen towards the target rotation
        transform.localRotation = Quaternion.Slerp(inicio, alvo,  Time.deltaTime * velocidade);
    }
}