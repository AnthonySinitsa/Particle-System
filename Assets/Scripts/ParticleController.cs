using UnityEngine;

public class ParticleController : MonoBehaviour{
    private ParticleSystem myParticleSystem;

    void Start(){
        myParticleSystem = GetComponent<ParticleSystem>();
    }

    void Update(){
        if (Input.GetKeyDown(KeyCode.Space)){
            if (myParticleSystem.isEmitting){
                myParticleSystem.Stop();
            }
            else{
                myParticleSystem.Play();
            }
        }
    }
}
