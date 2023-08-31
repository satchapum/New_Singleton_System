using PhEngine.Core;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SuperGame
{
    public class AchievementManager : Singleton<AchievementManager>
    {

        [SerializeField] List<Achievement> achievementsList = new List<Achievement>();
        public List<Achievement> AchievementsList => achievementsList;
        
        protected override void InitAfterAwake()
        {
            
        }

        public void AchievementComplete(string achievementGoal)
        {

            foreach(Achievement achievement in AchievementsList)
            {
                if (achievement.achievementGoal == achievementGoal)
                {
                    achievement.currentNumberCondition++;
                    if (achievement.currentNumberCondition == achievement.numberOfCondition)
                    {
                        Debug.Log("Pop-up achievement");
                        //pop-up_achievement_here
                    }
                }
            }
        }
    }
    [Serializable]
    public class Achievement
    {
        public string achievementGoal;
        public int numberOfCondition;
        public int currentNumberCondition;
    }
}

