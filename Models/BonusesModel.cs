using System.Collections.Generic;
using Controllers;
using ExtinctionRunner.Interfaces;
using UnityEditorInternal.Profiling.Memory.Experimental;
using UnityEngine;

namespace ExtinctionRunner
{
    public class BonusesModel
    {
        //Healing bonus fields
        public PlayerHpController PlayerHpController;
        public float HealHp { get; set; }
        
        //Speed bonus fields
        public CoreController CoreController;
        public float SpeedBonus { get; set; }
        public float Timer { get; set; }
        public List<IExecutable> ListOFExecutables;
        
        //Volcano bonus fields
        public int ScoreBonus { get; set; }



        public BonusesModel(PlayerHpController playerHpController, float healHp, CoreController coreController, float speedBonus, float timer, List<IExecutable> listOfExecutables) //добавить остальные бонусы
        {
            //Healing bonus 
            PlayerHpController = playerHpController;
            HealHp = healHp;
            
            //Speed bonus
            CoreController = coreController;
            SpeedBonus = speedBonus;
            Timer = timer;
            ListOFExecutables = listOfExecutables;
        }

    }
}