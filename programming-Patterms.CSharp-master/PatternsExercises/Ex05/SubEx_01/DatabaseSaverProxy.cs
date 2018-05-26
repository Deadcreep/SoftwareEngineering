using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Patterns.Ex05.ExternalLibs;

namespace Patterns.Ex05.SubEx_01
{
    class DatabaseSaverProxy : IDatabaseSaver
    {
        MailSender mailSender;
        CacheUpdater cacheUpdater;
        DatabaseSaver dbSaver;

        public DatabaseSaverProxy(MailSender mailSender, CacheUpdater cacheUpdater, DatabaseSaver dbSaver)
        {
            this.mailSender = mailSender;
            this.cacheUpdater = cacheUpdater;
            this.dbSaver = dbSaver;
        }

        void SaveData(object data)
        {            
            mailSender.Send(data.ToString());
            cacheUpdater.UpdateCache();
            dbSaver.SaveData(data);
        }
    }
}
