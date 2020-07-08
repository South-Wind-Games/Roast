using System.Collections;
using System.Collections.Generic;
using Data.Util;
using UnityEditor;
using UnityEngine;
namespace Roasts.Level
{
    public class GenerateLevel : MonoBehaviour
    {
        [SerializeField] private GameObject[] floorArray;

        [SerializeField] private GameObject[] objects;

        private float limites;

        private Vector3 objectsLocation;

        // Start is called before the first frame update
        void Start()
        {
            limites = 4;            
            
            
            Generate();

        }
       
        void Generate()
        {
        //piso
            int selectFloor;
            selectFloor = 0; //Random.Range(0, floorArray.Length);

            GameObject nuevoNivel=floorArray[selectFloor];

            

            Instantiate(nuevoNivel,transform.position, transform.rotation);
            
            //objetos

            int selectObject;
            selectObject = 0;//Random.Range(0, objectsArray.Length);
            
            
            GameObject nuevosObjetos=objects[selectObject];

            limites = Random.Range(-limites, limites);
            
             Instantiate(nuevosObjetos,new Vector3(limites,0,limites), transform.rotation);
            


        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}
