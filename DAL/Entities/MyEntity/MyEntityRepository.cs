using DAL.Interface;
using Domain.Entities;
using DTO.DataTable;
using DTO.MyEntity;
using LinqKit;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Text;
using Utilities.Extentions;

namespace DAL
{
    public class MyEntityRepository : Repository<MyEntity>, IMyEntityRepository
    {
        public MyEntityRepository(DbContext _Context) : base(_Context)
        {
        }



    }
}
