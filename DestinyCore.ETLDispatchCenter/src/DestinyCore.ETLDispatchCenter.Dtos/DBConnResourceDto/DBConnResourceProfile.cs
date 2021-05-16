using AutoMapper;
using DestinyCore.ETLDispatchCenter.Domain.Models.DBConnResource;
using System;
using System.Collections.Generic;
using System.Text;

namespace DestinyCore.ETLDispatchCenter.Dtos.DBConnResourceDto
{
    public class DBConnResourceProfile : Profile
    {
        public DBConnResourceProfile()
        {
            CreateMap<DBConnResourceInputDto, DBConnection>().ConstructUsing(x => new DBConnection(x.ConnectionName, x.Memo, x.Host, x.Port, x.UserName, x.PassWord, x.DBType, x.MaxConnSize, x.DataBase));

        }
    }
}
