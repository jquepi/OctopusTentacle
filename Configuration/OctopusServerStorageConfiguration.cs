using System;
using System.IO;
using System.Security.Cryptography;
using Octopus.Platform.Deployment.Configuration;

namespace Octopus.Shared.Configuration
{
    public class OctopusServerStorageConfiguration : IOctopusServerStorageConfiguration
    {
        readonly IKeyValueStore settings;
        readonly IHomeConfiguration home;

        public OctopusServerStorageConfiguration(IKeyValueStore settings, IHomeConfiguration home)
        {
            this.settings = settings;
            this.home = home;
        }

        public string ExternalDatabaseConnectionString
        {
            get { return settings.Get("Octopus.Storage.ExternalDatabaseConnectionString"); }
            set { settings.Set("Octopus.Storage.ExternalDatabaseConnectionString", value); }
        }

        public bool BackupsEnabledByDefault
        {
            get { return settings.Get("Octopus.Storage.BackupsEnabledByDefault", true); }
            set { settings.Set("Octopus.Storage.BackupsEnabledByDefault", value); }
        }

        public StorageMode StorageMode
        {
            get { return settings.Get("Octopus.Storage.Mode", StorageMode.Embedded); }
            set { settings.Set("Octopus.Storage.Mode", value); }
        }

        public string EmbeddedDatabaseStoragePath
        {
            get { return Path.Combine(home.HomeDirectory, "Data"); }
        }

        public int EmbeddedDatabaseListenPort
        {
            get { return settings.Get("Octopus.Storage.EmbeddedDatabaseListenPort", 10930); }
            set { settings.Set("Octopus.Storage.EmbeddedDatabaseListenPort", value); }
        }

        public string EmbeddedDatabaseListenHostname
        {
            get { return settings.Get("Octopus.Storage.EmbeddedDatabaseListenHostname", "localhost"); }
            set { settings.Set("Octopus.Storage.EmbeddedDatabaseListenHostname", value); }
        }

        public byte[] MasterKey
        {
            get
            {
                return settings.Get<byte[]>("Octopus.Storage.MasterKey", protectionScope: DataProtectionScope.LocalMachine);
            }
            set
            {
                settings.Set("Octopus.Storage.MasterKey", value, DataProtectionScope.LocalMachine);
            }
        }

        public bool IsMasterKeyBackedUp
        {
            get { return settings.Get("Octopus.Storage.IsMasterKeyBackedUp", false); }
            set { settings.Set("Octopus.Storage.IsMasterKeyBackedUp", value); }
        }

        public void Save()
        {
            settings.Save();
        }
    }
}