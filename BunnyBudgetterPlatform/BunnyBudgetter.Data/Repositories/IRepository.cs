﻿using BunnyBudgetterPlatform.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BunnyBudgetter.Data.Repositories
{
    public interface IRepository
    {
        Task AddEntity<T>(T entity) where T : class;

        Task<T> GetEntityById<T>(int id) where T : class;

        IQueryable<T> GetAll<T>() where T : class;

        IQueryable<T> GetAllWhere<T>(Expression<Func<T, bool>> qry) where T : class;

        //IQueryable<T> GetAllWhereWithIncludes<T>(Expression<Func<T, bool>> qry, Expression<Func<T, object[]>> includes) where T : class;
    }
}
