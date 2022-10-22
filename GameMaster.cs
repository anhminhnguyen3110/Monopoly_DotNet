using CustomProgram.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SplashKitSDK;
using CustomProgram.views;
using CustomProgram.Lands;
using CustomProgram.Cards;

namespace CustomProgram
{
    public class GameMaster
    {
        private static GameMaster _instance = null;
        private Board _board;
        public List<Player> Players { get; set; }

        public Card Card { get; set; }
        public Player CurrentPlayer { get; set; }
        public GUIController GUIController { get; set; }
        private CardFactory _cardFactory;
        private GameMaster()
        {
            Players = new List<Player>();
            _board = Board.GetInstance();
            _board.CreateBoard();
            this._cardFactory = new CardFactory();
        }

        public static GameMaster Instance
        {
            get
            {
                if (_instance == null)
                {
                    return new GameMaster();
                }
                return _instance;
            }
        }
        public Board Board
        {
            get
            {
                return this._board;
            }
        }

        public void AddPlayer(Player player)
        {
            this.Players.Add(player);
        }


        public bool CheckExistedColor(Color color)
        {
            foreach (Player player in Players)
            {
                if (player.Color.Equals(color))
                {
                    return false;
                }
            }
            return true;
        }
        public int GetCurrentPlayerIndex()
        {
            return Players.IndexOf(CurrentPlayer);
        }

        public void EndTurn()
        {
            this.CurrentPlayer.DoubleDice = 0;
            this.CurrentPlayer.ContinueRoll = false;
            this.CurrentPlayer = this.Players[(this.GetCurrentPlayerIndex() + 1) % (this.Players.Count)];
        }

        public void EndRound()
        {
            if (this.CurrentPlayer.ContinueRoll == true)
            {
                this.CurrentPlayer.ContinueRoll = false;
                return;
            }
            this.CurrentPlayer.DoubleDice = 0;
            this.CurrentPlayer = this.Players[(this.GetCurrentPlayerIndex() + 1) % (this.Players.Count)];
        }
        public bool WinningCondition()
        {
            List<Player> eliminatedPlayers = new List<Player>();
            foreach(Player player in Players)
            {
                if(player.UpdateTotalMoney() < 0)
                {

                    Console.WriteLine("Check");
                    eliminatedPlayers.Add(player);
                }
            }
            foreach (Player p in eliminatedPlayers)
            {
                this.Players.Remove(p);
            }
            return false;
        }
        
        public void ActivateCurrentLandEffect()
        {
            ActivatedLand activatedLand = this.Board.Lands[this.CurrentPlayer.CurrentLandPosition] as ActivatedLand;
            activatedLand.CreateEvent(this.CurrentPlayer);
        }

        public void RollingAction()
        {
            if (CurrentPlayer == null)
            {
                Console.WriteLine($"No one do turn");
                return;
            }
            Console.WriteLine($"{this.CurrentPlayer.Name} do turn");


            Player player = CurrentPlayer;
            Tuple<int, int> dice = player.Dice();
            GUIController.DiceUI.Roll(dice.Item1, dice.Item2);
            
            //dice = new Tuple<int, int> (3, 1);

            player.Move(dice.Item1 + dice.Item2);

        }

        public void AirportEffect(CityLand cityLand)
        {
            if(this.CurrentPlayer.CurrentLandPosition > cityLand.ID)
            {
                this.CurrentPlayer.Round += 1;
                this.CurrentPlayer.AddMoney(300);
            }
            this.CurrentPlayer.CurrentLandPosition = cityLand.ID;

        }
        public void Invoker(GameCommand command)
        {
            command.execute();
        }
        public void SetWorldCup(CityLand cityLand)
        {
            this.Invoker(new WorldCupCommand(cityLand, this));
        }
        public bool CheckCurrentPlayerBudget(double price)
        {
            Player player = CurrentPlayer;
            if (player.CheckBudget(price))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public int CheckLandType()
        {
            Land land = this.Board.Lands[this.CurrentPlayer.CurrentLandPosition];
            if (land.GetType() == typeof(BeachLand))
            {
                BeachLand beachLand = land as BeachLand;
                if (beachLand.CurrentLandOwner == null)
                {
                    return 4;
                }
                else if(beachLand.CurrentLandOwner != CurrentPlayer)
                {
                    return 1;
                }
            }
            if (land.Purchasable == true)
            {
                return 1;
            }
            else if(land.GetType() == typeof(ChanceLand))
            {
                return 9;
            }
            else if (land.Optional == false)
            {
                return 2;
            }else if(land.Optional == true && (land.GetType() == typeof(WorldCupLand) || land.GetType() == typeof(AirportLand)))
            {
                return 5;
            }else if(land.GetType() == typeof(SecretLand))
            {
                return 7;
            }
            else
            {
                return 10;
            }
            return 10;
        }
        public Card ChanceLandEffect()
        {
            Player player = this.CurrentPlayer;
            Card card = this._cardFactory.CreateCard();
            return card;
        }
        public void CopyLand(CityLand land)
        {
            land.CloneID = this.CurrentPlayer.CurrentLandPosition;
            CityLand cityLand = land.Clone() as CityLand;
            this.Board.Lands[this.CurrentPlayer.CurrentLandPosition] = cityLand;
            cityLand.ChangeOwner(this.CurrentPlayer);
        }
        public void BuyingHouse(int level)
        {
            Player player = this.CurrentPlayer;
            player.Invoker(new PurchaseBuildingCommand(player, this.Board.Lands[player.CurrentLandPosition] as CityLand, level));
        }

        public void PayingRent()
        {
            Player player = this.CurrentPlayer;
            player.Invoker(new PayRentCommand(player, this.Board.Lands[player.CurrentLandPosition] as CityLand));

        }
    }
}
