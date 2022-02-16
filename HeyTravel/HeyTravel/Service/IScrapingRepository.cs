﻿using HeyTravel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HeyTravel.Service
{
    public interface IScrapingRepository
    {
        Task<Casi> DataCovid(string stato);
        Task<GeoJson> Mappa();
    }
}
