using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Washer
{
    class Washer
    {
        #region Full Proberties
        //if the Washer dont have power its false.
        private bool power;
        //if the Washer dont have water its false.
        private bool water;
        //if the doorLock not are activated its false.
        private bool doorLock;
        //if the door is open its false.
        private bool doorOpen;
        //this is ued to select the speed of the drum.
        private byte drumSpeed;

        public bool Power
        {
            get { return power; }
            set { this.power = value; }
        }

        public bool Water
        {
            get { return water; }
            set { this.water = value; }
        }

        public bool DoorLock
        {
            get { return doorLock; }
            set { this.doorLock = value; }
        }

        public bool DoorOpen
        {
            get { return doorOpen; }
            set { this.doorOpen = value; }
        }

        public byte DrumSpeed
        {
            get { return drumSpeed; }
            set { this.drumSpeed = value; }
        }
        #endregion Full Proberties


        //constructor thats need power water doorlock dooropen and drumspeed before it can create a washer.
        #region Constructor
        public Washer(bool power, bool water, bool doorLock, bool doorOpen, byte drumSpeed)
        {
            this.power = power;
            this.water = water;
            this.doorLock = doorLock;
            this.doorOpen = doorOpen;
            this.drumSpeed = drumSpeed;
        }
        #endregion
    }
}
