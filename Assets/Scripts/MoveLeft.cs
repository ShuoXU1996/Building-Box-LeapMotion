
using Leap;
using Leap.Unity;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class MoveLeft : MonoBehaviour
{
    LeapProvider provider;
    public HandModelManager handModelManager;
    


    void Start()
    {
        provider = FindObjectOfType<LeapProvider>() as LeapProvider;
        //handModel = FindObjectOfType<HandModel>() as HandModel;
        handModelManager.GraphicsEnabled = true;
      
        
    }


    void Update()
    {

        Frame frame = provider.CurrentFrame;

        foreach (Hand hand in frame.Hands)
        {
            if (hand.IsLeft && hand.GrabAngle > 2)
            {
                handModelManager.GraphicsEnabled = false;


                transform.position = hand.PalmPosition.ToVector3() +

                                    2 * hand.PalmNormal.ToVector3() *

                                  (transform.localScale.y * .5f + .02f);


                transform.rotation = hand.Basis.CalculateRotation();
                


            }
            else
            {

                handModelManager.GraphicsEnabled = true;
            }

         



        }


    }
}
