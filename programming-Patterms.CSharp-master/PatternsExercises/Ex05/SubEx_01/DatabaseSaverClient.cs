using Patterns.Ex05.ExternalLibs;

namespace Patterns.Ex05.SubEx_01
{
    public class DatabaseSaverClient
    {
        public void Main(bool b)
        {
            var databaseSaver = new DatabaseSaver();
            var databaseSaverProxy = new DatabaseSaverProxy(new MailSender(), new CacheUpdater(), databaseSaver);
            DoSmth(databaseSaverProxy);
        }

        private void DoSmth(IDatabaseSaver saver)
        {
            saver.SaveData(null);
        }
    }
}