using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace DialogueSystem{

public class DialogueLines : DialogueBase
{
    private Text textHolder;
    
    [Header ("Customize Text")] 
    [SerializeField] private string input; // can be edited by UNITY
    [SerializeField] private Color textColor;
    [SerializeField] private Font textFont;

    [Header ("Time Parameters")]
    [SerializeField] private float delay;
    [SerializeField] private float delayBetweenLines;


    [Header ("Sound")]
    [SerializeField] private AudioClip sound;

    [Header ("Character Image")]
    [SerializeField] private Sprite characterSprite;
    [SerializeField] private Image imageHolder;

    private IEnumerator lineAppear; // the input text line

    private void Awake(){ // ensures the image is considered a part of the object and is always the same aspect ratio
 
        imageHolder.sprite = characterSprite;
        imageHolder.preserveAspect = true;
    }

    private void OnEnable(){ // takes the line

        ResetLine();
        lineAppear = WriteText(input, textHolder, textColor, textFont, delay, sound, delayBetweenLines);
        StartCoroutine(lineAppear);

    }

    private void Update(){
        if(Input.GetMouseButtonDown(0)){ // if click, skip the scroll; if not click, coroutine the text

            if(textHolder.text != input){
                StopCoroutine(lineAppear);
                textHolder.text = input;
            }
                
            else   
                finished = true;
        }
    }

    private void ResetLine(){ // replay the line

        textHolder = GetComponent<Text>();
        textHolder.text = "";
        finished = false;

    }
}
}
