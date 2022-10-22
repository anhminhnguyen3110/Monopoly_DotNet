using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SplashKitSDK;
using System.Threading.Tasks;
namespace CustomProgram.Lands
{
    public abstract class Land
    {
        protected string _name;
        private Color _color;
        protected bool _optional;
        protected int _id;
        public string Description { get; set; }
        public bool Purchasable { get; set; }
        public Land(int id, string name, Color color)
        {
            _id = id;
            Name = name;
            Color = color;
            this._optional = true;
            this.Purchasable = true;
        }

        public int ID
        {
            get
            {
                return this._id;
            }
            set
            {
                this._id = value;
            }
        }

        public Color Color
        {
            get
            {
                return _color;
            }
            set
            {
                _color = value;
            }
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


        public bool Optional
        {
            get
            {
                return (_optional);
            }
        }
    }
}
