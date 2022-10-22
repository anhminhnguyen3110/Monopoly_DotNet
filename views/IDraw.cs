using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomProgram.views
{
    public interface IDraw
    {
        public virtual void Draw() { }
        public virtual void Draw(Board board) { }
        public virtual void Draw(int[] dice) { }
    }
}
