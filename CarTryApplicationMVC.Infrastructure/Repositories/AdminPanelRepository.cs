using CarTryApplicationMVC.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarTryApplicationMVC.Infrastructure.Repositories
{
    public class AdminPanelRepository : IAdminPanelRepository
    {

        private readonly Context _context;

        public AdminPanelRepository(Context context)
        {
            _context = context;
        }






    }
}
