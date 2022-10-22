using CustomProgram.Cards;
using CustomProgram.Lands;
using CustomProgram.views;
using SplashKitSDK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomProgram.Controller
{
    public class ButtonController
    {
        private int _state = 0;
        private static ButtonController instance = null;
        private GameMaster _gameMaster;
        private GUIController _guiController;


        private ButtonController(GameMaster gameMaster, GUIController guiController)
        {
            _gameMaster = gameMaster;
            _guiController = guiController;
        }
        public void SetHouseUp() // for unowned house only
        {
            _guiController.Level1 = new Button("Buy Level 1", Color.Blue, 345, 250, 50, 90, 10);
            _guiController.Level2 = new Button("Buy Level 2", Color.Blue, 495, 250, 50, 90, 10);
            _guiController.Level3 = new Button("Buy Level 3", Color.Blue, 645, 250, 50, 90, 10);
            _guiController.Level4 = new Button("Buy Level 4", Color.Blue, 795, 250, 50, 90, 10);
            _guiController.Level5 = new Button("Buy Level 5", Color.Blue, 570, 250, 50, 90, 10);

            _guiController.Level1Info = new BoxInfo(Color.Blue, 330, 150, 80, 120);
            _guiController.Level2Info = new BoxInfo(Color.Blue, 480, 150, 80, 120);
            _guiController.Level3Info = new BoxInfo(Color.Blue, 630, 150, 80, 120);
            _guiController.Level4Info = new BoxInfo(Color.Blue, 780, 150, 80, 120);
            _guiController.Level5Info = new BoxInfo(Color.Blue, 570, 150, 80, 120);
            CityLand currentCityLand = _gameMaster.Board.Lands[_gameMaster.CurrentPlayer.CurrentLandPosition] as CityLand;
            Player player = _gameMaster.CurrentPlayer;
            int currentLevel = currentCityLand.Level;
            switch (currentLevel)
            {
                case 1:
                    _guiController.Level1.IsVisible = false;
                    _guiController.Level1Info.IsVisible = false;
                    break;
                case 2:
                    _guiController.Level1.IsVisible = false;
                    _guiController.Level1Info.IsVisible = false;
                    _guiController.Level2.IsVisible = false;
                    _guiController.Level2Info.IsVisible = false;
                    break;
                case 3:
                    _guiController.Level1.IsVisible = false;
                    _guiController.Level1Info.IsVisible = false;
                    _guiController.Level2.IsVisible = false;
                    _guiController.Level2Info.IsVisible = false;
                    _guiController.Level3.IsVisible = false;
                    _guiController.Level3Info.IsVisible = false;
                    break;
                default:
                    break;
            }

            if (!player.CheckBudget(currentCityLand.BasePrice + currentCityLand.UpgradePrice * 4))
            {
                _guiController.Level4.IsVisible = false;
                _guiController.Level4Info.IsVisible = false;
            }
            if (!player.CheckBudget(currentCityLand.BasePrice + currentCityLand.UpgradePrice * 3))
            {
                _guiController.Level4.IsVisible = false;
                _guiController.Level4Info.IsVisible = false;
                _guiController.Level3.IsVisible = false;
                _guiController.Level3Info.IsVisible = false;
            }
            if (!player.CheckBudget(currentCityLand.BasePrice + currentCityLand.UpgradePrice * 2))
            {
                _guiController.Level4.IsVisible = false;
                _guiController.Level4Info.IsVisible = false;
                _guiController.Level3.IsVisible = false;
                _guiController.Level3Info.IsVisible = false;
                _guiController.Level2.IsVisible = false;
                _guiController.Level2Info.IsVisible = false;
            }
            if (!player.CheckBudget(currentCityLand.BasePrice))
            {
                _guiController.Level4.IsVisible = false;
                _guiController.Level4Info.IsVisible = false;
                _guiController.Level3.IsVisible = false;
                _guiController.Level3Info.IsVisible = false;
                _guiController.Level2.IsVisible = false;
                _guiController.Level2Info.IsVisible = false;
                _guiController.Level1.IsVisible = false;
                _guiController.Level1Info.IsVisible = false;
            }
            if (player.Round == 0)
            {
                _guiController.Level4.IsVisible = false;
                _guiController.Level4Info.IsVisible = false;
            }
            _guiController.Level1.Color = _gameMaster.CurrentPlayer.Color;
            _guiController.Level2.Color = _gameMaster.CurrentPlayer.Color;
            _guiController.Level3.Color = _gameMaster.CurrentPlayer.Color;
            _guiController.Level4.Color = _gameMaster.CurrentPlayer.Color;
            _guiController.Level5.Color = _gameMaster.CurrentPlayer.Color;


            _guiController.Level1Info.Infos = new List<string> { };
            _guiController.Level2Info.Infos = new List<string> { };
            _guiController.Level3Info.Infos = new List<string> { };
            _guiController.Level4Info.Infos = new List<string> { };
            _guiController.Level5Info.Infos = new List<string> { };

            _guiController.Level1Info.Color = _gameMaster.CurrentPlayer.Color;
            _guiController.Level1Info.AddInfo($"Level 1");
            _guiController.Level1Info.AddInfo($"Real price: {currentCityLand.BasePrice}");
            _guiController.Level1Info.AddInfo($"Renting price: {currentCityLand.LowLevelRentingPrice}");

            _guiController.Level2Info.Color = _gameMaster.CurrentPlayer.Color;

            _guiController.Level2Info.AddInfo($"Level 2");
            _guiController.Level2Info.AddInfo($"Real price: {currentCityLand.BasePrice + currentCityLand.UpgradePrice * 2}");
            _guiController.Level2Info.AddInfo($"Renting price: {currentCityLand.CommonLevelRentingPrice * 1}");

            _guiController.Level3Info.Color = _gameMaster.CurrentPlayer.Color;

            _guiController.Level3Info.AddInfo($"Level 3");
            _guiController.Level3Info.AddInfo($"Real price: {currentCityLand.BasePrice + currentCityLand.UpgradePrice * 3}");
            _guiController.Level3Info.AddInfo($"Renting price: {currentCityLand.CommonLevelRentingPrice * 2}");

            _guiController.Level4Info.Color = _gameMaster.CurrentPlayer.Color;

            _guiController.Level4Info.AddInfo($"Level 4");
            _guiController.Level4Info.AddInfo($"Real price: {currentCityLand.BasePrice + currentCityLand.UpgradePrice * 4}");
            _guiController.Level4Info.AddInfo($"Renting price: {currentCityLand.CommonLevelRentingPrice * 3}");

            _guiController.Level5Info.Color = _gameMaster.CurrentPlayer.Color;

            _guiController.Level5Info.AddInfo($"Level 5");
            _guiController.Level5Info.AddInfo($"Real price: {currentCityLand.BasePrice + currentCityLand.UpgradePrice * 4 + 150}");
            _guiController.Level5Info.AddInfo($"Renting price: {currentCityLand.CommonLevelRentingPrice * 4}");
        }
        public void SetCardUp()
        {
            _gameMaster.Card = _gameMaster.ChanceLandEffect();
            _guiController.DrawCard = new BoxInfo(_gameMaster.Card.Color, 570, 150, 80, 120);
            _guiController.DrawCard.AddInfo(_gameMaster.Card.Name);
        }
        public void DrawHouseInfo()
        {
            CityLand currentCityLand = _gameMaster.Board.Lands[_gameMaster.CurrentPlayer.CurrentLandPosition] as CityLand;
            if (currentCityLand.Level < 4)
            {
                _guiController.Level1.Draw();
                _guiController.Level2.Draw();
                _guiController.Level3.Draw();
                _guiController.Level4.Draw();

                _guiController.Level1Info.Draw();
                _guiController.Level2Info.Draw();
                _guiController.Level3Info.Draw();
                _guiController.Level4Info.Draw();
            }
            else
            {
                _guiController.Level5.Draw();
                _guiController.Level5Info.Draw();
            }
            _guiController.Cancel.Draw();
        }

        public void SetBeachUp()
        {
            CityLand currentCityLand = _gameMaster.Board.Lands[_gameMaster.CurrentPlayer.CurrentLandPosition] as CityLand;
            _guiController.Level1 = new Button("Buy Level 1", Color.Blue, 345, 250, 50, 90, 10);
            _guiController.Level1.Color = _gameMaster.CurrentPlayer.Color;
            _guiController.Level1Info = new BoxInfo(Color.Blue, 330, 150, 80, 120);

            _guiController.Level1Info.Color = _gameMaster.CurrentPlayer.Color;
            _guiController.Level1Info.AddInfo($"Real price: {currentCityLand.BasePrice}");
            _guiController.Level1Info.AddInfo($"Renting price: {currentCityLand.LowLevelRentingPrice}");
            if (currentCityLand.CurrentLandOwner != null)
            {
                _guiController.Level1.IsVisible = false;
                _guiController.Level1Info.IsVisible = false;
            }
        }
        public void DrawBeach()
        {
            _guiController.Level1Info.Draw();
            _guiController.Level1.Draw();
            _guiController.Cancel.Draw();
        }
        public void Draw()
        {
            Land land = _gameMaster.Board.Lands[_gameMaster.CurrentPlayer.CurrentLandPosition] as CityLand;
            switch (_state)
            {
                case 0:
                    _guiController.RollDiceButton.Draw();
                    break;
                case 1:
                    CityLand cityLand = _gameMaster.Board.Lands[_gameMaster.CurrentPlayer.CurrentLandPosition] as CityLand;
                    if (cityLand.CurrentLandOwner == null || _gameMaster.CurrentPlayer == cityLand.CurrentLandOwner)
                    {
                        if (cityLand.Level == 5)
                        {
                            _guiController.LeaveButton.Draw();
                        }
                        else
                        {
                            _guiController.BuyButton.Draw();
                            _guiController.LeaveButton.Draw();
                        }
                    }
                    else
                    {
                        _guiController.PayrentButton.Draw();
                    }
                    break;
                case 2:
                    SetHouseUp();
                    DrawHouseInfo();
                    break;
                case 3: // tax, chestLand, Prison
                    _guiController.ActivateButton.Draw();
                    break;
                case 4:
                    SetBeachUp();
                    DrawBeach();
                    break;
                case 5:
                    _guiController.ActivateButton.Draw();
                    break;
                case 6:
                    _guiController.LeaveButton.Draw();
                    break;
                case 7:
                    _guiController.ActivateButton.Draw();
                    break;
                case 8:
                    _guiController.LeaveButton.Draw();
                    break;
                case 9:
                    _guiController.DrawCardButton.Draw();
                    break;
                case 11:
                    _guiController.DrawCard.Draw();
                    _guiController.ActivateButton.Draw();
                    break;
                case 10:
                    _guiController.LeaveButton.Draw();
                    break;

            }
        }
        public void ClickHandle(double x, double y)
        {
            Point2D mouseLoc = new Point2D { X = x, Y = y };
            //Console.WriteLine(_state);
            switch (_state)
            {
                case 0: // case rolling
                    if (_guiController.RollDiceButton.IsAt(mouseLoc))
                    {
                        _gameMaster.RollingAction();
                        Land landCase0 = _gameMaster.Board.Lands[_gameMaster.CurrentPlayer.CurrentLandPosition];
                        if (_gameMaster.CheckLandType() == 1) // Purchasable
                        {
                            _state = 1;
                        }
                        else if (_gameMaster.CheckLandType() == 2)
                        {
                            _state = 3;  //tax, chest, prison
                        }
                        else if (_gameMaster.CheckLandType() == 4)
                        {
                            _state = 4; //buy beach
                        }
                        else if (_gameMaster.CheckLandType() == 5)
                        {
                            _state = 5; // WorldCup
                        }
                        else if (_gameMaster.CheckLandType() == 7)
                        {
                            _state = 7;
                        }
                        else if (_gameMaster.CheckLandType() == 9)
                        {
                            _state = 9;
                        }
                        else
                        {
                            _state = 10;
                        }
                    }
                    break;
                case 1: // diciding to buy
                    CityLand cityLandCase1 = _gameMaster.Board.Lands[_gameMaster.CurrentPlayer.CurrentLandPosition] as CityLand;
                    if (cityLandCase1.CurrentLandOwner == null)
                    {
                        if (_guiController.LeaveButton.IsAt(mouseLoc))
                        {
                            _gameMaster.EndRound();
                            _state = 0;
                            return;
                        }
                        else if (_guiController.BuyButton.IsAt(mouseLoc))
                        {
                            _state = 2;
                        }
                    }
                    else if (cityLandCase1.CurrentLandOwner == _gameMaster.CurrentPlayer) //Upgrade
                    {
                        if (cityLandCase1.Level == 5)
                        {
                            if (_guiController.LeaveButton.IsAt(mouseLoc))
                            {
                                _gameMaster.EndRound();
                                _state = 0;
                                return;
                            }
                        }
                        else
                        {
                            if (_guiController.LeaveButton.IsAt(mouseLoc))
                            {
                                _gameMaster.EndRound();
                                _state = 0;
                                return;

                            }
                            else if (_guiController.BuyButton.IsAt(mouseLoc))
                            {
                                SetHouseUp();
                                _state = 2;
                            }
                        }
                    }
                    else
                    {
                        _gameMaster.PayingRent();
                        _state = 0;
                        _gameMaster.EndRound();
                        return;
                    }
                    if (_guiController.LeaveButton.IsAt(mouseLoc))
                    {
                        _gameMaster.EndRound();
                        _state = 0;
                        return;
                    }
                    else if (_guiController.BuyButton.IsAt(mouseLoc))
                    {
                        SetHouseUp();
                        _state = 2;
                    }
                    break;
                case 2: //choose house to buy
                    CityLand cityLandCase2 = _gameMaster.Board.Lands[_gameMaster.CurrentPlayer.CurrentLandPosition] as CityLand;
                    if (_guiController.Cancel.IsAt(mouseLoc))
                    {
                        _gameMaster.EndRound();
                        _state = 0;
                        return;
                    }
                    if (cityLandCase2.Level < 4)
                    {
                        if (_guiController.Level1.IsAt(mouseLoc))
                        {
                            _gameMaster.BuyingHouse(1);
                            _gameMaster.EndRound();
                            _state = 0;
                            return;
                        }
                        else if (_guiController.Level2.IsAt(mouseLoc))
                        {
                            _gameMaster.BuyingHouse(2);
                            _gameMaster.EndRound();
                            _state = 0;
                            return;
                        }
                        else if (_guiController.Level3.IsAt(mouseLoc))
                        {
                            _gameMaster.BuyingHouse(3);
                            _gameMaster.EndRound();
                            _state = 0;
                            return;
                        }
                        else if (_guiController.Level4.IsAt(mouseLoc))
                        {
                            _gameMaster.BuyingHouse(4);
                            _gameMaster.EndRound();
                            _state = 0;
                            return;
                        }
                    }
                    else if (cityLandCase2.Level == 4)
                    {
                        if (_guiController.Level5.IsAt(mouseLoc))
                        {
                            _gameMaster.BuyingHouse(5);
                            _gameMaster.EndRound();
                            _state = 0;
                            return;
                        }
                    }
                    break;

                case 3: //tax, chest, prison
                    if (_guiController.ActivateButton.IsAt(mouseLoc))
                    {
                        _gameMaster.ActivateCurrentLandEffect();
                        _gameMaster.EndRound();
                        _state = 0;
                    }
                    break;
                case 4: // buy Beach
                    CityLand cityLandCase4 = _gameMaster.Board.Lands[_gameMaster.CurrentPlayer.CurrentLandPosition] as CityLand;
                    if (_guiController.Cancel.IsAt(mouseLoc))
                    {
                        _gameMaster.EndRound();
                        _state = 0;
                    }
                    else if (_guiController.Level1.IsAt(mouseLoc))
                    {
                        _gameMaster.BuyingHouse(1);
                        _gameMaster.EndRound();
                        _state = 0;
                        return;
                    }
                    break;
                case 5: // worldcup and airport
                    if (_gameMaster.CurrentPlayer.CityLands.Count == 0 && _gameMaster.Board.Lands[_gameMaster.CurrentPlayer.CurrentLandPosition].GetType() == typeof(WorldCupLand))
                    {
                        _state = 0;
                        return;
                    }
                    else
                    {
                        if (_guiController.ActivateButton.IsAt(mouseLoc))
                        {
                            _state = 6;
                        }
                    }
                    break;
                case 6: // worldcup and airport
                    if (_guiController.LeaveButton.IsAt(mouseLoc))
                    {
                        _gameMaster.EndRound();
                        _state = 0;
                        return;
                    }
                    if (_gameMaster.Board.Lands[_gameMaster.CurrentPlayer.CurrentLandPosition].GetType() == typeof(WorldCupLand))
                    {
                        int i = _guiController.BoardUI.CheckLandClick(mouseLoc);
                        if (i != 40)
                        {
                            Land land = _gameMaster.Board.Lands[i];
                            if (land.Purchasable)
                            {
                                CityLand cityLand = land as CityLand;
                                if (cityLand.CurrentLandOwner == _gameMaster.CurrentPlayer)
                                {
                                    _gameMaster.SetWorldCup(cityLand);
                                    _gameMaster.EndRound();
                                    _state = 0;
                                    return;
                                }
                            }
                        }
                    }
                    else if (_gameMaster.Board.Lands[_gameMaster.CurrentPlayer.CurrentLandPosition].GetType() == typeof(AirportLand))
                    {
                        int i = _guiController.BoardUI.CheckLandClick(mouseLoc);
                        if (i != 40)
                        {
                            Land land = _gameMaster.Board.Lands[i];
                            if (land.Purchasable)
                            {
                                CityLand cityLand = land as CityLand;
                                if (cityLand.CurrentLandOwner == _gameMaster.CurrentPlayer || cityLand.CurrentLandOwner == null)
                                {
                                    _gameMaster.AirportEffect(cityLand);
                                    _state = 1;
                                    return;
                                }
                            }
                        }
                    }
                    break;
                case 7:
                    if (_gameMaster.CurrentPlayer.CityLands.Count == 0)
                    {
                        _state = 0;
                        return;
                    }
                    else
                    {
                        if (_guiController.ActivateButton.IsAt(mouseLoc))
                        {
                            _state = 8;
                        }
                    }
                    break;
                case 8:
                    if (_guiController.LeaveButton.IsAt(mouseLoc))
                    {
                        _gameMaster.EndRound();
                        _state = 0;
                        return;
                    }
                    int ind = _guiController.BoardUI.CheckLandClick(mouseLoc);
                    if (ind != 40)
                    {
                        Land land = _gameMaster.Board.Lands[ind];
                        if (land.Purchasable)
                        {
                            CityLand cityLand = land as CityLand;
                            if (cityLand.CurrentLandOwner == _gameMaster.CurrentPlayer && cityLand.GetType() != typeof(BeachLand))
                            {
                                _gameMaster.CopyLand(cityLand);
                                _gameMaster.EndRound();
                                _state = 0;
                                return;
                            }
                        }
                    }
                    break;
                case 9:
                    if (_guiController.DrawCardButton.IsAt(mouseLoc))
                    {
                        SetCardUp();
                        _state = 11;
                    }
                    break;
                case 11:
                    if (_guiController.ActivateButton.IsAt(mouseLoc))
                    {
                        _gameMaster.Card.CreateEvent(_gameMaster.CurrentPlayer, _gameMaster);
                        _gameMaster.EndRound();
                        _state = 0;
                    }
                    break;
                case 10:
                    if (_guiController.LeaveButton.IsAt(mouseLoc))
                    {
                        _gameMaster.EndRound();
                        _state = 0;
                    }
                    break;

            }


        }
        public static ButtonController GetInstance(GameMaster gameMaster, GUIController guiController)
        {
            if (instance == null)
            {
                instance = new ButtonController(gameMaster, guiController);
            }
            return instance;
        }
    }
}
