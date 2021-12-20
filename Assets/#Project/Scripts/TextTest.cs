using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 
public class TextTest : MonoBehaviour { 
public Text test; 
public bool flag = true; 
// Use this for initialization 
void Start () { 
    if(flag){ 
        test.text = "This is true"; 
    } 
    else{ 
        test.text = "This is false"; 
    } 
} 
}
