using Lucy.Core;
using Lucy.Core.Contracts;
using Lucy.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lucy.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            // Initialize the container
            InitializeContainer();
            var bot = ObjectBuilder.Create<ICanChat>();
        }

        private static void InitializeContainer()
        {
            ObjectBuilder.Container = null;
            ObjectBuilder.Container
                         .Register<ICanChat, ChatBot>();

        }
    }
}
