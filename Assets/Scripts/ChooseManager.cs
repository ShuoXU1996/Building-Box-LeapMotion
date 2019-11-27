using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Leap;
using Leap.Unity;

public class ChooseManager : MonoBehaviour
{
    public GameObject[] cubes;
    LeapProvider provider;
    
    
   
    Transform preclo = null;//Pour asurer chaque fois un object


    // Start is called before the first frame update
    void Start()
    {
        provider = FindObjectOfType<LeapProvider>() as LeapProvider;

        cubes = GameObject.FindGameObjectsWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {

        Frame frame = provider.CurrentFrame;

        foreach (Hand hand in frame.Hands)
        {
            if(hand.IsLeft)
            {
                Transform clostest;

                clostest = GetClosestObject(cubes,hand);


                if (hand.GrabAngle <= 2)
                {
                    if (clostest)
                    {
                        if (preclo != null && clostest != preclo)
                        {

                            preclo.GetComponent<MeshRenderer>().material.color = Color.white;
                            preclo.GetComponent<MoveLeft>().enabled = false;
                        }
                        clostest.GetComponent<MeshRenderer>().material.color = Color.blue;
                        clostest.GetComponent<MoveLeft>().enabled = true;

                        preclo = clostest;
                    }
                    else
                    {
                        preclo = null;

                        InitObject(cubes);
                    }
                }

            }





        }


    }


    Transform GetClosestObject(GameObject[] obj, Hand hand)
    {
        Transform tMin = null;
        float minDist = 0.1f;
        Vector3 currentPos = hand.PalmPosition.ToVector3();
        foreach (GameObject tt in obj)
        {
            Transform t = tt.GetComponent<Transform>();
            float dist = Vector3.Distance(t.position, currentPos);
           
            if (dist < minDist)
            {
                tMin = t;
                minDist = dist;
            }
        }
        return tMin;
        
    }

    void InitObject(GameObject[] obj)
    {
        
        foreach (GameObject tt in obj)
        {
            Transform t = tt.GetComponent<Transform>();
            t.GetComponent<MeshRenderer>().material.color = Color.white;
            t.GetComponent<MoveLeft>().enabled = false;
            
        }
       
    }


}
