using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class HaulerInputHandler : MonoBehaviour
{
    public float inputDelaySeconds = 0.025f;
    
    // Input tracking
    private float _timer;
    private float _lastMovementTime;
    private float _lastActionTime;
    private bool _releasedKey = true;

}
