﻿using WatchAPI.Datas.Models;
using WatchAPI.Datas.ViewModels;
using WatchAPI.Datas.ViewModels.Base;
using WatchAPI.Shared.Services;

namespace WatchAPI.Services
{
    public interface IProductService : IBaseService<Product, string>
    {
    }
}