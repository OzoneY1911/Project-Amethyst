using UnityEngine;

public class bauScript : MonoBehaviour {

	public float velocity = 10.0f;

	bool abrir = false;
	bool cheio = true;
	
	void Update () {

		if (abrir) {
			if (transform.rotation.x > -0.9) {
				transform.Rotate (new Vector3 (-velocity * Time.deltaTime * 2, 0.0f, 0.0f));
				if(transform.rotation.x < -0.45 && cheio == true){
					liberar ();
					cheio = false;
				}
			} 
		} else {
			if (transform.rotation.x < 0) {
				transform.Rotate (new Vector3 (velocity * Time.deltaTime * 2 , 0.0f, 0.0f));

			} 
		}
	
	}


	void OnTriggerStay(Collider other) 
	{ 

		if (abrir == false) 
		{
			Vector3 pos = transform.position;
			pos.y += 0.5f;
			pos.z += 0.25f;
		}


		if (Input.GetKeyDown (KeyCode.E)) 
		{
				abrir = true;
		}
	}

	void OnTriggerExit(Collider other) 
	{
		abrir = false;
	}


	public void liberar()
	{
		Vector3 pos = transform.position;
		//pos.x = 0;
		pos.y += 0.4f;
		pos.z += 0.4f;
	}
}
