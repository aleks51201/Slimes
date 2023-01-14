using UnityEngine;
using System.Collections.Generic;
using SlimeEvolutions.SO;

namespace SlimeEvolutions.Panel.Crossing
{
    public class HolderForCrossedPairsSlimes : MonoBehaviour
    {
        [SerializeField] private List<HoldCrossingPlaceView> crossingPositions;

        public IReadOnlyCollection<HoldCrossingPlaceView> CrossingPositions => crossingPositions;
    }
}
