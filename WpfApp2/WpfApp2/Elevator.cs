using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp2
{
    class Elevator
    {
    public enum States
    {
        EmptyWaiting,
        EmptyClimbing,
        OpenDoorsWaiting
    }

    public event EventHandler<States> StateChanged;
    public event EventHandler<int> LevelChanged;
    public int Level { get; private set; }
    public int Level_nyg { get; private set; }
    public States State { get; private set; }

    public Elevator()
    {
        Level = 1;
        Level_nyg = 2;
    }

    public async Task GoTo(int level, int Level_nyg)
    {
        State = States.EmptyClimbing;
        StateChanged?.Invoke(this, this.State);
            if (level > Level_nyg)
            {
                for (int i = level; i >= Level_nyg; i--)
                {
                    await Task.Delay(1000);
                    Level = i;
                    LevelChanged?.Invoke(this, this.Level);
                }
            }
            else if (Level_nyg > level)
            {
                for (int i = level; i <= Level_nyg; i++)
                {
                    await Task.Delay(1000);
                    Level = i;
                    LevelChanged?.Invoke(this, this.Level);
                }
            }
            else if (Level_nyg == level)
            {
                LevelChanged?.Invoke(this, this.Level);
            }

        State = States.OpenDoorsWaiting;
        StateChanged?.Invoke(this, this.State);
    }
    }
}
