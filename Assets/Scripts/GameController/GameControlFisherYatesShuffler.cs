using System.Collections.Generic;
using UnityEngine;

public class GameControlFisherYatesShuffler {
    public List<T> ShuffleList<T>(List<T> list) {
        var resultList = list;
        
        for (var i = 0; i < resultList.Count; i++) {
            var randomIndex = Random.Range(i, list.Count);
            (resultList[i], resultList[randomIndex]) = (resultList[randomIndex], resultList[i]);
        }

        return resultList;
    }
}