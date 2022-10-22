using SplashKitSDK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace CustomProgram.Lands
{
    public class CityLand : Land, ICloneable
    {
        private double _realPrice;
        private double _sellingPrice;
        protected double _lowLevelRentingPrice;
        protected double _commonLevelRentingPrice;
        protected double _upgradePrice;
        private int _level = 0;
        private bool _isWorldCup;
        private bool _isFestival;
        private Player _currentLandOwner;
        private double _rentingPrice;
        private double _basePrice;
        public int CloneID { get; set; }
        public CityLand(int id, string name, Color color, double realPrice, double upgradePrice, double lowLevelRentingPrice, double commonLevelRentingPrice): base(id, name,color)
        {
            this._currentLandOwner = null;
            this._realPrice = realPrice;
            this._sellingPrice = realPrice;
            this._upgradePrice = upgradePrice;
            this._lowLevelRentingPrice = lowLevelRentingPrice;
            this._commonLevelRentingPrice = commonLevelRentingPrice;
            this._rentingPrice = 0;
            this.Level = 0;
            this.Purchasable = true;
            this._isWorldCup = false;
            this._basePrice = realPrice;
            this.Description = "This is a property";
        }

        public bool UpgradeBuilding(int targetLevel)
        {
            double price = targetLevel * this.UpgradePrice;
            if (targetLevel == 1)
            {
                this.RealPrice = this.RealPrice + this.UpgradePrice * (targetLevel - this.Level);
                this.RentingPrice = this.RentingPrice = this.LowLevelRentingPrice;
                this.SellingPrice = this.RealPrice * 2;
                this.Level = targetLevel;
            }
            else if(targetLevel <=4)
            {
                this.RealPrice = this.RealPrice + this.UpgradePrice * (targetLevel - this.Level);
                this.RentingPrice = this.CommonLevelRentingPrice * (targetLevel - 1);
                this.SellingPrice = this.RealPrice * 2;
                this.Level = targetLevel;
            }
            else if(targetLevel == 5)
            {
                this.RealPrice = this.RealPrice + 150;
                this.SellingPrice = this.RealPrice * 2;
                this.RentingPrice = this.CommonLevelRentingPrice * (targetLevel - 1);
                this.Level = targetLevel;
            }
            else
            {
                return false;
            }
            return true;
        }
        public virtual void ChangeOwner(Player newOwner)
        {
            if(this.CurrentLandOwner != null)
            {
                this.CurrentLandOwner.RemoveLand(this);
            }
            this._currentLandOwner = newOwner;
            this.CurrentLandOwner.AddLand(this);
        }

        public bool IsWorldCup
        {
            get { return this._isWorldCup; }
            set { this._isWorldCup = value; }
        }

        public bool IsFestival
        {
            get { return this._isFestival; }
            set { this._isFestival = value; }
        }

        public double RentingPrice
        {
            get
            {
                if (IsWorldCup)
                {
                    return this._rentingPrice * 2;
                }
                return this._rentingPrice;
            }
            set
            {
                this._rentingPrice = value;
            }
        }

        public double SellingPrice
        {
            get
            {
                return this._sellingPrice;
            }
            set
            {
                this._sellingPrice = value;
            }
        }

        public double UpgradePrice
        {
            get
            {
                double ret = this.Level == 4 ? 150 : this._upgradePrice;
                return ret;
            }
            set
            {
                this._upgradePrice = value;
            }
        }

        public double LowLevelRentingPrice
        {
            get
            {
                return this._lowLevelRentingPrice;
            }
        }

        public double CommonLevelRentingPrice
        {
            get
            {
                return this._commonLevelRentingPrice;
            }
        }
        public double RealPrice
        {
            get
            {
                return this._realPrice;
            }
            set
            {
                this._realPrice = value;
            }
        }
        public int Level
        {
            get
            {
                return this._level;
            }
            set
            {
                this._level = value;
            }
        }

        public Player CurrentLandOwner
        {
            get
            {
                return this._currentLandOwner;
            }
            set
            {
                this._currentLandOwner = value;
            }
        }
        public void ReturnToDefault()
        {
            this.CurrentLandOwner = null;
            this.RealPrice = RealPrice - Level * _upgradePrice;
            this._rentingPrice = 0;
            this.Level = 0;
            this._isWorldCup = false;
        }

        public object Clone()
        {
            CityLand cityLand =  new CityLand(CloneID, "Clone", Color, this.RealPrice, this.UpgradePrice, this.LowLevelRentingPrice, this.CommonLevelRentingPrice);
            cityLand.Level = this.Level;
            cityLand.RentingPrice = this.RentingPrice;
            cityLand.RealPrice = this.RealPrice;
            this._isWorldCup = false;
            return cityLand;
        }

        public double BasePrice
        {
            get
            {
                return this._basePrice;
            }
            set
            {
                this._basePrice = value;
            }
        }
    }   
}
