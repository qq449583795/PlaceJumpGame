using QFramework;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UTGM
{
    public class ApplePlatformer2D : Architecture<ApplePlatformer2D>
    {
        // Start is called before the first frame update
        public static EasyEvent OnOpenBornFireUI = new EasyEvent();
        private static bool mIsGameOver;
        public static bool IsGameOver
        {
            get { return mIsGameOver; }
            set {
                if (value)
                {
                    HasContinueGame = false;
                }
                mIsGameOver = value; 
            }
        }
        public static bool HasContinueGame
        {
            get { return PlayerPrefs.GetInt(nameof(HasContinueGame),0)==1; }
            set
            {
                PlayerPrefs.SetInt(nameof(HasContinueGame), value ? 1 : 0);
            }
        }
        public static void ReSetGameData()
        {
            IsGameOver = false;
            HasContinueGame = true;

            foreach (IBornFireRule item in
                        ApplePlatformer2D.Interface.GetSystem<IBornFireSystem>().BornFireRuleList)
            {
                item.ReSet();
            }
            ApplePlatformer2D.Interface.GetModel<IPlayerModel>().HP = 1;
            ApplePlatformer2D.Interface.GetModel<IPlayerModel>().MaxHP = 1;
            ApplePlatformer2D.IsGameOver = false;
            BornFire.RemainingHealth = 60;
        }
        public static void ContinueGame()
        {
            var ruleList = ApplePlatformer2D.Interface.GetSystem<IBornFireSystem>().BornFireRuleList;
            ApplePlatformer2D.Interface.GetModel<IPlayerModel>().HP =PlayerPrefs.GetInt("HP");
            ApplePlatformer2D.Interface.GetModel<IPlayerModel>().MaxHP =PlayerPrefs.GetInt("MaxHP");
            BornFire.RemainingHealth = PlayerPrefs.GetFloat("RemainingHealth",0 );
            foreach (var item in ruleList)
            {
                item.Load();
            }
        }
        protected override void Init()
        {
            this.RegisterSystem<IBornFireSystem>(new BornFireSystem());
            this.RegisterModel<IPlayerModel>(new PlayerModel());
            GlobalMonoEvent.OnApplicationQuitEvent.Register(() =>
            {
                PlayerPrefs.SetInt(nameof(IsGameOver), IsGameOver?1:0);
                var ruleList =ApplePlatformer2D.Interface.GetSystem<IBornFireSystem>().BornFireRuleList;
                PlayerPrefs.SetInt("HP", ApplePlatformer2D.Interface.GetModel<IPlayerModel>().HP);
                PlayerPrefs.SetInt("MaxHP", ApplePlatformer2D.Interface.GetModel<IPlayerModel>().MaxHP);
                PlayerPrefs.SetFloat("RemainingHealth", BornFire.RemainingHealth);
                foreach (var item in ruleList)
                {
                    item.Save();
                }
            });
        }
    }
}

