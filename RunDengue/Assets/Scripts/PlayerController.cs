using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PlayerController : MonoBehaviour {
	//criar um componente de audio
	//pega um script do gerenciador e a partir disso posso solicitar para tocar 
	public AudioSource audioControllerPlayer;
	public AudioClip soundJump;
	public AudioClip soundSlide;
	public AudioClip soundErr;

	//variável para pegar o corpo rígido do personagem, mas à atribuição é feita na engine
	public Rigidbody2D PlayerRigidbory;

	//Esta varável controlará as animações do personagem
	public Animator anim;

	//Vamos verificar se o personagem está no chão
	public Transform groundCheck; //pega a posição do colider que verifica o chão
	public bool grounded = false;
	public LayerMask whatIsGround;


	//verifica para fazer slide
	public float slideTemp;
	public float timeTemp;
	private bool slide;

	//controla a força do pulo
	public int forceJump = 1;
	// Use this for initialization

	//mudar o colider de posição
	public Transform colisor;

	//pontuação
	//public UnityEngine.UI.Text pontos;
	//public static int pontuação = 0;


	void Start () {
		//pontuação = 0;
		//toda vez que o jogo começar ela recebe 0
	//	PlayerPrefs.SetInt("pontuacao", 0);
		PlayerPrefs.SetInt("record", 0);
	}


	
	// Update is called once per frame
	void Update () {
		//PARA SAIR
		if (Input.GetKey("escape"))
			Application.Quit();

		

	//	pontos.text = pontuação.ToString ();

		/*/Para verificar se o botão foi pressionado e estiver no chão
		if(Input.GetButtonDown("Jump") && grounded || Input.GetKeyDown(KeyCode.UpArrow)&& grounded){	
			
			if (slide) {
				slide = false;
				//aqui é apenas a verificação do colisor para quando ele estiver abaixado e pular o colider voltar ao seu lugar
				colisor.position = new Vector3(colisor.position.x, colisor.position.y + 0.3f, colisor.position.z);
			}
			//Assim que for pressionado eu crio um novo vetor que contém o X,Y que passo à forca a ser adicionada
			PlayerRigidbory.AddForce (new Vector2 (0, forceJump));
			PlayJumpSound ();

		}
		if(Input.GetButtonDown("Slide") && grounded||Input.GetKeyDown(KeyCode.DownArrow)&& grounded){
			if (!slide) {
				//Para o colisor baixar
				colisor.position = new Vector3 (colisor.position.x, colisor.position.y - 0.3f, colisor.position.z);
				//para a animação
				slide = true;
				timeTemp = 0f;
				PlaySlideSound ();
			}										
		}


		*/
		//faço a verificação de tempo no slide
		if (slide) {
			timeTemp += Time.deltaTime;
			if (timeTemp >= slideTemp) {
				//para o colisor subir 
				colisor.position = new Vector3(colisor.position.x, colisor.position.y + 0.3f, colisor.position.z);
				slide = false;
			}
		}

		//Aqui irei pegar o animator e mandar para ele os valores para que ele possa executar as animações
		anim.SetBool("jump",!grounded);
		anim.SetBool ("slide", slide);

		//aqui temos o overlap que retorna true se tiver no chão e também passo a possição que ele deve ser criado 
		//e passa qual layer ele 
		//verifica
		grounded = Physics2D.OverlapCircle(groundCheck.position, 0.7f, whatIsGround);
	}


	void PlayErrSound (){
		audioControllerPlayer.PlayOneShot (soundErr);
	}

	void PlaySlideSound (){
		audioControllerPlayer.PlayOneShot (soundSlide);
	}

	void PlayJumpSound (){
		audioControllerPlayer.PlayOneShot (soundJump);
	}


	public void touchJump(){
		//Para verificar se o botão foi pressionado e estiver no chão
		if(grounded){				
			if (slide) {
				slide = false;
				//aqui é apenas a verificação do colisor para quando ele estiver abaixado e pular o colider voltar ao seu lugar
				colisor.position = new Vector3(colisor.position.x, colisor.position.y + 0.3f, colisor.position.z);
			}
			//Assim que for pressionado eu crio um novo vetor que contém o X,Y que passo à forca a ser adicionada
			PlayerRigidbory.AddForce (new Vector2 (0, forceJump));
			//chama função para tocar audio do player
			PlayJumpSound ();
			
		}
	}

	public void touchslide(){
		if(grounded){
			//chama função para tocar audio do player
			PlaySlideSound ();
			if (!slide) {
				//Para o colisor baixar
				colisor.position = new Vector3 (colisor.position.x, colisor.position.y - 0.3f, colisor.position.z);
				//para a animação
				slide = true;
				timeTemp = 0f;
			}
		}	
	}


	//função para verificar colisão
	void OnTriggerEnter2D(Collider2D outher){		
		
		if(outher.tag == "Aedes"){		
			PlayErrSound ();
			//changer color after die
			GetComponent<SpriteRenderer> ().color = new Color (255f, 0f, 0f,255f);
			pontuationController.CheckPontuation ();

			SceneManager.LoadScene("lost");

			/*PlayerPrefs.SetInt("pontuation", pontuationController.pontuation);
			//
			if(pontuationController.pontuation > PlayerPrefs.GetInt("record")){
				PlayerPrefs.SetInt("record", pontuationController.pontuation);	
			}*/

		}

		
	}
}