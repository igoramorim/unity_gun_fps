using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    //Nesse script Player ficaria a vida do personagem, a coleta de itens e a vida do jogador

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    //Funcao responsavel pelas colisoes do jogador
    //A caixa de municao precisa estar com a opcao "Is Trigger" ativada no Inspector,
    //assim o jogador pega a municao somente uma vez ao colidir com a caixa
    
    //Essa parte e um pouco avancada, por isso nao fizemos em aula.
    //Continuem praticando e em breve voces conseguirao entender certinho!

    private void OnTriggerEnter(Collider other){

        //Verificamos se o item que o jogador colidiu possui a TAG "CaixaMunicao"
        if(other.gameObject.tag == "CaixaMunicao") {

            //Esse "var" significa que estou criando uma variavel local que sera usada somente nessa parte do codigo
            //Guardamos nela o componente "Atirar" do nosso Player.
            //Esse componente e o script que dispara e troca as armas do jogador
            var atirar = gameObject.GetComponent<Atirar>();

            //Pegamos a arma que o jogador esta usando no momento
            var armaAtual = atirar.armas[atirar.armaAtual];

            //Pegamos o componente "Arma" que e um script que toda arma possui e usamos a funcao AumentarMunicao()
            //Colocamos dentro dessa funcao a quantidade de municao que a caixa possui

            //Com esse other.gameObject.GetComponent<CaixaMunicao>().quantidadeMunicao
            //Pegamos a variavel "quantidadeMunicao" do componente "CaixaMunicao", que e o script que esta na caixa,
            armaAtual.GetComponent<Arma>().AumentarMunicao(other.gameObject.GetComponent<CaixaMunicao>().quantidadeMunicao);
        }
    }
}
