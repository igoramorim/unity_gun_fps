using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tiro : MonoBehaviour
{

    //Esse script fica nos tiros das armas. Cada tiro pode ter uma velocidade diferente, um "tempo de vida" e um dano
    //So adicionei o dano para voces saberem que seria nesse script. Como nao temos inimigos a programacao nao foi feita

    public float velocidade;    //Velocidade com que o tiro ira se movimentar
    public float tempoVida;     //Quantos segundos o tiro vai permanecer no jogo
                                //Precisamos destrui-lo depois de um tempo para nao acumular varios
                                //objetos 3d e evitar que trave

    private Rigidbody tiro;     //Variavel do tipo Rigidbody para trabalhar com a fisica do tiro e fazer ele andar
    public float dano;          //Dano do tiro, ou seja, quantidade de vida que vai tirar quando acertar um inimigo

    //Assim que o tiro for criado no jogo, faremos ele andar para frente e autodestruir-se depois de um tempo
    void Start()
    {
        tiro = gameObject.GetComponent<Rigidbody>();    //Pegamos o componente Rigidbody do GameObject
        tiro.AddForce(transform.forward * velocidade);  //Adicionamos um forca para frente (forward) multiplicada pela velocidade
        Destroy(gameObject, tempoVida);                 //Destruimos o proprio gameObject depois de um tempo (tempoVida)
    }

    // Update is called once per frame
    void Update()
    {

    }
}
