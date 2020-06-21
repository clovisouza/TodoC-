using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using Todo.Domain.Entities;

namespace Todo.Domain.Tests.EntityTestes
{
    [TestClass]
   public class TodoItemTestes
    {
        private readonly TodoItem todo = new TodoItem("Titulo", DateTime.Now, "jesuscl");

        [TestMethod]
        public void Dado_um_Novo_Todo_O_Mesmo_Nao_Pode_ser_Concluido()
        {
            var todo = new TodoItem("Titulo", DateTime.Now, "jesuscl");

            Assert.AreEqual(todo.Done,false);

        }
    }
}
