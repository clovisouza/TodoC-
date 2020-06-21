using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using Todo.Domain.Commands;

namespace Todo.Domain.Tests.CommandsTestes
{
    [TestClass]
   public class CreateTodoCommandTestes
    {
        private readonly CreateTodoCommand _validCommand = new CreateTodoCommand("Titulo", "JesusCl", DateTime.Now);
        private readonly CreateTodoCommand _invalidCommand = new CreateTodoCommand("", "", DateTime.Now);

        public CreateTodoCommandTestes()
        {
            //_validCommand.Validate();
            //_invalidCommand.Validate();

        }

        [TestMethod]
        public void Dado_Um_Commando_Invalido()
        {            
            Assert.AreEqual(_invalidCommand.Invalid, false);
        }

        [TestMethod]
        public void Dado_Um_Commando_Valido()
        {
            
            Assert.AreEqual(_validCommand.Valid, true);
        }

    }
}
