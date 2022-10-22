using System;
using SplashKitSDK;
using CustomProgram.Lands;
using System.Collections.Generic;
using CustomProgram.views;
using CustomProgram.Controller;

namespace CustomProgram
{
    public class Program
    {
        public static void Main()
        {
            new Font("Roboto", ".\\Roboto-Regular.ttf");
            //UI
            GameMaster gameMaster = GameMaster.Instance;
            int numberOfPlayers = ConsoleInput.ConsoleInt("How many player are there?", 2, 4);
            //int numberOfPlayers = 4; // test
            for (int i = 0; i < numberOfPlayers; i++)
            {
                string playerName = ConsoleInput.ConsoleString("Name of the player?", 2, 10);
                Color color;
                string image;
                do
                {
                    int playerColor = ConsoleInput.ConsoleInt("Color of the player? \n-1-Red \n-2-Yellow \n-3-Blue \n-4-Green", 1, 4);

                    switch (playerColor)
                    {
                        case 1:
                            color = Color.Red;
                            image = ".\\Red.png";
                            break;
                        case 2:
                            color = Color.Yellow;
                            image = ".\\Yellow.png";
                            break;
                        case 3:
                            color = Color.Blue;
                            image = ".\\Blue.png";
                            break;
                        case 4:
                            color = Color.Green;
                            image = ".\\Green.png";
                            break;
                        default:
                            color = Color.Green;
                            image = ".\\Green.png";
                            break;
                    }
                } while (!gameMaster.CheckExistedColor(color));
                gameMaster.AddPlayer(new Player(playerName, color, image));

                //if (i == 0)
                //{
                //    gameMaster.AddPlayer(new Player("testPlayer1", Color.Red, ".\\Red.png"));
                //    //gameMaster.Players[gameMaster.Players.Count-1].SubstractMoney(2900);
                //}else if (i == 1)
                //{
                //    gameMaster.AddPlayer(new Player("testPlayer2", Color.Yellow, ".\\Yellow.png"));
                //    //gameMaster.Players[gameMaster.Players.Count - 1].SubstractMoney(2900);
                //}
                //else if (i == 2)
                //{
                //    gameMaster.AddPlayer(new Player("testPlayer3", Color.Blue, ".\\Blue.png"));
                //    //gameMaster.Players[gameMaster.Players.Count - 1].SubstractMoney(2900);
                //}
                //else
                //{
                //    gameMaster.AddPlayer(new Player("testPlayer4", Color.Green, ".\\Green.png"));
                //    //gameMaster.Players[gameMaster.Players.Count-1].SubstractMoney(2900);

                //}
            }

            foreach (Player player in gameMaster.Players)
            {
                Tuple<int,int> firstRoll = player.Dice();
                player.FirstRoll = firstRoll.Item1 + firstRoll.Item2;
            }
            gameMaster.Players.Sort((x, y) => y.FirstRoll.CompareTo(x.FirstRoll));
            Window window = new Window("Monopoly", 1200, 800);
            //window.ToggleFullscreen();
            GUIController guiController = GUIController.Instance;
            guiController.BoardUI = new BoardUI(190.0, 0, gameMaster.Board);
            guiController.AddHouse();



            gameMaster.CurrentPlayer = gameMaster.Players[0];
            gameMaster.GUIController = guiController;
            int turn = 0;
            int numberOfPlayer = gameMaster.Players.Count;
            int ind = 0;
            ButtonController buttonController = ButtonController.GetInstance(gameMaster, guiController);
            do
            {
                SplashKit.ClearScreen();
                //gui
                SplashKit.ProcessEvents();
                guiController.BoardUI.Draw();
                guiController.DiceUI.Draw();
                guiController.UpdateHouse();
                PlayerUI.drawPlayer(gameMaster);
                guiController.ShowTurn.Draw(gameMaster);
                
                buttonController.Draw();
                if (SplashKit.MouseClicked(MouseButton.LeftButton))
                {
                    buttonController.ClickHandle(SplashKit.MousePosition().X, SplashKit.MousePosition().Y);
                }
                if (gameMaster.WinningCondition() || gameMaster.Players.Count == 1)
                {
                    guiController.WinningUI.SetWinner(gameMaster.CurrentPlayer);
                    guiController.WinningUI.IsVisible = true;
                }
                guiController.WinningUI.Draw();
                SplashKit.RefreshScreen();
            } while (!window.CloseRequested);


        }
    }
}
