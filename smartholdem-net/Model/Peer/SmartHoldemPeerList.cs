﻿using SmartHoldemNet.Model.BaseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHoldemNet.Model.Peer
{
    public class SmartHoldemPeerList : SmartHoldemResponseBase
    {
        public List<SmartHoldemPeer> Peers { get; set; }
    }
}
