using RDR2;
using RDR2.Native;
using RDR2.Math;
using RDR2.UI;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClassLibrary1
{
    public class Client : Script
    {
        Keys openMenuKey;
        RDR2.Control LKey;
        bool controls = false;
        public Client()
        {
            //openMenuKey = Settings.GetValue("Options", "LightningKey", Keys.J);
            int x = Settings.GetValue("Options", "ConorKey", 0);
            if(x == 0)
            {
                //controls = false;
                openMenuKey = Settings.GetValue("Options", "LightningKey", Keys.J);
            }
            else
            {
                //controls = true;
                LKey = Settings.GetValue("Options", "LightningKey", RDR2.Control.ScriptPadUp);
            }
            Tick += OnTick;
            Interval = 1;
            KeyDown += OnKeyDown;
        }

        private void OnTick(object sender, EventArgs evt)
        {
            RaycastResult pos = World.CrosshairRaycast(100000, IntersectOptions.Everything);
            Vector3 pos1 = pos.HitPosition;
            if (Game.IsControlJustPressed(2, LKey))
            {
                Function.Call((Hash)0x67943537D179597C, pos1.X, pos1.Y, pos1.Z);
            }
        }
        private void OnKeyDown(object sender, KeyEventArgs e)
        {
            RaycastResult pos = World.CrosshairRaycast(100000, IntersectOptions.Everything);
            Vector3 pos1 = pos.HitPosition;
            if (e.KeyCode == openMenuKey)
            {
                Function.Call((Hash)0x67943537D179597C, pos1.X, pos1.Y, pos1.Z);
            }
        }
    }
}
