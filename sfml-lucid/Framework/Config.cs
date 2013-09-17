using System;

using System.Configuration;

namespace Lucid.Framework
{
    /// <summary>
    /// Stub for now. Configuration file reader, exposes .cfg file as a 
    /// </summary>
    public static class Config
    {
        private static bool isInitialized = false;

        public static string Read(string key)
        {
            if (!isInitialized) throw new InvalidOperationException("Error: Can not read the config before it is initialized. Has Game.Run() been called yet?");
            if (!HasKey(key)) throw new ArgumentException("Error: Key is not in the configuration.", key);
            throw new NotImplementedException("ERROR: Can not read from configuration file. Not implemented.");
        }

        private static bool HasKey(string key)
        {
            return false;
        }
    }
}
