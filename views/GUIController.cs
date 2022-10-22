using CustomProgram.Lands;
using SplashKitSDK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomProgram.views
{
    public class GUIController
    {
        private static GUIController _instance;
        public DiceUI DiceUI { get; set; }
        public WinningUI WinningUI { get; set; }
        public ShowTurn ShowTurn { get; set; }
        public DrawBuilding[] DrawBuildings { get; set; }
        public GameMaster GameMaster { get; set; }
        public Button RollDiceButton { get; set; }
        public Button MoveButton { get; set; }

        public Button BuyButton { get; set; }
        public Button LeaveButton { get; set; }
        public Button PayrentButton { get; set; }

        public Button ActivateButton { get; set; }
        public Button Level1 { get; set; }
        public Button Level2 { get; set; }
        public Button Level3 { get; set; }
        public Button Level4 { get; set; }
        public Button Level5 { get; set; }

        public Button Cancel { get; set; }
        public Button DrawCardButton { get; set; }

        public BoxInfo Level1Info { get; set; }
        public BoxInfo Level2Info { get; set; }
        public BoxInfo Level3Info { get; set; }
        public BoxInfo Level4Info { get; set; }
        public BoxInfo Level5Info { get; set; }
        public BoxInfo DrawCard { get; set; }
        public BoardUI BoardUI { get; set; }
        private GUIController()
        {
            DiceUI = new DiceUI();
            WinningUI = new WinningUI();
            ShowTurn = new ShowTurn();
            DrawBuildings = new DrawBuilding[36];

            RollDiceButton = new Button("Roll!", Color.Green, 570, 500, 50, 80, 20);
            MoveButton = new Button("Move!", Color.Red, 570, 500, 50, 80, 20);
            BuyButton = new Button("Buy!", Color.Green, 520, 500, 50, 80, 20);
            LeaveButton = new Button("Leave!", Color.Red, 620, 500, 50, 80, 20);
            PayrentButton = new Button("Payrent!", Color.Black, 550, 500, 50, 120, 20);
            DrawCardButton = new Button("DrawCard!", Color.Black, 550, 500, 50, 130, 20);
            ActivateButton = new Button("Activate!", Color.Black, 550, 500, 50, 120, 20);
            Cancel = new Button("Cancel", Color.Red, 570, 330, 50, 90, 15);
        }
        public static GUIController Instance
        {
            get
            {
                if(_instance == null)
                {
                    _instance = new GUIController();
                }
                return _instance;
            }
        }

        public void AddHouse()
        {
            int i = 0;
            foreach (Land land in BoardUI.Board.Lands)
            {
                double[] ret = BoardUI.GetCenter(land.ID);
                DrawBuildings[i] = new DrawBuilding(Color.Black, ret[0], ret[1]);
                i += 1;
            }
        }

        public void UpdateHouse()
        {
            int i = 0;
            foreach (Land land in BoardUI.Board.Lands)
            {
                if (land.Purchasable == true)
                {
                    CityLand cityLand = land as CityLand;
                    if (cityLand.CurrentLandOwner != null)
                    {
                        DrawBuildings[i].CityLand = cityLand;
                        DrawBuildings[i].Color = cityLand.CurrentLandOwner.Color;
                        DrawBuildings[i].Draw();
                    }
                }
                i += 1;
            }
        }
    }
}
