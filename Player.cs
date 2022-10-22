using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CustomProgram.PlayerStateDesign;
using SplashKitSDK;
using CustomProgram.Lands;
using CustomProgram.Command;

namespace CustomProgram
{
    public class Player
    {
        public int Round { get; set; }
        public Tuple<int, int> DiceResult { get; set; }
        private RollingDice _dice;
        private int _currentLandPosition;
        private string _name;
        private double _money;
        private PlayerState _currentState;
        private int _firstRoll;
        private FreeState _freeState;
        private JailedState _jailedState;
        private StunnedState _stunnedState;
        private Color _color;
        private List<CityLand> _cityLands;
        private List<BeachLand> _beachObservers;
        private string _image;
        public int DoubleDice { get; set; }
        public bool ContinueRoll { get; set; }
        public PlayerState FreeState
        {
            get
            {
                return _freeState;
            }
        }
        public PlayerState JailedState
        {
            get
            {
                return _jailedState;
            }
        }
        
        public List<BeachLand> BeachObservers
        {
            get
            {
                return this._beachObservers;
            }
        }
        public PlayerState StunnedState
        {
            get
            {
                return _stunnedState;
            }
        }

        public int FirstRoll
        {
            get
            {
                return this._firstRoll;
            }
            set
            {
                this._firstRoll = value;
            }
        }

        public Player(string name, Color color, string image)
        {
            _name = name;
            _money = 3000;
            _dice = new RollingDice();
            _currentLandPosition = 0;
            _image = image;
            _freeState = new FreeState();
            _jailedState = new JailedState();
            _stunnedState = new StunnedState();
            _beachObservers = new List<BeachLand>();
            _currentState = _freeState;
            this._color = color;
            this.CityLands = new List<CityLand> { };
            ContinueRoll = false;
            Round = 0;
        }

        public String Image
        {
            get
            {
                return this._image;
            }
        }
        public Color Color
        {
            get
            {
                return this._color;
            }
            set
            {
                this._color = value;
            }
        }
        public void AddMoney(double value)
        {
            this._money += value;
        }
        public void SubstractMoney(double value)
        {
            this._money -= value;
        }
        public double Money
        {
            get { return _money; }
        }
        public string Name 
        { 
            get
            {
                return _name;
            }
            set 
            {
                _name = value;
            }
        }
        public int CurrentLandPosition
        {
            get
            {
                return _currentLandPosition % 40;
            }
            set
            {
                _currentLandPosition = value;
            }
        }

        public PlayerState GetState()
        {
            return _currentState;
        }

        public void SetState(PlayerState newState)
        {
            _currentState = newState;
        }

        public void Move(int dice)
        {
            _currentState.Move(this, dice);
        }
        
        public Tuple<int,int> Dice()
        {
            _currentState.Dice(this, _dice);
            return this.DiceResult;
        }
        public void Invoker(GameCommand command)
        {
            command.execute();
        }
        public void AddLand(CityLand cityLand)
        {
            this.CityLands.Add(cityLand);
        }
        public void RemoveLand(CityLand cityLand)
        {
            this.CityLands.Remove(cityLand);
            if(cityLand.GetType() == typeof(BeachLand))
            {
                this.RemoveObserver(cityLand as BeachLand);
            }
            cityLand.ReturnToDefault();
        }
        public double UpdateTotalMoney()
        {
            double total = 0;
            total += Money;
            foreach(CityLand cityLand in CityLands)
            {
                total += cityLand.RealPrice;
            }
            return total;
        }
        public List<CityLand> CityLands
        {
            get
            {
                return this._cityLands;
            }
            set
            {
                this._cityLands = value;
            }
        }
        public void killedBy(Player player)
        {
            if(player!=null) player.AddMoney(UpdateTotalMoney());
            this._money = 0;
            foreach(CityLand cityLand in CityLands)
            {
                cityLand.ReturnToDefault();
            }
        }

        public bool CheckBudget(double price)
        {
            if (this.Money >= price)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void AddObserver(BeachLand beachLand)
        {
            this._beachObservers.Add(beachLand);
            foreach(BeachLand beach in this._beachObservers)
            {
                beach.Notify(_beachObservers.Count());
            }
        }

        public void RemoveObserver(BeachLand beachLand)
        {
            this._beachObservers.Remove(beachLand);
            foreach(BeachLand beach in this._beachObservers)
            {
                beach.Notify(_beachObservers.Count());
            }
        }
    }
}
