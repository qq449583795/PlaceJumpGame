using QFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UTGM
{
    public interface  IPlayerModel:IModel
    {
        int HP { get; set; }
        int MaxHP { get; set; }
    }
    public class PlayerModel : AbstractModel, IPlayerModel
    {
        public int HP { get; set; } = 1;
        public int MaxHP { get; set; } = 1;

        protected override void OnInit()
        {
            
        }
    }


}
