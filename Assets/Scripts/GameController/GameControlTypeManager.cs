using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameControlTypeManager : MonoBehaviour {
    public enum vehicleType {
        TRAIN_PASSENGER,
        TRAIN_FREIGHT,
        TRAIN_DANGEROUS
    }

    public enum TrafficStatus {
        MOVE,
        STOP,
        IDLE
    }
}