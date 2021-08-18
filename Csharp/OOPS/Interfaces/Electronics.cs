using System;

namespace IProgram2
{
    interface IElectronicDevice
    {
        void On();
        void Off();
        void VolumeUp();
        void VolumeDown();
    }

    interface ICommand
    {
        void Execute();
        void Undo();
    }
    
    class Television : IElectronicDevice {
        private int Volume { get; set; }
        private string Status { get; set; }
        public void On()
        {
            Status = "on";
            Console.WriteLine("tv is on");
        }

        public void Off()
        {
            Status = "off";
            Console.WriteLine("tv is off");
        }

        public void VolumeUp()
        {
            ++Volume;
            Console.WriteLine(Volume);
        }

        public void VolumeDown()
        {
            --Volume;
            Console.WriteLine(Volume);
        }
        
    }

    class PowerButton : ICommand
    {
        private IElectronicDevice device;

        public PowerButton(IElectronicDevice device)
        {
            this.device = device;
        }
        
        public void Execute()
        {
            device.On();
        }

        public void Undo()
        {
            device.Off();
        }
        
    }

    class TVRemote
    {
        public static IElectronicDevice GetDevice()
        {
            return new Television();
        }


    }
    
}