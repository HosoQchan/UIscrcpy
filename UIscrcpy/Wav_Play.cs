using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace UIscrcpy
{
    internal class Sound_Ctrl
    {
        static public System.Media.SoundPlayer Click = new System.Media.SoundPlayer(".\\Resources\\Sound\\Click.wav");

        static public void Initialize()
        {
            Click.Load();
        }

        static public void Stop(System.Media.SoundPlayer player)
        {
            if (player != null)
            {
                player.Stop();
                player.Dispose();
                player = null;
            }
        }

        static public void Play(System.Media.SoundPlayer player)
        {
            player.Play();
        }
    }
}
