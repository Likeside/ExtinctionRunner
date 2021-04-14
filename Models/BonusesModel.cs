using Controllers;
using UnityEditorInternal.Profiling.Memory.Experimental;

namespace ExtinctionRunner
{
    public class BonusesModel
    {
        //Healing bonus fields
        public PlayerHpController _playerHpController;
        public float HealHp { get; set; }
        
        //Speed bonus fields
        public CoreRotationSpeedController _coreRotationSpeedController;
        public float SpeedBonus { get; set; }
        
        //Volcano bonus fields
        public VolcanoBonusController _volcanoBonusController;
        public int AmountAdded { get; set; }



        public BonusesModel(PlayerHpController playerHpController, float healHp) //добавить остальные бонусы
        {
            _playerHpController = playerHpController;
            HealHp = healHp;
        }

    }
}