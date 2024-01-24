using QFramework;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UTGM
{
    public class ApplePlatformer2D : Architecture<ApplePlatformer2D>
    {
        // Start is called before the first frame update
        protected override void Init()
        {
            this.RegisterSystem<IBornFireSystem>(new BornFireSystem());
            this.RegisterModel<IPlayerModel>(new PlayerModel());
        }
    }
}

