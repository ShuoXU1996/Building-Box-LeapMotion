
using Leap;
using Leap.Unity;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move : MonoBehaviour
{
    LeapProvider provider;
    public HandModelManager handModelManager;
    SoundManager sou;
    

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
            
            if (hand.IsRight && hand.GrabAngle > 2)
            {
                handModelManager.GraphicsEnabled = false;


                transform.position = hand.PalmPosition.ToVector3() +

                                     hand.PalmNormal.ToVector3() *

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


//public class FollowLeapRVIG : MonoBehaviour
//{
//    //leap motion controller
//    [Tooltip("Must be in the scene")]
//    public HandController handController;

//    private Hand hand;
//    private HandModel handModel;

//    public Vector3 HandPosition
//    {
//        get;
//        protected set;
//    }

//    //visible default leap hand model attributes
//    public KeyCode visibleHandKey = KeyCode.V;

//    public bool defaultVisibleHand = false;
//    private bool visibleHand;

//    protected void Start()
//    {
//        HandPosition = new Vector3();
//        HandPosition = Vector3.zero;
//        visibleHand = defaultVisibleHand;
//    }

//    protected void Update()
//    {
//        UpdateTracker();
//        this.transform.position = HandPosition;
//    }

//    protected void UpdateTracker()
//    {
//        //get the 1st hand in the frame
//        if (handController.GetAllGraphicsHands().Length != 0)
//        {
//            handModel = handController.GetAllGraphicsHands()[0];
//            handModel.transform.GetComponentInChildren<SkinnedMeshRenderer>().enabled = visibleHand;
//            hand = handModel.GetLeapHand();
//            HandPosition = handModel.GetPalmPosition();
//        }

//        //mask/display the graphical hand on key down
//        if (Input.GetKeyDown(visibleHandKey))
//        {
//            var smr = handModel.transform.GetComponentInChildren<SkinnedMeshRenderer>();
//            visibleHand = !visibleHand;
//        }
//    }
//}