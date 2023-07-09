using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity.Netcode;
using UnityEngine;

namespace Assets.Scripts.Models
{
    public abstract class TestButtonNetworkBehavior : NetworkBehaviour
    {
        public abstract void OnTestClick();
        public abstract void OnTest2Click();
    }
}
