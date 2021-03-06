using System;
using System.Collections.Generic;
using UnityEngine;

namespace ExtinctionRunner.Models
{
    public enum Track
        {
            Idle,
            Walk,
            Jump,
            HealthBonusIdle,
            SpeedBonusIdle,
            VolcanoBonusIdle,
            HealingCollected,
            SpeedCollected,
            VolcanoCollected,
            IdlePredator,
            WalkPredator,
            JumpPredator
        }

        [CreateAssetMenu(fileName = "SpriteAnimationsModelSO", menuName = "Configs/SpriteAnimationsModelSO", order = 1)]
        public class AnimationModelSO : ScriptableObject
        {
            [Serializable]
            public class SpritesSequence
            {
                public Track Track;
                public List<Sprite> Sprites = new List<Sprite>();
            }

            public List<SpritesSequence> Sequences = new List<SpritesSequence>();

        }
}
