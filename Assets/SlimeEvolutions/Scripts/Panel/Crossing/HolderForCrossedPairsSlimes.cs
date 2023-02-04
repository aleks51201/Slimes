using UnityEngine;
using System.Collections.Generic;

namespace SlimeEvolutions.Panel.Crossing
{
    public class HolderForCrossedPairsSlimes : MonoBehaviour
    {
        [SerializeField] private List<HoldCrossingPlaceView> crossingPositions;

        public IReadOnlyCollection<HoldCrossingPlaceView> CrossingPositions => crossingPositions;
    }
}
