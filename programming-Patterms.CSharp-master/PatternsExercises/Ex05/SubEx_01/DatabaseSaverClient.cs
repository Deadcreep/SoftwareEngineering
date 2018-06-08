using System;
using Patterns.Ex05.ExternalLibs;

namespace Patterns.Ex05.SubEx_01
{
    public class DatabaseSaverClient
    {
        public void Main(bool b)
        {
            IDatabaseSaver databaseSaver = new DatabaseSaver();
            var sender = new MailSender();
            databaseSaver = new MailSenderDecorator(databaseSaver, sender);
            databaseSaver = new MailSenderDecorator(databaseSaver, sender, "qwe@qwe.qw");
            databaseSaver = new CacheUpdaterDecorator(databaseSaver, new CacheUpdater());

            DoSmth(databaseSaver);

        }


        private void DoSmth(IDatabaseSaver saver)
        {
            saver.SaveData(null);
        }

    }

    public class DatabaseSaverDecorator : IDatabaseSaver
    {
        protected IDatabaseSaver wrap;

        public DatabaseSaverDecorator(IDatabaseSaver saver)
        {
            wrap = saver;
        }

        public void SaveData(object data)
        {
            wrap.SaveData(data);
        }
    }

    public class MailSenderDecorator : DatabaseSaverDecorator
    {
        private readonly MailSender mailSender;
        private readonly string email;
        public MailSenderDecorator(IDatabaseSaver saver, MailSender mailSender, string email = "") : base(saver)
        {
            this.mailSender = mailSender;
            this.email = email;
        }

        public new void SaveData(object data)
        {
            base.SaveData(data);
            mailSender.Send(email);
        }
    }

    public class CacheUpdaterDecorator : DatabaseSaverDecorator
    {
        private readonly CacheUpdater cacheUpdater;
        public CacheUpdaterDecorator(IDatabaseSaver saver, CacheUpdater cacheUpdater) : base(saver)
        {
            this.cacheUpdater = cacheUpdater;
        }

        public new void SaveData(object data)
        {
            base.SaveData(data);
            cacheUpdater.UpdateCache();
        }
    }

}