using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PoolOne
{
    public partial class HighScore
    {
        public string name;
        public int shots;
        public DateTime dateTime;

        public HighScore()
        {

        }

        public HighScore(string _name, int _shots, DateTime _dateTime)
        {
            name = _name;
            shots = _shots;
            dateTime = _dateTime;
        }

    }
}
