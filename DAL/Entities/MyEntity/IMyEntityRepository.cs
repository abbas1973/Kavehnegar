using Domain.Entities;
using DTO.Base;
using DTO.DataTable;
using DTO.MyEntity;
using Microsoft.AspNetCore.Http;

namespace DAL.Interface
{
    public interface IMyEntityRepository : IRepository<MyEntity>
    {

    }
}
