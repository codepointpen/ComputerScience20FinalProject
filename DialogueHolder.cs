using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace DialogueSystem{

    public class DialogueHolder : MonoBehaviour
    {

        private bool dialogueFinished;

        private void OnEnable(){ // start the coroutine

            StartCoroutine(dialogueSequence());

        }

        private void Update(){ // if escape pressed, stop the dialogue and close the dialogue box
            if(Input.GetKey(KeyCode.Escape)){
                Deactivate();
                gameObject.SetActive(false);
                StopCoroutine(dialogueSequence());
            }
        }

        private IEnumerator dialogueSequence(){

            if(!dialogueFinished){ // allows for an extra dialogue encounter 

                for(int x = 0; x < transform.childCount - 1; x++){
                    Deactivate();
                    transform.GetChild(x).gameObject.SetActive(true);
                    yield return new WaitUntil(() => transform.GetChild(x).GetComponent<DialogueLines>().finished);
            }

            }

            else{ // plays the last dialogue object in the sequence
                int index = transform.childCount - 1;
                Deactivate();
                transform.GetChild(index).gameObject.SetActive(true);
                yield return new WaitUntil(() => transform.GetChild(index).GetComponent<DialogueLines>().finished);
                
            }

            dialogueFinished = true;

            gameObject.SetActive(false);

        }

        private void Deactivate(){ // deactivate the dialogue box ui
            for(int x = 0; x < transform.childCount; x++){
                transform.GetChild(x).gameObject.SetActive(false);
            }
        }
    }
}