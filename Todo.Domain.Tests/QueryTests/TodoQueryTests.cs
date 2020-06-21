using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Todo.Domain.Entities;
using Todo.Domain.Queries;

namespace Todo.Domain.Tests.QueryTests
{
    [TestClass]    
   public class TodoQueryTests
    {
       private readonly List<TodoItem> _items;

        public TodoQueryTests()
        {
            _items = new List<TodoItem>
            {
                new TodoItem("Tarefa 1", DateTime.Now, "Usuario A"),
                new TodoItem("Tarefa 1", DateTime.Now, "Usuario A"),
                new TodoItem("Tarefa 1", DateTime.Now, "Usuario A"),
                new TodoItem("Tarefa 1", DateTime.Now, "Jesuscl"),
                new TodoItem("Tarefa 1", DateTime.Now, "Usuario A")
            };
        }


        [TestMethod]
        public void Dada_a_Consulta_Deve_Retornar_Apenas_Tarefa_usuario()
        {
            int result = _items.AsQueryable().Where(TodoQueries.GetAll("Jesuscl")).Count();
            Assert.AreEqual(1, result);
        }
    }
}
