using SplashKitSDK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomProgram.views
{
    public class DiceUI : IDraw
    {
        public static bool isVisible = false;

        private Bitmap[] _images = new Bitmap[6];
        private Bitmap _currentImage1;
        private Bitmap _currentImage2;
        public DiceUI()
        {
            for (int i = 0; i < 6; i++) _images[i] = new Bitmap("d" + (i+1), ".\\d" + (i + 1) + ".png");
            _currentImage1 = _images[1];
            _currentImage2 = _images[2];
        }
        public void Roll(int d1,int d2)
        {
            _currentImage1 = _images[d1-1];
            _currentImage2 = _images[d2-1];
        }
        public void Draw()
        {
            SplashKit.DrawBitmap(_currentImage1, 570, 400);
            SplashKit.DrawBitmap(_currentImage2, 620, 400);
        }
    }
}
