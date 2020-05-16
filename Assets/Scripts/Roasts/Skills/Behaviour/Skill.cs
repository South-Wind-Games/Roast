using System.Collections;
using System.Collections.Generic;
using Roasts;
using UnityEngine;
using UnityEngine.UIElements;

public abstract class Skill : MonoBehaviour
{
    protected RoastPlayer owner;
    //protected T data;
    protected int currentLevel;
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

   public abstract void Use();
}
