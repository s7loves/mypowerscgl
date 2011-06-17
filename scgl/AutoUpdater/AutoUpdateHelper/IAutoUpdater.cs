
using System;
using System.Collections.Generic;
using System.Text;

namespace EbadaAutoupdater
{
    public interface IAutoUpdater
    {
        void Update();

        void RollBack();
    }
}
