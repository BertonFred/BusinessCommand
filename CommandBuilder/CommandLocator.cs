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
            Commandes = new Dictionary<Type, CommandDefintion>();
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

            Commandes.Add(cdeDef.CommandType, cdeDef);
        }

        public static void Register(Type _Type)
        {
            CommandDefintion cdeDef = new CommandDefintion()
            {
                CommandType = _Type,
                IsSingleton = false,
                SingletonInstance = null
            };

            Commandes.Add(cdeDef.CommandType, cdeDef);
        }

        public static IBusinessCommand Resolve<T>()
            where T : IBusinessCommand, new()
        {
            CommandDefintion cdeDef = Commandes[typeof(T)];
            T Instance = default(T);

            if (cdeDef.IsSingleton == true)
            {
                if (cdeDef.SingletonInstance == null)
                    cdeDef.SingletonInstance = new T();

                Instance = (T) cdeDef.SingletonInstance;
            }
            else 
            {
                Instance = new T();
            }

            return Instance;
        }
        public static IBusinessCommand Resolve<T>(Object _CommandRequest)
            where T : IBusinessCommand, new()
        {
            var Instance = Resolve<T>();
            Instance.CommandRequest = _CommandRequest;
            return Instance;
        }

        private static Dictionary<Type,CommandDefintion> Commandes { get; set; }
    }

    public class CommandDefintion
    {
        public Type CommandType { get; set; }
        public bool IsSingleton { get; set; }
        public IBusinessCommand SingletonInstance { get; set; }
    }
}