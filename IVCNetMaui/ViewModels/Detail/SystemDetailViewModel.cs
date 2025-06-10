using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IVCNetMaui.ViewModels.Detail
{
    internal class SystemDetailViewModel : ObservableObject
    {
        public ObservableCollection<Network> Items { get; } = new ObservableCollection<Network>
        {
            new Network
            {
                Name = "Ethernet",
                NIT = 6,
                Send = "87.00 Kbps",
                Receive = "125.45 Kbps",
                PktQd = 0
            }
        };
        public SystemDetailViewModel() { 
        
        }
        public class Network
        {
            public string Name { get; set; } = "";
            public int NIT { get; set; }
            public string Send { get; set; } = "";
            public string Receive { get; set; } = "";
            public int PktQd { get; set; }
        }
    }
}
