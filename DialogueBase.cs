using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace DialogueSystem{

    public class DialogueBase : MonoBehaviour
    {
        public bool finished { get; protected set;}

        protected IEnumerator WriteText(string input, Text textHolder, Color textColor, Font textFont, float delay, AudioClip sound, float delayBetweenLines){ // shows letters one by one
            
            textHolder.color = textColor; // text color taken from dialoguelines
            textHolder.font = textFont; // text font taken from dialoguelines

            if (textHolder == null) {
                Debug.LogError("Text holder is null. Please assign a Text component to display the text.");
            yield break; // exit the coroutine
            }
            
            for(int x = 0; x < input.Length; x++){
                textHolder.text += input[x];

                if (SoundManager.instance != null && sound != null){
                    SoundManager.instance.PlaySound(sound); // play letter sound
                }
                yield return new WaitForSeconds(delay); // calls the computer to wait for 0.1 seconds before continuing the loop
            }

            yield return new WaitUntil(() => Input.GetMouseButtonUp(0)); // if right click, stop the text scroll
            finished = true;
        } 

    }
}