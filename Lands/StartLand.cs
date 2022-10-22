using SplashKitSDK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace CustomProgram.Lands
{
    public class StartLand : Land
    {
        public StartLand(int id, string name, Color color):base(id,name,color)
        {
            this.Purchasable = false;
            this.Description = "This land will be the start of the game";
        }
    }
}
