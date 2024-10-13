using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameControlType : MonoBehaviour {
    public enum TrainType {
        PASSENGER,
        CARGO,
        DANGEROUS_CARGO
    }

    public enum TrainStatus {
        GO,
        WARNING,
        STOP
    }
}