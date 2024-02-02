using QFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UTGM
{
    public interface  IBornFireSystem : ISystem
    {
        List<IBornFireRule> BornFireRuleList { get; }
        IBornFireRule GetRulByKey(string key);
    }
    public class BornFireSystem : AbstractSystem,IBornFireSystem
    {
        public List<IBornFireRule> BornFireRuleList { get; } = new List<IBornFireRule>();

        public IBornFireRule GetRulByKey(string key)
        {
            foreach (IBornFireRule rule in BornFireRuleList)
            {
                if (rule.Key == key)
                {
                    return rule;
                }
            }
            return null;
        }

        protected override void OnInit()
        {
            BornFireRuleList.Add(new HPBar());
            BornFireRuleList.Add(new MaxHpPlus1());
            BornFireRuleList.Add(new ReBornEnemy());
        }
    }
}
