﻿using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using Todo.Domain.Entities;

namespace Todo.Domain.Queries
{
   public static class TodoQueries
    {
        public static Expression<Func<TodoItem, bool>> GetAll(string user)
        {
            return x => x.User == user;
        }

        public static Expression<Func<TodoItem, bool>> GetAllDone(string user)
        {
            return x => x.User == user &&x.Done;
        }

        public static Expression<Func<TodoItem, bool>> GetAllUnDone(string user)
        {
            return x => x.User == user && x.Done==false;
        }

        public static Expression<Func<TodoItem, bool>> GetById(Guid id,string user)
        {
            return x => x.User == user
                       && x.Id==id;
        }


        public static Expression<Func<TodoItem, bool>> GetAByPeriod(string user,DateTime date, bool Done)
        {
            return x => x.User == user 
                       && x.Done == Done
                       && x.Date.Date==date.Date;
        }



    }
}
