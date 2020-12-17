using Project.Core;
using Project.Core.Repositories;
using Project.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Project.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly MyDbContext _context;
        private MusicRepository _musicRepository;
        private ArtistRepository _artistRepository;
        private Prdo

        public UnitOfWork(MyDbContext context)
        {
            this._context = context;
        }

        public IArtistRepository Artists => _artistRepository = _artistRepository ?? new ArtistRepository(_context);

        public IMusicRepository Musics => _musicRepository = _musicRepository ?? new MusicRepository(_context);

        public IArtistRepository Products => _

        public async Task<int> CommitAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
