﻿using Modelos;

namespace Hotel.Interfaces
{
    public interface IFacturaServicio
    {
        Task<int> Nueva(Factura factura);
    }
}
