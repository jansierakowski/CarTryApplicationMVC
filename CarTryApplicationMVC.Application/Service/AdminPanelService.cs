using AutoMapper;
using CarTryApplicationMVC.Application.Interfaces;
using CarTryApplicationMVC.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarTryApplicationMVC.Application.Service
{
    public class AdminPanelService : IAdminPanelService
    {

        private readonly IMapper _mapper;
        private readonly IAdminPanelRepository _adminPanelRepository;


        public AdminPanelService(IAdminPanelRepository adminPanelRepository, IMapper mapper)
        {
            _mapper = mapper;
            _adminPanelRepository = adminPanelRepository;
        }






    }
}
