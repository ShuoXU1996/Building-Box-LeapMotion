using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Leap;
using Leap.Unity;
using UnityEngine.UI;

public class MusicGesture : MonoBehaviour
{
    LeapProvider provider;
    public Text text;
    public float smallestVelocity = 2f;//手掌移动的最小速度

    //[Tooltip("Velocity (m/s) of Single Direction ")]
    //[Range(0, 1)]
    public float deltaVelocity = 2f;//单方向上手掌移动的速度
    List<string> musicNames;
    int i = 0;
    bool isMusicPlay = false;
    // Start is called before the first frame update
    void Start()
    {
        provider = FindObjectOfType<LeapProvider>() as LeapProvider;
        musicNames = new List<string>();
        musicNames.Add("stephy-bebe-cochon-chanson");
        musicNames.Add("stephy-berlingot-le-crapaud-chanson");
        musicNames.Add("stephy-jingle-bells-chanson-noel");
        text.text = "Music Stop";


    }
    
    // Update is called once per frame
    void Update()
    {
        Frame frame = provider.CurrentFrame;
        foreach (Hand hand in frame.Hands)
        {
            if(hand.IsLeft)
            {
                if (hand.GrabAngle <= 2)
                {
                    if (isMoveRight(hand))
                    {
                        if (i == musicNames.Count - 1)
                            i = 0;
                        Debug.Log("i " + i);
                        isMusicPlay = true;
                        playMusic(musicNames[i++]);
                    }
                    else if (isMoveForward(hand))
                    {
                        isMusicPlay = false;
                        SoundManager.Instance.StopMusic();
                        text.text = "Music Stop";
                    }
                }
            }
        }

    }

    void playMusic(string name)
    {
        SoundManager.Instance.PlayMusicByName(name);
        text.text = name;
        
    }


    //hand move four direction
    public bool isMoveRight(Hand hand)
    {

        return hand.PalmVelocity.x > deltaVelocity && !isStationary(hand);
    }

    // 手划向右边
    public bool isMoveLeft(Hand hand)
    {

        //print (hand.PalmVelocity.x );
        return hand.PalmVelocity.x < -deltaVelocity && !isStationary(hand);
    }

    //手向上 
    public bool isMoveUp(Hand hand)
    {
        //print ("hand.PalmVelocity.y" + hand.PalmVelocity.y);

        return hand.PalmVelocity.y > deltaVelocity && !isStationary(hand);
    }

    //手向下  
    public bool isMoveDown(Hand hand)
    {
        return hand.PalmVelocity.y < -deltaVelocity && !isStationary(hand);
    }


    //手向前
    public bool isMoveForward(Hand hand)
    {
        //print (hand.PalmVelocity.z);
        return hand.PalmVelocity.z > deltaVelocity && !isStationary(hand);
    }

    //手向后 
    public bool isMoveBack(Hand hand)
    {
        return hand.PalmVelocity.z < -deltaVelocity && !isStationary(hand);
    }

    //固定不动的
    public bool isStationary(Hand hand)
    {
        return hand.PalmVelocity.Magnitude < smallestVelocity;      //Vector3.Magnitude返回向量的长度
    }
}
