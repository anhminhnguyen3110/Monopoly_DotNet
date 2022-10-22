using SplashKitSDK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomProgram.Lands
{
    public class SecretLand : ActivatedLand
    {
        private double _realPrice;
        private double _sellingPrice;
        private double _rentingPrice;
        private int _level;
        private bool _isWorldCup;
        private bool _isFestival;
        public Player _currentLandOwner;


        public SecretLand(int id, string name, Color color, double realPrice) : base(id,name, color)
        {
            this._currentLandOwner = null;
            this.ID = id;
            this._realPrice = realPrice;
            this.Purchasable = false;
            this.Description = "This land will have no effect or player will be lose random money";
        }

    }
}
