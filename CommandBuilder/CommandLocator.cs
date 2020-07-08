using Commande.BusinessCommand;
using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace Commande
{
    public class CommandLocator
    {
        static CommandLocator()
        {
            Commandes = new Dictionary<string, CommandDefintion>();
        }

        public static void Register(string CommandName,IBusinessCommand Command)
        {
            CommandDefintion cdeDef = new CommandDefintion()
            {
                CommandType = Command.GetType(),
                IsSingleton = true,
                SingletonInstance = Command
            };

            Commandes.Add(CommandName, cdeDef);
        }

        public static void Register<T>()
            where T : IBusinessCommand
        {
            CommandDefintion cdeDef = new CommandDefintion()
            {
                CommandType = typeof(T),
                IsSingleton = false,
                SingletonInstance = null
            };

            Commandes.Add(typeof(T).ToString(), cdeDef);
        }

        public static void Register(Type _Type)
        {
            CommandDefintion cdeDef = new CommandDefintion()
            {
                CommandType = _Type,
                IsSingleton = false,
                SingletonInstance = null
            };

            Commandes.Add(_Type.ToString(), cdeDef);
        }

        public static IBusinessCommand Resolve(string CommandName)
        {
            CommandDefintion cdeDef = Commandes[CommandName];
            return cdeDef.SingletonInstance;
        }

        public static IBusinessCommand Resolve<T>()
            where T : IBusinessCommand
        {
            return Resolve(typeof(T).ToString());
        }

        public static IBusinessCommand Resolve<T>(Object _CommandRequest)
            where T : IBusinessCommand, new()
        {
            var Instance = Resolve<T>();
            Instance.CommandRequest = _CommandRequest;
            return Instance;
        }

        private static Dictionary<string,CommandDefintion> Commandes { get; set; }
    }

    public class CommandDefintion
    {
        public Type CommandType { get; set; }
        public bool IsSingleton { get; set; }
        public IBusinessCommand SingletonInstance { get; set; }
    }
}