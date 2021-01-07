﻿using Project.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Project.Core
{
    public interface IUnitOfWork : IDisposable
    {
        IMusicRepository Musics { get; }
        IArtistRepository Artists { get; }
        IProductRepository Products { get; }
        IProductGroupRepository  productGroups { get; }
        Task<int> CommitAsync();
    }
}
