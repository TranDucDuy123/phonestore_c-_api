﻿using WatchAPI.Datas.Models;
using WatchAPI.Datas.ViewModels;
using WatchAPI.Datas.ViewModels.Base;
using WatchAPI.Shared.Repositories;

namespace WatchAPI.Repositories
{
    public interface IOrderRepo : IBaseRepository<Order, string>
    {
    }
}