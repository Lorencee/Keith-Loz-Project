
using UnityEngine;
using System.Collections;

public class AnimationMix : MonoBehaviour

{
    public Animation anim;
    public Transform shoulder;

    void Start()
    {
        // Add mixing transform
        anim["wave_hand"].AddMixingTransform(shoulder);
    }
}